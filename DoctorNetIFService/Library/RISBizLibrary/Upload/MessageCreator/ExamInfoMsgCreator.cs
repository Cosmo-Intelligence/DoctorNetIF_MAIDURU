using System;
using System.Configuration;
using System.Data;
using System.Text;
using RISBizLibrary.Data;
using RISBizLibrary.Upload.Data;
using RISCommonLibrary.Lib.Exceptions;
using RISCommonLibrary.Lib.Msg;
using RISCommonLibrary.Lib.Msg.Common.ExamInfo;
using RISCommonLibrary.Lib.Msg.Common.ExamInfo.Detail;
using RISCommonLibrary.Lib.Msg.ExamInfo;
using RISCommonLibrary.Lib.Utils;
using RISODPLibrary.Lib.Utils;

namespace RISBizLibrary.Upload.MessageCreator
{
	internal class ExamInfoMsgCreator : BaseMsgCreator
	{
		#region const

		private const string JIGO_KBN_NORMAL = "0"; //通常入力
		private const string JIGO_KBN_INPUT_AFTER = "1"; //事後入力
		private const string INFUSE_NORMAL = "31";
		private const string INFUSE_RI = "03";
		private const string XX_KBN_RI = "17";
		private const string COMMENT_KBN_DIRECTION = "32";
		private const string COMMENT_KBN_INFUSE = "33";
		private const string COMMENT_KBN_RI_TAKEPROC = "01";
		private const string COMMENT_KBN_RI_FUNC = "02";
		private const string ORDER_MODE_INPUT_AFTER = "3";
		#endregion

		#region member
		public string fYakuhin;
		public string fZairyou;
		#endregion

		#region field

		#endregion

		#region property

		/// <summary>
		/// ログ出力用名前
		/// </summary>
		public override string NameForLog
		{
			get
			{
				return "実施";
			}
		}

		#endregion

		#region constractor

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public ExamInfoMsgCreator()
			: base()
		{
		}
		#endregion

		#region IMessageCreator メンバ

		public override string[] GetRequestTypes()
		{
			return new[]
			{
				RQRISDBConst.REQUEST_TYPE_EXAM,
				RQRISDBConst.REQUEST_TYPE_EXAM_UPDATE,
				RQRISDBConst.REQUEST_TYPE_EXAM_CANCEL
			};
		}

		public override BaseMsg CreateMsg(ToHisInfo toHisInfo, IDbConnection cnRis, string pRISID, string pSyoriKbn)
		{
			_log.Info("実施情報を取得します");

			TOrderMainTable _OrderMain;
			TExtendOrderInfo _ExtendOrder;
			TExMainTable _ExMain;
			
			BaseMsg Result = null;
			try
			{
				_OrderMain = OrderMainTableMsgCreate(toHisInfo, cnRis);
				_ExtendOrder = ExtendOrderInfoMsgCreate(toHisInfo, cnRis);
				_ExMain = ExMainTableMsgCreate(toHisInfo, cnRis);
				Result = InternalCreateMsg(toHisInfo, _OrderMain, _ExtendOrder, _ExMain, pSyoriKbn, cnRis);
			}
			finally
			{
				_OrderMain = null;
				_ExtendOrder = null;
				_ExMain = null;
			}
			return Result;
		}

		public BaseMsg InternalCreateMsg(ToHisInfo toHisInfo, TOrderMainTable pOrder,
			TExtendOrderInfo pExtend, TExMainTable pExMain, string pSyoriKbn, IDbConnection cnRis)
		{
			HISRISExamMsg ret_Msg = new HISRISExamMsg();
			HISRISExamInfoAggregate _Msg = ret_Msg.MsgBody.ExamRIS;

			string _MsgType;
			string _RequestType;
			string _KENSA_DOC_ID1;
			DateTime _SakuseiDate;
			DateTime _SyoriDate;
			DateTime _ExamEndDate;
			int _ExamIdx;
			//_BuiItem:TH2RExamBUIList;
			DataRow _BuiRecord;
			DataTable _BuiList = new DataTable();
			DataTable _ToHisList = new DataTable();
			string _SQL;
			DataTable _Recset_TOHISINFO = new DataTable();
			bool _ExamUpdate_bo;

			//2014.8.25 cosmo add --------------------------------------------------- start
			string _SQL2;
			DataTable _Recset_EXMAINTABLE = new DataTable();
			//2014.8.25 cosmo add --------------------------------------------------- end

			//BaseMsg Result = null;

			_RequestType = toHisInfo.RequestType;

			//TOHISINFO上で要求種別=OP02(実施変更）で、実施が１度も送信されていない場合には
			//実施（新規）電文を作成する為に、ここで一度チェック
			_ExamUpdate_bo = true;
			_SQL = "";
			_SQL = _SQL + "select RIS_ID from TOHISINFO";
			_SQL = _SQL + " where REQUESTID != '" + toHisInfo.RequestID.ToString() + "'";
			_SQL = _SQL + "   and RIS_ID = '" + toHisInfo.RIS_ID + "'";
			_SQL = _SQL + "   and TRANSFERSTATUS =" + "'01'";
			_SQL = _SQL + "   and TRANSFERRESULT =" + "'OK'";
			_SQL = _SQL + "   and REQUESTTYPE in (" + "'OP01'" + "," + "'OP02'" + "," + ("'OP99'") + ")";
			_SQL = _SQL + " ORDER BY REQUESTID DESC";
			//_Recset_TOHISINFO = TRecordList.Create;
			try
			{
				//TDBMgr.GetDBMgr.OpenSQL(_SQL, nil, _Recset_TOHISINFO);

				using (IDbCommand command = cnRis.CreateCommand())
				{
					command.InitCommandODP(ConfigurationManager.AppSettings["CommandTimeout"].StringToInt32());
					command.CommandText = _SQL;

					//IDataParameter param = command.CreateParameter();
					//param.SetInputString(PARAM_RIS_ID, toHisInfo.RIS_ID);
					//command.Parameters.Add(param);

					MiscUtils.WriteDbCommandLogForLog4net(command, _log);

					IDataReader reader = command.ExecuteReader();
					try
					{
						_Recset_TOHISINFO.Load(reader);
						if (_Recset_TOHISINFO.Rows.Count == 0)
						{
							//throw new DataNotFoundException(string.Format(
							//	"データが見つかりませんでした。RIS_ID={0}", toHisInfo.RIS_ID));
						}

						//MiscUtils.WriteDataReaderLogForLog4net(reader, _log);

					}
					finally
					{
						reader.Close();
					}
				}
				if (_Recset_TOHISINFO.Rows.Count > 0)
				{
					_ExamUpdate_bo = false;
				}
			}
			finally
			{
				_Recset_TOHISINFO = null;
			}

			//2014.8.25 cosmo mod --------------------------------------------------- start
			//2回目以降の中止送信も電文種別=変更（2T）で設定するよう変更
			if (_RequestType == RQRISDBConst.REQUEST_TYPE_EXAM)
			{
				_MsgType = MsgConst.DENBUN_SYBT_EXAM_RIS;
			}
			else if (_RequestType == RQRISDBConst.REQUEST_TYPE_EXAM_CANCEL)
			{
				//ExmainTable.ENDCOUNTの値により電文種別を判断する
				_SQL2 = "";
				_SQL2 = _SQL2 + "select ENDCOUNT from EXMAINTABLE ";
				_SQL2 = _SQL2 + "where ris_id = '" + toHisInfo.RIS_ID + "'";
				//_Recset_EXMAINTABLE = TRecordList.Create;
				try
				{
					//TDBMgr.GetDBMgr.OpenSQL(_SQL2, nil, _Recset_EXMAINTABLE);
					using (IDbCommand command = cnRis.CreateCommand())
					{
						command.InitCommandODP(ConfigurationManager.AppSettings["CommandTimeout"].StringToInt32());
						command.CommandText = _SQL2;

						//IDataParameter param = command.CreateParameter();
						//param.SetInputString(PARAM_RIS_ID, toHisInfo.RIS_ID);
						//command.Parameters.Add(param);

						MiscUtils.WriteDbCommandLogForLog4net(command, _log);

						IDataReader reader = command.ExecuteReader();
						try
						{
							_Recset_EXMAINTABLE.Load(reader);
							if (_Recset_EXMAINTABLE.Rows.Count == 0)
							{
								//throw new DataNotFoundException(string.Format(
								//	"データが見つかりませんでした。RIS_ID={0}", toHisInfo.RIS_ID));
							}

							//MiscUtils.WriteDataReaderLogForLog4net(reader, _log);

						}
						finally
						{
							reader.Close();
						}
					}

					// 2020.08.28 Mod H.Taira@COSMO Start
					//if (int.Parse(_Recset_EXMAINTABLE.Rows[0]["ENDCOUNT"].ToString()) > 1)
					if (_Recset_EXMAINTABLE.Rows.Count > 0 && int.Parse(_Recset_EXMAINTABLE.Rows[0]["ENDCOUNT"].ToString()) > 1)
					{
						_MsgType = MsgConst.DENBUN_SYBT_EXAM_CHANGE_RIS; //実施変更
					}
					// 2020.08.28 Mod H.Taira@COSMO End
					else
					{
						_MsgType = MsgConst.DENBUN_SYBT_EXAM_RIS;        //実施電文（新規）
					}
				}
				finally
				{
					_Recset_EXMAINTABLE = null;
				}
			}
			else if (_RequestType == RQRISDBConst.REQUEST_TYPE_EXAM_UPDATE)
			{
				if (_ExamUpdate_bo)
				{
					_MsgType = MsgConst.DENBUN_SYBT_EXAM_RIS;        //実施電文（新規）
				}
				else
				{
					_MsgType = MsgConst.DENBUN_SYBT_EXAM_CHANGE_RIS; //実施変更
				}

				//2014.8.25 cosmo mod --------------------------------------------------- end

			}
			else
			{
				return ret_Msg;
			}

			//INIファイル読み込み
			//ReadIniFile;

			//Result = TH2RExamMsg.Create;
			//_Msg = TH2RExamMsg(Result).MsgBody;

			_ToHisList = ToHisInfoSelect(toHisInfo.RIS_ID, cnRis);

			try
			{
				/*ヘッダー情報*/

				if (_RequestType == RQRISDBConst.REQUEST_TYPE_EXAM_CANCEL && _ToHisList.Rows.Count != 0)
				{
					_Msg.DENBUN_SYBT.Data  = MsgConst.DENBUN_SYBT_EXAM_CHANGE_RIS;
				}
				else
				{
					if (_RequestType == RQRISDBConst.REQUEST_TYPE_EXAM_UPDATE && pSyoriKbn == MsgConst.SYORI_KBN_NEW)
					{
						if (_ExamUpdate_bo)
						{
							_Msg.DENBUN_SYBT.Data  = MsgConst.DENBUN_SYBT_EXAM_RIS;
						}
						else
						{
							_Msg.DENBUN_SYBT.Data  = MsgConst.DENBUN_SYBT_EXAM_CHANGE_RIS;
						}
					}
					else
					{
						_Msg.DENBUN_SYBT.Data  = _MsgType;
					}

				}
				_SakuseiDate = DateTime.Now;
				_Msg.SAKUSEI_DATE.Data  = _SakuseiDate.ToString("yyyyMMdd");
				_Msg.SAKUSEI_TIME.Data  = _SakuseiDate.ToString("hhmmss");
				_Msg.S_SYS_CD.Data  = ret_Msg.SrcSysCode;
				_Msg.R_SYS_CD.Data  = ret_Msg.DstSysCode;
				_Msg.HEADER_CNT.Data  = "00000001";

				// 処理区分  実施 or 検査中止の場合: 1 //
				//                     　変更の場合: 3 //
				if (_RequestType == RQRISDBConst.REQUEST_TYPE_EXAM_CANCEL && _ToHisList.Rows.Count != 0)
				{
					_Msg.SYORI_KBN.Data  = MsgConst.SYORI_KBN_CANCEL;
				}
				else
				{
					if (_RequestType == RQRISDBConst.REQUEST_TYPE_EXAM || _RequestType == RQRISDBConst.REQUEST_TYPE_EXAM_CANCEL)
					{
						_Msg.SYORI_KBN.Data  = MsgConst.SYORI_KBN_NEW;
					}
					else if (_RequestType == RQRISDBConst.REQUEST_TYPE_EXAM_UPDATE)
					{
						if (pSyoriKbn == MsgConst.SYORI_KBN_CANCEL)
						{
							_Msg.SYORI_KBN.Data  = MsgConst.SYORI_KBN_CANCEL;
						}
						else
						{
							_Msg.SYORI_KBN.Data  = MsgConst.SYORI_KBN_NEW;
						}
					}
				}



				if (DateTime.TryParse(toHisInfo.RequestDate, out _SyoriDate))
				{
					_Msg.SYORI_DATE.Data  = _SyoriDate.ToString("yyyyMMdd");
					_Msg.SYORI_TIME.Data  = _SyoriDate.ToString("hhmmss");
				}

				/*オーダーＫＥＹ情報*/
				_Msg.PT_ID.Data         = pOrder.Kanja_ID;
				_Msg.HASSEI_DATE.Data   = pExtend.ADDENDUM01;
				_Msg.SEQ_NO.Data        = StringUtils.Mid(pExtend.ADDENDUM02, 1, 2) + ":" +
											StringUtils.Mid(pExtend.ADDENDUM02, 3, 2) + ":" +
											StringUtils.Mid(pExtend.ADDENDUM02, 5, 2);
				_Msg.WS_NO.Data         = pExtend.ADDENDUM03;
				_Msg.INDEX_KBN.Data     = pExtend.ADDENDUM04;
				_Msg.XX_KBN.Data        = pExtend.ADDENDUM05;
				_Msg.XX_SYBT.Data       = pExtend.ADDENDUM06;
				_Msg.XX_SEQ.Data        = pExtend.ADDENDUM07;
				_Msg.ORDER_NO.Data      = pOrder.OrderNo;

				// キャンセル区分 実施の場合: 0              //
				//  　            中止の場合: 1　            //
				//                変更の場合は1回目送信時: 1 //
				//                            2回目送信時: 0 //
				if (_RequestType == RQRISDBConst.REQUEST_TYPE_EXAM_CANCEL && _ToHisList.Rows.Count != 0)
				{
					_Msg.CANCEL_KBN.Data  = "1";
				}
				else
				{
					if (_RequestType == RQRISDBConst.REQUEST_TYPE_EXAM)
					{
						_Msg.CANCEL_KBN.Data  = "0";
					}
					else if (_RequestType == RQRISDBConst.REQUEST_TYPE_EXAM_CANCEL)
					{
						_Msg.CANCEL_KBN.Data  = "1";
					}
					else if (_MsgType == MsgConst.DENBUN_SYBT_EXAM_CHANGE_RIS)
					{
						if (pSyoriKbn == MsgConst.SYORI_KBN_CANCEL)
						{
							_Msg.CANCEL_KBN.Data  = "0";
						}
						else
						{
							_Msg.CANCEL_KBN.Data  = "0";
						}
					}
				}
			}
			finally
			{
				_ToHisList = null;
			}

			_Msg.FILLER.Data        = "      ";
			_Msg.KNS_SYBT.Data      = StringUtils.Mid(pOrder.KensaType_ID, 1, 2);
			_Msg.XX_SUM.Data        = pExtend.ADDENDUM09;
			_Msg.ACCESSION_NO.Data  = "                ";

			//オーダ関連情報
			//2014.7.28 cosmo mod----------------------------------------------------- start
			//  if pExtend.ADDENDUM13 = ORDER_MODE_INPUT_AFTER then
			if (pExtend.ADDENDUM12 == "ORDER_MODE_INPUT_AFTER")  //★★★
			{
				//2014.7.28 cosmo mod----------------------------------------------------- end
				_Msg.JIGO_KBN.Data  = "1";
			}
			else
			{
				_Msg.JIGO_KBN.Data  = "0";
			}

			_Msg.FILLER1.Data  = " ";
			_Msg.FILLER2.Data  = " ";
			_Msg.FILLER3.Data  = " ";
			_Msg.FREE_COMMENT1.Data  = "          ";

			/*実施ヘッダ情報*/
			_Msg.JISSI_DATE.Data  = pExMain.Kensa_Date;
			DateTime.TryParse(pExMain.ExamEndDate, out _ExamEndDate);
			_Msg.JISSI_TIME.Data  = _ExamEndDate.ToString("hhmmss");

			//_Msg.KNS_DR1.Data 	  = pExMain.Kensai_ID;
			//204.8.5 cosmo mod ------------------------------------------------ start
			//  _KENSA_DOC_ID1  = GetKENSA_DOC_ID1FromExtendExamInfo(pRequest);
			_Msg.KNS_DR1.Data     = StringUtils.Mid(pExMain.EnforceDoc_ID, 1, 8);
			//204.8.5 cosmo mod ------------------------------------------------ end

			_Msg.KNS_DR2.Data     = "        ";
			_Msg.KNS_DR3.Data       = "        ";
			//204.8.5 cosmo mod ------------------------------------------------ start
			// 2020.07.14 mod start cosmo@nishihara 検査技師フラグ追加
			////  _Msg.KNS_GISI1.Data   = pExMain.Kensa_Gisi_ID;
			//_Msg.KNS_GISI1.Data   = pExMain.Jisisya_ID;
			if (ConfigurationManager.AppSettings["RESULT_IS_SET_JISISYA_AS_KENSA_GISI"] == "Y")
			{
				_Msg.KNS_GISI1.Data = pExMain.Jisisya_ID;
			}
			else
			{
				_Msg.KNS_GISI1.Data = pExMain.Kensa_Gisi_ID;
			}
			// 2020.07.14 mod end cosmo@nishihara 検査技師フラグ追加
			//204.8.5 cosmo mod ------------------------------------------------ end
			_Msg.KNS_GISI2.Data   = "        ";
			_Msg.KNS_GISI3.Data   = "        ";
			_Msg.ROOM_CD1.Data    = "  ";

			//機能検査基本情報
			if (pExtend.ADDENDUM05 == XX_KBN_RI)
			{
				AddFuncItems(_Msg.FUNC_SUMM, toHisInfo, INFUSE_RI, cnRis);
			}
			else
			{
				AddFuncItems(_Msg.FUNC_SUMM, toHisInfo, INFUSE_NORMAL, cnRis);
			}

			// 2020.07.14 mod start cosmo@nishihara 実施コメント処理内容変更(512byte以上で文字カット)
			/*RIS→HISコメント*/

			//_Msg.JISSI_COMMENT.Data = RemoveLastLonlyCR(RemoveDust(StringUtils.Mid(AdjustCRLF(pExMain.Bikou), 1, 512)));//★★

			// 2020.08.28 Mod H.Taira@COSMO Start
			//if (!string.IsNullOrEmpty(pExMain.Bikou) && !string.IsNullOrEmpty(pExMain.Siji_Isi_Comment)) {

			//	string comment = ConfigurationManager.AppSettings["SIJI_ISI_COMMENT_LINKSTRING"];
			//	_Msg.JISSI_COMMENT.Data = RemoveLastLonlyCR(RemoveDust(StringUtils.LeftB(AdjustCRLF(comment + pExMain.Siji_Isi_Comment), 512)));//★★
			//}
			//else if (!string.IsNullOrEmpty(pExMain.Bikou) && string.IsNullOrEmpty(pExMain.Siji_Isi_Comment))
			//{ 
			//	_Msg.JISSI_COMMENT.Data = RemoveLastLonlyCR(RemoveDust(StringUtils.LeftB(AdjustCRLF(pExMain.Bikou), 512)));//★★
			//}
			//else if (!string.IsNullOrEmpty(pExMain.Bikou) && !string.IsNullOrEmpty(pExMain.Siji_Isi_Comment))
			//{
			//	_Msg.JISSI_COMMENT.Data = RemoveLastLonlyCR(RemoveDust(StringUtils.LeftB(AdjustCRLF(pExMain.Bikou + pExMain.Siji_Isi_Comment), 512)));//★★
			//}
			//else
			//{
			//	_Msg.JISSI_COMMENT.Data = null;
			//}

			string comment = ConfigurationManager.AppSettings["SIJI_ISI_COMMENT_LINKSTRING"];
			string bikou= "";
			string sijiIsiComment = "";
			string name = ConfigurationManager.AppSettings["SIJI_ISI_NAME_LINKSTRING"];
			string sijiIsiName = "";
			string date = ConfigurationManager.AppSettings["SIJI_ISI_DATE_LINKSTRING"];
			string sijiIsiDate = "";
			//プレチェック
			if (!string.IsNullOrEmpty(pExMain.Bikou))
			{
				bikou = pExMain.Bikou;
			}
			if (!string.IsNullOrEmpty(pExMain.Siji_Isi_Comment))
			{
				sijiIsiComment = comment + pExMain.Siji_Isi_Comment;
			}
			if (!string.IsNullOrEmpty(pExMain.siji_isi_name))
			{
				sijiIsiName = name + pExMain.siji_isi_name;
				if (!string.IsNullOrEmpty(pExMain.siji_doctor_name))
				{
					sijiIsiName += "/" + pExMain.siji_doctor_name;
				}
			}
			if (!string.IsNullOrEmpty(pExMain.siji_isi_date))
			{
				sijiIsiDate = date + pExMain.siji_isi_date;
			}
			//_Msg.JISSI_COMMENT.Data = RemoveLastLonlyCR(StringUtils.LeftB(AdjustCRLF(bikou + sijiIsiComment), 512));//★★
			_Msg.JISSI_COMMENT.Data = RemoveLastLonlyCR(StringUtils.LeftB(AdjustCRLF(bikou + sijiIsiComment + sijiIsiName + sijiIsiDate), 1024));//★★
			// 2020.08.28 Mod H.Taira@COSMO End
			// 2020.07.14 mod end cosmo@nishihara 実施コメント処理内容変更(512byte以上で文字カット)

			/*実施部位情報*/
			_BuiList = ExBuiSelect(toHisInfo, cnRis);
			try
			{
				for (_ExamIdx  = 0; _ExamIdx < _BuiList.Rows.Count; _ExamIdx++)
				{
					_BuiRecord = _BuiList.Rows[_ExamIdx];
					H2RExamBUIAggregate _BuiItem = new H2RExamBUIAggregate();
					_Msg.BUI_SUMM.Add(_BuiItem);
					//部位基本情報
					// 2020.08.28 Mod H.Taira@COSMO Start
					//_BuiItem.BUI_SEQ.Data   = (_Msg.BUI_SUMM.Count + 1).ToString("00000");
					if (_Msg.BUI_SUMM.Count > 0)
					{
						_BuiItem.BUI_SEQ.Data   = (_Msg.BUI_SUMM.Count).ToString("00000");
					}
					else
					{
						_BuiItem.BUI_SEQ.Data   = (_Msg.BUI_SUMM.Count + 1).ToString("00000");
					}
					// 2020.08.28 Mod H.Taira@COSMO End
					_BuiItem.BUI_CD.Data    = StringUtils.Mid(_BuiRecord["BUI_ID"].ToString(), 1, 8);
					_BuiItem.ROOM_CD2.Data  = "  ";
					_BuiItem.MAC_CD.Data    = "  ";
					_BuiItem.KV.Data    = "    ";
					_BuiItem.MA.Data    = "  ";
					_BuiItem.SEC.Data   = "  ";
					_BuiItem.LENG.Data  = "  ";

					//部位詳細情報
					if (pExtend.ADDENDUM05 == XX_KBN_RI)
					{
						AddCommentItemsForRI(_BuiItem.COMMENT_SUMM, toHisInfo, _BuiRecord, _ExamIdx, cnRis);
					}
					else
					{
						AddCommentItems(_BuiItem.COMMENT_SUMM, toHisInfo, _BuiRecord, _ExamIdx, cnRis);
					}

					//体位方向情報
					//※設定なし

					//フィルム情報
					AddFilmItems(_BuiItem.FILM_SUMM, toHisInfo, _BuiRecord, cnRis);

					//撮影コマ情報
					//※設定なし

					//RIなら1部位で抜ける
					if (pExtend.ADDENDUM05 == XX_KBN_RI)
					{
						break;
					}
				}
				
			}
			finally
			{
				_BuiList = null;
			}
			/*使用薬剤情報*/
			AddDrugItems(_Msg.DRUG_SUMM, toHisInfo, cnRis);

			/*使用器材情報*/
			AddKziItems(_Msg.KZI_SUMM, toHisInfo, cnRis);

			/*使用放射性医薬品情報*/
			//※設定なし
			return ret_Msg;
		}


		public TExtendOrderInfo ExtendOrderInfoMsgCreate(ToHisInfo toHisInfo, IDbConnection cnRis)
		{
			DataTable _ResultSet = new DataTable();
			TExtendOrderInfo _ExtendOrder = new TExtendOrderInfo();
			DataRow _Record;
			string _SQL;

			TExtendOrderInfo Result = null;
			try
			{
				_SQL = "";
				_SQL = _SQL + " select ";
				_SQL = _SQL +      " RIS_ID, ADDENDUM01, ADDENDUM02, ADDENDUM03, ";
				//2014.7.24 cosmo mod----------------------------------------------------- start
				//    _SQL  = _SQL +      " ADDENDUM04, ADDENDUM05, ADDENDUM06, ADDENDUM07, ";
				_SQL = _SQL +      " ADDENDUM04, ADDENDUM05, ADDENDUM06, ADDENDUM07, ADDENDUM09, ADDENDUM12, ";
				//2014.7.24 cosmo mod----------------------------------------------------- end
				_SQL = _SQL +      " ADDENDUM11, ADDENDUM13, ADDENDUM15 ";
				_SQL = _SQL + " from ";
				_SQL = _SQL +      " ExtendOrderInfo ";
				_SQL = _SQL + " where ";
				_SQL = _SQL +      " RIS_ID = '" + toHisInfo.RIS_ID + "'";
				//TDBMgr.GetDBMgr.OpenSQL(_SQL, nil, _ResultSet);
				using (IDbCommand command = cnRis.CreateCommand())
				{
					command.InitCommandODP(ConfigurationManager.AppSettings["CommandTimeout"].StringToInt32());
					command.CommandText = _SQL;

					//IDataParameter param = command.CreateParameter();
					//param.SetInputString(PARAM_RIS_ID, toHisInfo.RIS_ID);
					//command.Parameters.Add(param);

					MiscUtils.WriteDbCommandLogForLog4net(command, _log);

					IDataReader reader = command.ExecuteReader();
					try
					{
						_ResultSet.Load(reader);
						if (_ResultSet.Rows.Count == 0)
						{
							//throw new DataNotFoundException(string.Format(
							//	"データが見つかりませんでした。RIS_ID={0}", toHisInfo.RIS_ID));
						}

						//MiscUtils.WriteDataReaderLogForLog4net(reader, _log);

					}
					finally
					{
						reader.Close();
					}
				}

				if (_ResultSet.Rows.Count == 0)
				{
					_ResultSet = null;
					return _ExtendOrder;
				}

				_Record = _ResultSet.Rows[0];
				_ExtendOrder.ADDENDUM01  = StringUtils.Mid(_Record["ADDENDUM01"].ToString(), 1, 8);
				_ExtendOrder.ADDENDUM02  = StringUtils.Mid(_Record["ADDENDUM02"].ToString(), 1, 8);
				_ExtendOrder.ADDENDUM03  = StringUtils.Mid(_Record["ADDENDUM03"].ToString(), 1, 4);
				_ExtendOrder.ADDENDUM04  = StringUtils.Mid(_Record["ADDENDUM04"].ToString() ,1, 1);
				_ExtendOrder.ADDENDUM05  = StringUtils.Mid(_Record["ADDENDUM05"].ToString(), 1, 2);
				_ExtendOrder.ADDENDUM06  = StringUtils.Mid(_Record["ADDENDUM06"].ToString(), 1, 3);
				_ExtendOrder.ADDENDUM07  = StringUtils.Mid(_Record["ADDENDUM07"].ToString(), 1, 5);
				_ExtendOrder.ADDENDUM11  = StringUtils.Mid(_Record["ADDENDUM11"].ToString(), 1, 16);
				_ExtendOrder.ADDENDUM13  = StringUtils.Mid(_Record["ADDENDUM13"].ToString(), 1, 1);
				_ExtendOrder.ADDENDUM15  = StringUtils.Mid(_Record["ADDENDUM15"].ToString(), 1, 8);
				//2014.7.24 cosmo add----------------------------------------------------- start
				_ExtendOrder.ADDENDUM09  = StringUtils.Mid(_Record["ADDENDUM09"].ToString(), 1, 2);
				_ExtendOrder.ADDENDUM12  = StringUtils.Mid(_Record["ADDENDUM12"].ToString(), 1, 1);
				//2014.7.24 cosmo add----------------------------------------------------- end
				Result = _ExtendOrder;
			}
			finally
			{
				_ResultSet = null;
			}
			return _ExtendOrder;
		}

		public TOrderMainTable OrderMainTableMsgCreate(ToHisInfo toHisInfo, IDbConnection cn)
		{
			DataTable _ResultSet = new DataTable();
			TOrderMainTable _Order = new TOrderMainTable();
			DataRow _Record;
			string _SQL;

			TOrderMainTable Result = null;
			try
			{
				_SQL= "";
				_SQL= _SQL + " select ";
				_SQL= _SQL +      " RIS_ID, KANJA_ID, ORDERNO, KENSATYPE_ID ";
				_SQL= _SQL + " from ";
				_SQL= _SQL +      " ORDERMAINTABLE ";
				_SQL= _SQL + " where ";
				_SQL= _SQL +      " RIS_ID = '" + toHisInfo.RIS_ID.ToString() + "'";
				//TDBMgr.GetDBMgr.OpenSQL(_SQL, nil, _ResultSet);
				using (IDbCommand command = cn.CreateCommand())
				{
					command.InitCommandODP(ConfigurationManager.AppSettings["CommandTimeout"].StringToInt32());
					command.CommandText = _SQL;

					//IDataParameter param = command.CreateParameter();
					//param.SetInputString(PARAM_RIS_ID, toHisInfo.RIS_ID);
					//command.Parameters.Add(param);

					MiscUtils.WriteDbCommandLogForLog4net(command, _log);

					IDataReader reader = command.ExecuteReader();
					try
					{
						_ResultSet.Load(reader);
						if (_ResultSet.Rows.Count == 0)
						{
							//throw new DataNotFoundException(string.Format(
							//	"データが見つかりませんでした。RIS_ID={0}", toHisInfo.RIS_ID));
						}

						//MiscUtils.WriteDataReaderLogForLog4net(reader, _log);

					}
					finally
					{
						reader.Close();
					}
				}

				if (_ResultSet.Rows.Count == 0)
				{
					return null;
				}
				_Record = _ResultSet.Rows[0];

				_Order.Kanja_ID = StringUtils.Mid(_Record["KANJA_ID"].ToString(), 1, 10);
				_Order.OrderNo = StringUtils.Mid(_Record["ORDERNO"].ToString(), 1, 16);
				_Order.KensaType_ID = StringUtils.Mid(_Record["KENSATYPE_ID"].ToString(), 1, 8);
				Result = _Order;
			}
			finally
			{
				_ResultSet = null;
			}
			return Result;
		}


		public TExMainTable ExMainTableMsgCreate(ToHisInfo toHisInfo, IDbConnection cn)
		{
			DataTable _ResultSet = new DataTable();
			TExMainTable _ExMain = new TExMainTable();
			DataRow _Record;
			string _SQL;

			TExMainTable Result = null;
			try
			{
				_SQL = "";
				_SQL = _SQL + " select ";
				_SQL = _SQL +      " KENSA_DATE, EXAMENDDATE, KENSAI_ID, ";
				//2014.8.5 cosmo mod --------------------------------------------------- start
				//    _SQL  = _SQL +      " KENSA_GISI_ID, KENSASITU_ID, BIKOU ";
				// 2020.07.15 mod start cosmo@nishihara SIJI_ISI_COMMENT追加
				//_SQL = _SQL +      " KENSA_GISI_ID, KENSASITU_ID, BIKOU, ";
				_SQL = _SQL +      " KENSA_GISI_ID, KENSASITU_ID, BIKOU, SIJI_ISI_COMMENT,";
				_SQL = _SQL +      " SIJI_ISI_NAME, SIJI_DOCTOR_NAME, SIJI_ISI_DATE,";
				// 2020.07.15 mod end cosmo@nishihara SIJI_ISI_COMMENT追加
				_SQL = _SQL +      " ENFORCEDOC_ID, JISISYA_ID ";
				//2014.8.5 cosmo mod --------------------------------------------------- end
				_SQL = _SQL + " from ";
				_SQL = _SQL +      " EXMAINTABLE ";
				_SQL = _SQL + " where ";
				_SQL = _SQL +      " RIS_ID = '" + toHisInfo.RIS_ID + "'";
				//TDBMgr.GetDBMgr.OpenSQL(_SQL, nil, _ResultSet);
				using (IDbCommand command = cn.CreateCommand())
				{
					command.InitCommandODP(ConfigurationManager.AppSettings["CommandTimeout"].StringToInt32());
					command.CommandText = _SQL;

					//IDataParameter param = command.CreateParameter();
					//param.SetInputString(PARAM_RIS_ID, toHisInfo.RIS_ID);
					//command.Parameters.Add(param);

					MiscUtils.WriteDbCommandLogForLog4net(command, _log);

					IDataReader reader = command.ExecuteReader();
					try
					{
						_ResultSet.Load(reader);
						if (_ResultSet.Rows.Count == 0)
						{
							//throw new DataNotFoundException(string.Format(
							//	"データが見つかりませんでした。RIS_ID={0}", toHisInfo.RIS_ID));
						}

						//MiscUtils.WriteDataReaderLogForLog4net(reader, _log);

					}
					finally
					{
						reader.Close();
					}
				}

				if (_ResultSet.Rows.Count == 0)
				{
					_ResultSet = null;
					return Result;
				}

				_Record = _ResultSet.Rows[0];
				_ExMain.Kensa_Date     = StringUtils.Mid(_Record["KENSA_DATE"].ToString(),  1, 8);
				_ExMain.ExamEndDate    = _Record["EXAMENDDATE"].ToString();
				_ExMain.Kensai_ID      = StringUtils.Mid(_Record["KENSAI_ID"].ToString(), 1, 8);
				_ExMain.Kensa_Gisi_ID  = StringUtils.Mid(_Record["KENSA_GISI_ID"].ToString(), 1, 8);
				_ExMain.KensaSitu_ID   = StringUtils.Mid(_Record["KENSASITU_ID"].ToString(), 1, 2);
				_ExMain.Bikou          = StringUtils.Mid(_Record["BIKOU"].ToString(), 1, 500);
				// 2020.07.15 mod start cosmo@nishihara SIJI_ISI_COMMENT追加
				_ExMain.Siji_Isi_Comment = StringUtils.Mid(_Record["SIJI_ISI_COMMENT"].ToString(), 1, 500);
				// 2020.07.15 mod end cosmo@nishihara SIJI_ISI_COMMENT追加

				_ExMain.siji_isi_name = StringUtils.Mid(_Record["SIJI_ISI_NAME"].ToString(), 1, 64);
				_ExMain.siji_isi_date = StringUtils.Mid(_Record["SIJI_ISI_DATE"].ToString(), 1, 64);
				_ExMain.siji_doctor_name = _Record["SIJI_DOCTOR_NAME"].ToString();

				_ExMain.EnforceDoc_ID  = StringUtils.Mid(_Record["ENFORCEDOC_ID"].ToString(), 1, 8);
				_ExMain.Jisisya_ID     = StringUtils.Mid(_Record["JISISYA_ID"].ToString(), 1, 8);
				Result = _ExMain;
			}
			finally
			{
				_ResultSet = null;
			}
			return Result;
		}

		#endregion

		public DataTable ToHisInfoSelect(string pRISID, IDbConnection cn)
		{
			DataTable _ResultSet = new DataTable();
			string _SQL;

			DataTable Result = null;

			_SQL = "";
			_SQL = _SQL + " select RIS_ID from TOHISINFO ";
			_SQL = _SQL + " where RIS_ID = '" + pRISID + "'";
			_SQL = _SQL + " and REQUESTTYPE = " + "'OP01'";
			_SQL = _SQL + " and TRANSFERSTATUS = " + "'01'";

			//TDBMgr.GetDBMgr.OpenSQL(_SQL, nil, _ResultSet);
			using (IDbCommand command = cn.CreateCommand())
			{
				command.InitCommandODP(ConfigurationManager.AppSettings["CommandTimeout"].StringToInt32());
				command.CommandText = _SQL;

				//IDataParameter param = command.CreateParameter();
				//param.SetInputString(PARAM_RIS_ID, toHisInfo.RIS_ID);
				//command.Parameters.Add(param);

				MiscUtils.WriteDbCommandLogForLog4net(command, _log);

				IDataReader reader = command.ExecuteReader();
				try
				{
					_ResultSet.Load(reader);
					if (_ResultSet.Rows.Count == 0)
					{
						//throw new DataNotFoundException(string.Format(
						//	"データが見つかりませんでした。RIS_ID={0}", pRISID));
					}

					//MiscUtils.WriteDataReaderLogForLog4net(reader, _log);
				}
				finally
				{
					reader.Close();
				}
			}
			Result = _ResultSet;
			return Result;
		}


		//---------------------------------------------------
		//オーダ情報を元に、機能検査配列に追加する
		//[引数]
		//  pOrder: TOrderMainTable; オーダ
		//  pDst: TH2RExamFUNCArray; 機能検査配列
		//[戻り値]
		//  Result: integer; 最後に追加された要素のインデックス
		//---------------------------------------------------
		public int AddFuncItems(H2RExamFUNCArray pDst, ToHisInfo toHisInfo, string pKbn, IDbConnection cn)
		{
			// 2020.10.16 Del H.Taira@COSMO Start
			//H2RExamFUNCAggregate _FUNCItem = new H2RExamFUNCAggregate();
			// 2020.10.16 Del H.Taira@COSMO End
			DataTable _FuncList;
			DataRow _FuncRec;
			int _FuncIdx;

			int Result = -1;

			_FuncList = FuncSelect(toHisInfo, pKbn, cn);
			try
			{
				if (_FuncList.Rows.Count == 0)
				{
					_FuncList = null;
					return Result;
				}

				for (_FuncIdx = 0; _FuncIdx < _FuncList.Rows.Count; _FuncIdx++)
				{
					// 2020.10.16 Add H.Taira@COSMO Start
					H2RExamFUNCAggregate _FUNCItem = new H2RExamFUNCAggregate();
					// 2020.10.16 Add H.Taira@COSMO End
					_FuncRec = _FuncList.Rows[_FuncIdx];
					Result = pDst.Add(_FUNCItem);
					//_FuncItem = pDst[_FuncIdx].FUNCInfos[Result];
					_FUNCItem.FUNC_KBN.Data  = pKbn;
					_FUNCItem.FUNC_CD.Data  = StringUtils.Right(_FuncRec["INFUSE_ID"].ToString(), 3);
				}
			}
			finally
			{
				_FuncList = null;
			}
			return Result;
		}

		public DataTable FuncSelect(ToHisInfo toHisInfo, string pKbn, IDbConnection cn)
		{
			DataTable _ResultSet = new DataTable();
			string _SQL;
			
			DataTable Result = null;

			_SQL = "";
			_SQL = _SQL + " select ";
			_SQL = _SQL +      " EXINFUSETABLE.INFUSE_ID ";
			_SQL = _SQL + " from ";
			_SQL = _SQL +      " EXINFUSETABLE, INFUSEMASTER ";
			_SQL = _SQL + " where ";
			_SQL = _SQL +      " EXINFUSETABLE.RIS_ID = '" + toHisInfo.RIS_ID + "'";
			_SQL = _SQL + " and ";
			_SQL = _SQL +      " EXINFUSETABLE.INFUSE_ID = INFUSEMASTER.INFUSE_ID";
			_SQL = _SQL + " and ";
			_SQL = _SQL +      " INFUSEMASTER.INFUSEKBN = '" + pKbn + "'";
			//TDBMgr.GetDBMgr.OpenSQL(_SQL, nil, _ResultSet);
			using (IDbCommand command = cn.CreateCommand())
			{
				command.InitCommandODP(ConfigurationManager.AppSettings["CommandTimeout"].StringToInt32());
				command.CommandText = _SQL;

				//IDataParameter param = command.CreateParameter();
				//param.SetInputString(PARAM_RIS_ID, toHisInfo.RIS_ID);
				//command.Parameters.Add(param);

				MiscUtils.WriteDbCommandLogForLog4net(command, _log);

				IDataReader reader = command.ExecuteReader();
				try
				{
					_ResultSet.Load(reader);
					if (_ResultSet.Rows.Count == 0)
					{
						//throw new DataNotFoundException(string.Format(
						//	"データが見つかりませんでした。RIS_ID={0}", toHisInfo.RIS_ID));
					}

					//MiscUtils.WriteDataReaderLogForLog4net(reader, _log);

				}
				finally
				{
					reader.Close();
				}
			}
			Result = _ResultSet;
			return Result;
		}

		public DataTable ExBuiSelect(ToHisInfo toHisInfo, IDbConnection cn)
		{
			DataTable _ResultSet = new DataTable();

			string _SQL;

			_SQL = "";
			_SQL = _SQL + " select ";
			_SQL = _SQL +      " BUI_ID, NO, KENSASITU_ID, KENSAKIKI_ID, HOUKOU_ID, KENSAHOUHOU_ID, SAYUU_ID ";
			_SQL = _SQL + " from ";
			_SQL = _SQL +      " EXBUITABLE ";
			_SQL = _SQL + " where ";
			_SQL = _SQL +      " RIS_ID = '" + toHisInfo.RIS_ID + "'";
			_SQL = _SQL + " and ";
			_SQL = _SQL +      " SATUEISTATUS = " + "'1'";

			//TDBMgr.GetDBMgr.OpenSQL(_SQL, null, _ResultSet);
			using (IDbCommand command = cn.CreateCommand())
			{
				command.InitCommandODP(ConfigurationManager.AppSettings["CommandTimeout"].StringToInt32());
				command.CommandText = _SQL;

				//IDataParameter param = command.CreateParameter();
				//param.SetInputString(PARAM_RIS_ID, toHisInfo.RIS_ID);
				//command.Parameters.Add(param);

				MiscUtils.WriteDbCommandLogForLog4net(command, _log);

				IDataReader reader = command.ExecuteReader();
				try
				{
					_ResultSet.Load(reader);
					if (_ResultSet.Rows.Count == 0)
					{
						//throw new DataNotFoundException(string.Format(
						//	"データが見つかりませんでした。RIS_ID={0}", toHisInfo.RIS_ID));
					}

					//MiscUtils.WriteDataReaderLogForLog4net(reader, _log);

				}
				finally
				{
					reader.Close();
				}
			}
			DataTable Result = _ResultSet;
			return Result;
		}
		//---------------------------------------------------
		//実績検査情報を元に、コメント配列に追加する（RIの場合）
		//---------------------------------------------------
		public int AddCommentItemsForRI(H2RExamCOMMENTArray pDst, ToHisInfo toHisInfo, DataRow pBuiRecord, int pIdx, IDbConnection cn)
		{
			H2RExamCOMMENTAggregate _CommentItem = new H2RExamCOMMENTAggregate();
			DataTable _InfuseIdList;
			int _CommentIdx, _HouhouCnt, _KinouCnt, _Total;
			
			DataTable _BuiRecList;
			DataRow _BuiRec;

			int Result  = -1;
			_BuiRec = ExBuiSelectForRI(toHisInfo, cn);
			_InfuseIdList = InfuseID_Select(toHisInfo, pIdx + 1, "02", cn);
			try
			{
				//if (_BuiRec.ItemArray.Length != 0)
				if (_BuiRec != null && 
					_BuiRec.ItemArray.Length != 0)
				{
					//ExBuiTable.KENSAHOUHOU_ID設定時
					//if (StringUtils.Right(_BuiRec["KENSAHOUHOU_ID"].ToString(), 3) != "000")
					if (!string.IsNullOrEmpty(_BuiRec["KENSAHOUHOU_ID"].ToString()) && 
						StringUtils.Right(_BuiRec["KENSAHOUHOU_ID"].ToString(), 3) != "000")
					{
						Result = pDst.Add(_CommentItem);
						//Result = pDst.Add();
						//_CommentItem = pDst.COMMENTInfos[Result];
						_CommentItem.COMMENT_KBN.Data  = COMMENT_KBN_RI_TAKEPROC;
						_CommentItem.COMMENT_CODE.Data  = StringUtils.Right(_BuiRec["KENSAHOUHOU_ID"].ToString(), 3);
					}
				}

				for (_CommentIdx  = 0; _CommentIdx < _InfuseIdList.Rows.Count; _CommentIdx++)
				{
					if (_InfuseIdList.Rows[pIdx]["INFUSE_ID"].ToString() != "")
					{
						//Result = pDst.Add(_CommentItem);
						////_CommentItem = pDst.COMMENTInfos[Result];
						//_CommentItem.COMMENT_KBN.Data  = COMMENT_KBN_RI_FUNC;
						//_CommentItem.COMMENT_CODE.Data  = StringUtils.Right(_InfuseIdList.Rows[_CommentIdx]["INFUSE_ID"].ToString(), 3);
						H2RExamCOMMENTAggregate _CommentItem2 = new H2RExamCOMMENTAggregate();
						Result = pDst.Add(_CommentItem2);
						//_CommentItem = pDst.COMMENTInfos[Result];
						_CommentItem2.COMMENT_KBN.Data  = COMMENT_KBN_RI_FUNC;
						_CommentItem2.COMMENT_CODE.Data  = StringUtils.Right(_InfuseIdList.Rows[_CommentIdx]["INFUSE_ID"].ToString(), 3);
					}
				}
			}
			finally
			{
				_InfuseIdList = null;
				_BuiRecList = null;
			}
			return Result;

		}

		//---------------------------------------------------
		//実績検査情報を元に、コメント配列に追加する（RI以外）
		//---------------------------------------------------
		public int AddCommentItems(H2RExamCOMMENTArray pDst, ToHisInfo toHisInfo, DataRow pBuiRecord, int pIdx, IDbConnection cn)
		{
			H2RExamCOMMENTAggregate _CommentItem = new H2RExamCOMMENTAggregate();
			int _CommentIdx, _HoukouCnt, _HouhouCnt, _Total;
			DataTable _BuiRecList;
			DataTable _InfuseList;
			DataRow _BuiRec;
			int _InfuseIdx;
			int _BuiNo;

			int Result = -1;
			//ExBuiTable.Noを取得
			_BuiNo = int.Parse(pBuiRecord["NO"].ToString());
			//ExBuiTable取得
			_BuiRec = ExBuiSelectNotNone(toHisInfo, "HOUKOU_ID", _BuiNo, cn);

			//ExInfuseTable取得
			_InfuseList = InfuseID_Select(toHisInfo, _BuiNo, "33", cn);

			try
			{
				if (_BuiRec != null)
				{
					if (_BuiRec.ItemArray.Length != 0)
					{
						//ExBuiTable.HOUKOU_ID設定時
						if (_BuiRec["HOUKOU_ID"].ToString() != "")
						{
							Result = pDst.Add(_CommentItem);

							_CommentItem.COMMENT_KBN.Data  = COMMENT_KBN_DIRECTION;
							_CommentItem.COMMENT_CODE.Data  = StringUtils.Right(_BuiRec["HOUKOU_ID"].ToString(), 3);
						}

					}
				}

				//取得したExInfuseTableのレコード分繰り返し
				for (_InfuseIdx = 0; _InfuseIdx < _InfuseList.Rows.Count; _InfuseIdx++)
				{
					if (_InfuseList.Rows[_InfuseIdx]["INFUSE_ID"].ToString() != "")
					{
						//Result = pDst.Add(_CommentItem);
						////_CommentItem = pDst.COMMENTInfos[Result];
						//_CommentItem.COMMENT_KBN.Data = COMMENT_KBN_INFUSE;
						//_CommentItem.COMMENT_CODE.Data = StringUtils.Right(_InfuseList.Rows[_InfuseIdx]["INFUSE_ID"].ToString(), 3);
						H2RExamCOMMENTAggregate _CommentItem2 = new H2RExamCOMMENTAggregate();
						Result = pDst.Add(_CommentItem2);
						//_CommentItem = pDst.COMMENTInfos[Result];
						_CommentItem2.COMMENT_KBN.Data = COMMENT_KBN_INFUSE;
						_CommentItem2.COMMENT_CODE.Data = StringUtils.Right(_InfuseList.Rows[_InfuseIdx]["INFUSE_ID"].ToString(), 3);
					}
				}
			}
			finally
			{
				_BuiRecList = null;
				_InfuseList = null;
			}
			return Result;
		}


		public DataRow ExBuiSelectNotNone(ToHisInfo toHisInfo, string pIdKbn, int pIdx, IDbConnection cn)
		{
			DataTable _ResultSet = new DataTable();
			string _SQL;
			DataRow Result;

			_SQL = "";
			_SQL = _SQL + " select ";
			_SQL = _SQL +      " NO, " +  pIdKbn;
			_SQL = _SQL + " from ";
			_SQL = _SQL +      " EXBUITABLE ";
			_SQL = _SQL + " where ";
			_SQL = _SQL +      " RIS_ID = '" + toHisInfo.RIS_ID + "'";
			_SQL = _SQL + " and ";
			_SQL = _SQL +      " NO = '" + pIdx.ToString() + "'";
			_SQL = _SQL + " and ";
			_SQL = _SQL +      " not " + pIdKbn + " like " + "'%000'";
			_SQL = _SQL + " and ";
			_SQL = _SQL +      " SATUEISTATUS = " + "'1'";
			_SQL = _SQL + " order by NO";

			//TDBMgr.GetDBMgr.OpenSQL(_SQL, nil, _ResultSet);
			using (IDbCommand command = cn.CreateCommand())
			{
				command.InitCommandODP(ConfigurationManager.AppSettings["CommandTimeout"].StringToInt32());
				command.CommandText = _SQL;

				//IDataParameter param = command.CreateParameter();
				//param.SetInputString(PARAM_RIS_ID, toHisInfo.RIS_ID);
				//command.Parameters.Add(param);

				MiscUtils.WriteDbCommandLogForLog4net(command, _log);

				IDataReader reader = command.ExecuteReader();
				try
				{
					_ResultSet.Load(reader);
					if (_ResultSet.Rows.Count == 0)
					{
						//throw new DataNotFoundException(string.Format(
						//	"データが見つかりませんでした。RIS_ID={0}", toHisInfo.RIS_ID));
					}

					//MiscUtils.WriteDataReaderLogForLog4net(reader, _log);

				}
				finally
				{
					reader.Close();
				}
			}

			if (_ResultSet.Rows.Count == 0)
			{
				Result  = null;
			}
			else
			{
				Result = _ResultSet.Rows[0];
			}
			return Result;
		}


		public DataTable InfuseID_Select(ToHisInfo toHisInfo, int pIdx, string pInfKbn, IDbConnection cn)
		{
			DataTable _ResultSet = new DataTable();
			string _SQL;
			int _test;

			DataTable Result  = null;

			//_ResultSet = TRecordList.Create;

			_SQL = "";
			_SQL = _SQL + " select EXINFUSETABLE.INFUSE_ID ";
			_SQL = _SQL + " from EXINFUSETABLE, INFUSEMASTER, EXBUITABLE";
			_SQL = _SQL + " where EXINFUSETABLE.RIS_ID = '" + toHisInfo.RIS_ID + "'";
			_SQL = _SQL + " and EXINFUSETABLE.RIS_ID = EXBUITABLE.RIS_ID";
			_SQL = _SQL + " and EXINFUSETABLE.BUI_NO = '" + pIdx.ToString() + "'";  // RIはプラス１をパラメータ渡しする
			_SQL = _SQL + " and EXINFUSETABLE.BUI_NO = EXBUITABLE.NO";
			_SQL = _SQL + " and EXINFUSETABLE.INFUSE_ID = INFUSEMASTER.INFUSE_ID ";
			_SQL = _SQL + " and INFUSEMASTER.INFUSEKBN = '" + pInfKbn + "'";
			_SQL = _SQL + " and EXBUITABLE.SATUEISTATUS = " + "'1'";

			//TDBMgr.GetDBMgr.OpenSQL(_SQL, nil, _ResultSet);
			using (IDbCommand command = cn.CreateCommand())
			{
				command.InitCommandODP(ConfigurationManager.AppSettings["CommandTimeout"].StringToInt32());
				command.CommandText = _SQL;

				//IDataParameter param = command.CreateParameter();
				//param.SetInputString(PARAM_RIS_ID, toHisInfo.RIS_ID);
				//command.Parameters.Add(param);

				MiscUtils.WriteDbCommandLogForLog4net(command, _log);

				IDataReader reader = command.ExecuteReader();
				try
				{
					_ResultSet.Load(reader);
					if (_ResultSet.Rows.Count == 0)
					{
						//throw new DataNotFoundException(string.Format(
						//	"データが見つかりませんでした。RIS_ID={0}", toHisInfo.RIS_ID));
					}

					//MiscUtils.WriteDataReaderLogForLog4net(reader, _log);

				}
				finally
				{
					reader.Close();
				}
			}
			Result = _ResultSet;
			return Result;
		}

		public DataRow ExBuiSelectForRI(ToHisInfo toHisInfo, IDbConnection cn)
		{
			DataTable _ResultSet = new DataTable();
			string _SQL;

			DataRow Result = null;

			_SQL = "";
			_SQL = _SQL + " select ";
			_SQL = _SQL +        " EB.KENSAHOUHOU_ID ";
			_SQL = _SQL + " from ";
			_SQL = _SQL +        " EXBUITABLE EB";
			_SQL = _SQL + " where ";
			_SQL = _SQL +        " EB.RIS_ID = '" + toHisInfo.RIS_ID + "'";
			//2009/03/26 nsk 変更 start --------------------------------------------------------
			//  _SQL  = _SQL + " and ";
			//  _SQL  = _SQL +        " EB.RIS_ID = OM.RIS_ID ";
			//2009/03/26 nsk 変更 end --------------------------------------------------------
			_SQL = _SQL + " and ";
			_SQL = _SQL +        " EB.SATUEISTATUS = " + "'1'";
			//2009/03/26 nsk 変更 start --------------------------------------------------------
			//  _SQL  = _SQL + " and ";
			//  _SQL  = _SQL +        " not EB.KENSAHOUHOU_ID like " + SingleQuote("%000");
			//2009/03/26 nsk 変更 end --------------------------------------------------------

			//TDBMgr.GetDBMgr.OpenSQL(_SQL, nil, _ResultSet);

			using (IDbCommand command = cn.CreateCommand())
			{
				command.InitCommandODP(ConfigurationManager.AppSettings["CommandTimeout"].StringToInt32());
				command.CommandText = _SQL;

				MiscUtils.WriteDbCommandLogForLog4net(command, _log);

				IDataReader reader = command.ExecuteReader();
				try
				{
					_ResultSet.Load(reader);
					if (_ResultSet.Rows.Count == 0)
					{
						//throw new DataNotFoundException(string.Format(
						//	"データが見つかりませんでした。RIS_ID={0}", toHisInfo.RIS_ID));
					}
				}
				finally
				{
					reader.Close();
				}
			}

			// 2020.08.28 Mod H.Taira@COSMO Start
			if (_ResultSet.Rows.Count == 0)
			{
				Result = null;
			}
			else
			{
				Result = _ResultSet.Rows[0];
			}

			//Result = _ResultSet.Rows[0];
			// 2020.08.28 Mod H.Taira@COSMO End
			return Result;
		}


		//---------------------------------------------------
		//実績検査情報からフィルム配列に追加する
		//[引数]
		//  pExamInfo: TExamInfoPfm; 実績検査
		//  pDst: TH2RExamFILMArray; フィルム配列
		//[戻り値]
		//  Result: integer; 最後に追加された要素のインデックス
		//---------------------------------------------------
		public int AddFilmItems(H2RExamFILMArray pDst, ToHisInfo toHisInfo, DataRow pBuiRecord, IDbConnection cn)
		{
			int _FilmIdx;
			H2RExamFILMAggregate _FilmItem = new H2RExamFILMAggregate();
			DataTable _FilmList = new DataTable();
			DataRow _FilmRec;
			int _Used, _Partition;

			int Result  = -1;

			_FilmList = ExFilmSelect(toHisInfo, pBuiRecord, cn);
			try
			{
				if (_FilmList.Rows.Count == 0)
				{
					_FilmList = null;
					return Result;

				}

				for (_FilmIdx = 0; _FilmIdx < _FilmList.Rows.Count; _FilmIdx++)
				{
					_FilmRec = _FilmList.Rows[_FilmIdx];

					//ExFilmTable.USED がNullの場合は0
					if (_FilmRec["USED"].ToString() == "")
					{
						_Used = 0;
					}
					else
					{
						_Used = int.Parse(_FilmRec["USED"].ToString());
					}

					//ExFilmTable.PARTITION がNullの場合は0
					if (_FilmRec["PARTITION"].ToString() == "")
					{
						_Partition = 0;
					}
					else
					{
						_Partition = int.Parse(_FilmRec["PARTITION"].ToString());
					}


					Result = pDst.Add(_FilmItem);
					//_FilmItem = pDst.FILMInfos[Result];

					_FilmItem.FILM_CD.Data   = StringUtils.Mid(_FilmRec["FILM_ID"].ToString(), 1, 4);

					_FilmItem.FILM_CNT.Data  = _Used.ToString("00000");

					_FilmItem.KAKU_CNT.Data  = _Partition.ToString("00000");

					_FilmItem.SATU_CNT.Data  = (_Used * _Partition).ToString("00000");
				}
			}
			finally
			{
				_FilmList = null;
			}

			return Result;
		}


		public DataTable ExFilmSelect(ToHisInfo toHisInfo, DataRow pBuiRecord, IDbConnection cn)
		{
			DataTable _ResultSet = new DataTable();
			string _SQL;
			DataTable Result = null;

			_SQL = "";
			_SQL = _SQL + " select ";
			_SQL = _SQL +      " FILM_ID, USED, PARTITION, LOSS ";
			_SQL = _SQL + " from ";
			_SQL = _SQL +      " EXFILMTABLE ";
			_SQL = _SQL + " where ";
			_SQL = _SQL +      " RIS_ID = '" + toHisInfo.RIS_ID + "'";
			_SQL = _SQL + " and ";
			_SQL = _SQL +      " BUI_NO = '" + pBuiRecord["NO"] + "'";
			_SQL = _SQL + " order by NO";

			//TDBMgr.GetDBMgr.OpenSQL(_SQL, nil, _ResultSet);
			using (IDbCommand command = cn.CreateCommand())
			{
				command.InitCommandODP(ConfigurationManager.AppSettings["CommandTimeout"].StringToInt32());
				command.CommandText = _SQL;

				//IDataParameter param = command.CreateParameter();
				//param.SetInputString(PARAM_RIS_ID, toHisInfo.RIS_ID);
				//command.Parameters.Add(param);

				MiscUtils.WriteDbCommandLogForLog4net(command, _log);

				IDataReader reader = command.ExecuteReader();
				try
				{
					_ResultSet.Load(reader);
					if (_ResultSet.Rows.Count == 0)
					{
						//throw new DataNotFoundException(string.Format(
						//	"データが見つかりませんでした。RIS_ID={0}", toHisInfo.RIS_ID));
					}

					//MiscUtils.WriteDataReaderLogForLog4net(reader, _log);

				}
				finally
				{
					reader.Close();
				}
			}

			Result = _ResultSet;
			return Result;
		}

		public DataRow CommentSelect(string pColumn, ToHisInfo toHisInfo, int pIdx, IDbConnection cn)
		{

			DataTable _ResultSet = new DataTable();
			DataRow _Record;
			string _SQL;

			DataRow Result = null;

			_SQL = "";
			_SQL = _SQL + " select ";
			_SQL = _SQL +        pColumn;
			_SQL = _SQL + " from ";
			_SQL = _SQL +       "EXBUITABLE";
			_SQL = _SQL + " where ";
			_SQL = _SQL +      "RIS_ID = '" + toHisInfo.RIS_ID + "'";
			_SQL = _SQL + " and ";
			_SQL = _SQL +      " SATUEISTATUS = " + "'1'";
			_SQL = _SQL + " order by NO";

			//TDBMgr.GetDBMgr.OpenSQL(_SQL, nil, _ResultSet);
			using (IDbCommand command = cn.CreateCommand())
			{
				command.InitCommandODP(ConfigurationManager.AppSettings["CommandTimeout"].StringToInt32());
				command.CommandText = _SQL;

				//IDataParameter param = command.CreateParameter();
				//param.SetInputString(PARAM_RIS_ID, toHisInfo.RIS_ID);
				//command.Parameters.Add(param);

				MiscUtils.WriteDbCommandLogForLog4net(command, _log);

				IDataReader reader = command.ExecuteReader();
				try
				{
					_ResultSet.Load(reader);
					if (_ResultSet.Rows.Count == 0)
					{
						//throw new DataNotFoundException(string.Format(
						//	"データが見つかりませんでした。RIS_ID={0}", toHisInfo.RIS_ID));
					}

					//MiscUtils.WriteDataReaderLogForLog4net(reader, _log);

				}
				finally
				{
					reader.Close();
				}
			}

			Result = _ResultSet.Rows[pIdx];
			return Result;
		}



		//---------------------------------------------------
		//オーダ情報を元に、使用薬剤配列に追加する
		//[引数]
		//  pOrder: TOrderMainTable; オーダ
		//  pDst: TH2RExamDRUGArray; 使用薬剤配列
		//[戻り値]
		//  Result: integer; 最後に追加された要素のインデックス
		//---------------------------------------------------
		public int AddDrugItems(H2RExamDRUGArray pDst, ToHisInfo toHisInfo, IDbConnection cn)
		{
			int _DrugIdx;
			// 2020.08.28 Del H.Taira@COSMO Start
			//H2RExamDRUGAggregate _DrugItem = new H2RExamDRUGAggregate();
			// 2020.08.28 Del H.Taira@COSMO End
			DataTable _DrugList = new DataTable();
			DataRow _DrugRec;
			string fYakuhin = "";

			// 2020.08.28 Add H.Taira@COSMO Start
			fYakuhin = ConfigurationManager.AppSettings["KIZAIKBN_YAKUHIN"];
			// 2020.08.28 Add H.Taira@COSMO End
			int Result = -1;

			_DrugList = DrugKziSelect(toHisInfo, fYakuhin, cn);

			try
			{
				if (_DrugList.Rows.Count == 0)
				{
					_DrugList = null;
					return Result;
				}

				for (_DrugIdx = 0; _DrugIdx < _DrugList.Rows.Count; _DrugIdx++)
				{
					_DrugRec = _DrugList.Rows[_DrugIdx];
					// 2020.08.28 Add H.Taira@COSMO Start
					H2RExamDRUGAggregate _DrugItem = new H2RExamDRUGAggregate();
					// 2020.08.28 Add H.Taira@COSMO End
					Result = pDst.Add(_DrugItem);
					//_DrugItem = pDst.DRUGInfos[Result];
					_DrugItem.DRUG_CD.Data  = StringUtils.Right(_DrugRec["PARTS_ID"].ToString(), 8);
					if (_DrugRec["SUURYOU"].ToString().Length >= 6)
					{
						_DrugItem.DRUG_CNT.Data  = "99999";
					}
					else
					{
						_DrugItem.DRUG_CNT.Data  = int.Parse(_DrugRec["SUURYOU"].ToString()).ToString("00000");
						_DrugItem.DRUG_STD_CD.Data  = StringUtils.Mid(_DrugRec["ZOUEIZAITANNI_ID"].ToString(), 1, 2);
					}
				}
			}
			finally
			{
				_DrugList = null;
			}
			return Result;
		}

		public DataTable DrugKziSelect(ToHisInfo toHisInfo, string pKbn, IDbConnection cn)
		{
			DataTable _ResultSet = new DataTable();
			string _SQL;

			DataTable Result  = null;
			//_ResultSet = TRecordList.Create;

			_SQL = "";
			_SQL = _SQL + " select zo.ris_id , zo.PARTS_ID, zo.SUURYOU, pa.ZOUEIZAITANNI_ID";
			_SQL = _SQL + " from EXZOUEIZAITABLE zo, EXBUITABLE bui, PARTSMASTER pa ";
			_SQL = _SQL + " where bui.ris_id = '" + toHisInfo.RIS_ID + "'";
			_SQL = _SQL + " and zo.ris_id = bui.ris_id ";
			_SQL = _SQL + " and zo.BUI_NO = bui.NO ";
			_SQL = _SQL + " and bui.SATUEISTATUS = " + "'1'";
			_SQL = _SQL + " and zo.PARTS_ID = pa.ZOUEIZAI_ID";
			_SQL = _SQL + " and pa.ZOUEIZAIKBN = '" + (pKbn) + "'";
			_SQL = _SQL + " order by zo.bui_no, zo.no";

			//TDBMgr.GetDBMgr.OpenSQL(_SQL, nil, _ResultSet);
			using (IDbCommand command = cn.CreateCommand())
			{
				command.InitCommandODP(ConfigurationManager.AppSettings["CommandTimeout"].StringToInt32());
				command.CommandText = _SQL;

				//IDataParameter param = command.CreateParameter();
				//param.SetInputString(PARAM_RIS_ID, toHisInfo.RIS_ID);
				//command.Parameters.Add(param);

				MiscUtils.WriteDbCommandLogForLog4net(command, _log);

				IDataReader reader = command.ExecuteReader();
				try
				{
					_ResultSet.Load(reader);
					if (_ResultSet.Rows.Count == 0)
					{
						//throw new DataNotFoundException(string.Format(
						//	"データが見つかりませんでした。RIS_ID={0}", toHisInfo.RIS_ID));
					}

					//MiscUtils.WriteDataReaderLogForLog4net(reader, _log);

				}
				finally
				{
					reader.Close();
				}
			}
			Result = _ResultSet;

			return Result;
		}


		//---------------------------------------------------
		//オーダ情報を元に、使用器材配列に追加する
		//[引数]
		//  pOrder: TOrderMainTable; オーダ
		//  pDst: TH2RExamKZIArray; 使用器材配列
		//[戻り値]
		//  Result: integer; 最後に追加された要素のインデックス
		public int AddKziItems(H2RExamKZIArray pDst, ToHisInfo toHisInfo, IDbConnection cn)
		{
			int _KziIdx;
			//H2RExamKZIAggregate _KziItem =new H2RExamKZIAggregate();
			DataTable _KziList = new DataTable();
			DataRow _KziRec;
			// 2020.08.28 Add H.Taira@COSMO Start
			fZairyou = ConfigurationManager.AppSettings["KIZAIKBN_ZAIRYOU"];
			// 2020.08.28 Add H.Taira@COSMO End
			int Result = -1;
			_KziList = DrugKziSelect(toHisInfo, fZairyou, cn);
			try
			{
				if (_KziList.Rows.Count == 0)
				{
					_KziList = null;
					return Result;
				}

				for (_KziIdx = 0; _KziIdx < _KziList.Rows.Count; _KziIdx++)
				{
					_KziRec = _KziList.Rows[_KziIdx];
					H2RExamKZIAggregate _KziItem = new H2RExamKZIAggregate();
					Result = pDst.Add(_KziItem);
					//_KziItem = pDst.KZIInfos[Result];
					_KziItem.KZI_CD.Data  = StringUtils.Right(_KziRec["PARTS_ID"].ToString(), 8);

					if (int.Parse(_KziRec["SUURYOU"].ToString()) >= 6)
					{
						_KziItem.KZI_CNT.Data  = "99999";
					}
					else
					{
						_KziItem.KZI_CNT.Data  = int.Parse(_KziRec["SUURYOU"].ToString()).ToString("00000");  // 07/02/19 1000倍外し
						_KziItem.KZI_STD_CD.Data  = StringUtils.Mid(_KziRec["ZOUEIZAITANNI_ID"].ToString(), 1, 2);
					}
				}
			}
			finally
			{
				_KziList = null;
			}
			return Result;

		}

		//---------------------------------------------------
		//文字列から末尾にCRLFでないLFだけがあったら消す
		//pSrc: string; 処理文字列
		//Result: string; 処理結果
		//---------------------------------------------------
		public string RemoveLastLonlyCR(string pSrc)
		{
			string _last;
			string _prevLast;
			string Result;

			Result = pSrc;
			if (string.IsNullOrEmpty(pSrc))
			{
				return pSrc;
			}
			if (!isHankaku(Result.Substring(Result.Length - 1, 1)))
			{
				return Result;
			}

			// 2020.07.15 mod end cosmo@nishihara 末尾に"\r"が来た場合"\r"をカットする処理に変更
			////最後がCRだった削除
			//if (Result.LastIndexOf("\r") == -1)
			//{
			//	Result = Result.Substring(0, Result.Length - 1);
			//}

			if (!string.IsNullOrEmpty(Result))
			{
				string Result_Endstr = Result.Substring(Result.Length - 1, 1);
				//末尾がCRだったら削除
				if (Result_Endstr.LastIndexOf("\r") != -1)
				{
					Result = Result.Substring(0, Result.Length - 1);
				}
			}
			return Result;

		}


		//---------------------------------------------------
		//文字列から末尾の２バイトゴミを取り除く
		//pSrc: string; 処理文字列
		//Result: string; 処理結果
		//---------------------------------------------------
		public string RemoveDust(string pSrc)
		{
			string Result = pSrc;
			if (string.IsNullOrEmpty(pSrc))
			{
				return pSrc;
			}
			if (isZenkaku(Result.Substring(Result.Length - 1, 1)))
			{
				Result = Result.Substring(0, Result.Length - 1);
			}
			return Result;
		}


		//---------------------------------------------------
		//CRLFのスタイルに変更する
		//pSrc: string; 該当文字列
		//Result: string;
		//---------------------------------------------------
		public string AdjustCRLF(string pSrc)
		{
			return pSrc.Replace("\r\n", "\n").Replace("\r", "\n").Replace("\n", "\r\n");
		}

		 public static bool isHankaku(string str)
		{
			int num = Encoding.GetEncoding(ConfigurationManager.AppSettings["MessageEncode"].StringToString()).GetByteCount(str);
			return num == str.Length;
		}

		public static bool isZenkaku(string str)
		{
			int num = Encoding.GetEncoding(ConfigurationManager.AppSettings["MessageEncode"].StringToString()).GetByteCount(str);
			return num == str.Length * 2;
		}

		public override BaseMsgData CreateMsgData()
		{
			return new ExamInfoMsgData();
		}

		public class TOrderMainTable
		{
			public string Kanja_ID;
			public string OrderNo;
			public string KensaType_ID;

		}

		public class TExtendOrderInfo
		{
			public string ADDENDUM01;
			public string ADDENDUM02;
			public string ADDENDUM03;
			public string ADDENDUM04;
			public string ADDENDUM05;
			public string ADDENDUM06;
			public string ADDENDUM07;
			public string ADDENDUM11;
			public string ADDENDUM13;
			public string ADDENDUM15;
			public string ADDENDUM09;
			public string ADDENDUM12;
		}

		public class TExMainTable
		{
			public string Kensa_Date;
			public string ExamEndDate;
			public string Kensai_ID;
			public string Kensa_Gisi_ID;
			public string KensaSitu_ID;
			public string Bikou;
			// 2020.07.15 mod start cosmo@nishihara SIJI_ISI_COMMENT追加
			public string Siji_Isi_Comment;
			// 2020.07.15 mod end cosmo@nishihara SIJI_ISI_COMMENT追加
			public string EnforceDoc_ID;
			public string Jisisya_ID;

			public string siji_isi_name;
			public string siji_doctor_name;
			public string siji_isi_date;
		}
	}
}
