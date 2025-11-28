using System.Configuration;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using RISBizLibrary.Data;
using RISBizLibrary.Download.Data;
using RISCommonLibrary.Lib.Exceptions;
using RISCommonLibrary.Lib.Msg.Common.OrderInfo;
using RISCommonLibrary.Lib.Utils;
using RISODPLibrary.Lib.Utils;

namespace RISBizLibrary.Updater.Table
{
	public class ORDERINDICATETABLEUpdaterOrderInfo : BaseUpdater
	{
		#region const
		private const string XX_KBN_RI        = "17";
		#region InsertSQL

		/// <summary>
		/// InsertSQL
		/// </summary>
		private const string INSERT_SQL =
		"MERGE INTO ORDERINDICATETABLE p " +
		"USING " +
		"( " +
			"SELECT " +
				":RIS_ID RIS_ID, " +
				":ORDERCOMMENT_ID ORDERCOMMENT_ID, " +
				":KENSA_SIJI KENSA_SIJI, " +
				":RINSYOU RINSYOU, " +
				":REMARKS REMARKS " +
			"FROM " +
				"DUAL " +
		") pn " +
		"ON " +
		"( p.RIS_ID = pn.RIS_ID) " +
		//"WHEN MATCHED THEN " + //-- 既存レコードの更新
		//	"UPDATE SET " +
		//		"ORDERCOMMENT_ID = pn.ORDERCOMMENT_ID, " +
		//		"KENSA_SIJI = pn.KENSA_SIJI, " +
		//		"RINSYOU = pn.RINSYOU, " +
		//		"REMARKS = pn.REMARKS " +
		"WHEN NOT MATCHED THEN " + //新規レコードの作成
			"INSERT " +
			"( " +
				"RIS_ID, " +
				"ORDERCOMMENT_ID, " +
				"KENSA_SIJI, " +
				"RINSYOU, " +
				"REMARKS " +
			") " +
			"VALUES " +
			"( " +
				"pn.RIS_ID, " +
				"pn.ORDERCOMMENT_ID, " +
				"pn.KENSA_SIJI, " +
				"pn.RINSYOU, " +
				"pn.REMARKS " +
			") ";

		#endregion
		#endregion

		#region param
		/// <summary>
		/// RIS_ID
		/// </summary>
		private const string PARAM_NAME_RIS_ID = "RIS_ID";

		/// <summary>
		/// ORDERCOMMENT_ID
		/// </summary>
		private const string PARAM_NAME_ORDERCOMMENT_ID = "ORDERCOMMENT_ID";

		/// <summary>
		/// KENSA_SIJI
		/// </summary>
		private const string PARAM_NAME_KENSA_SIJI = "KENSA_SIJI";

		/// <summary>
		/// RINSYOU
		/// </summary>
		private const string PARAM_NAME_RINSYOU = "RINSYOU";

		/// <summary>
		/// REMARKS
		/// </summary>
		private const string PARAM_NAME_REMARKS = "REMARKS";


		/// <summary>
		/// INFUSE_ID
		/// </summary>
		private const string PARAM_NAME_INFUSE_ID = "INFUSE_ID";

		/// <summary>
		/// COMMENT_ID
		/// </summary>
		private const string PARAM_NAME_COMMENT_ID = "COMMENT_ID";
		#endregion


		#region field
		#endregion

		public override string TargetSQL
		{
			get
			{
				return INSERT_SQL;
			}
		}

		public override void SetParams(BaseMsgData data, System.Data.IDbCommand command)
		{
			command.Parameters.Clear();
			OrderInfoMsgData orderData = (OrderInfoMsgData)data;
			HISRISOrderInfoAggregate order = orderData.Request.MsgBody.OrderInfo;

			//_SQL       : TInsertSQLCreator;
			string _PartsStr = "";
			int _BuiIdx;
			string _Flg = "";
			int _CommentIdx;
			string _IDStr = "";
			string _NameStr = "";
			string _InfuseStr = "";
			string _InfuseName;
			string _KensaStr = "";
			string _ComName = "";
			string _ComStr = "";
			string _BUiComStr = "";
			string _KinouKensaStr;
			string _BUiFreeComStr = "";

			int _YKIdx;
			string _DateTime = "";
			string _DateYYYY = "";
			string _DateMM = "";
			string _DateDD = "";
			string _Time_JI = "";
			string _Time_FUN = "";
			string _Time_BYO = "";

			string _OpenClose = "";

			_Flg  = "0";
			SetStringToCommand(PARAM_NAME_RIS_ID, orderData.RIS_ID, command);

			//-------------------------------
			// OrderCommentIDへの格納値編集
			//-------------------------------

			//★★★1.オープン検査/クローズ検査区分 ★★★★★★★★★
			_OpenClose = "";
			for (_BuiIdx  = 0; _BuiIdx < order.BUI_SUMM.Count; _BuiIdx++)
			{

				for (_CommentIdx = 0; _CommentIdx < order.BUI_SUMM[_BuiIdx].COMMENT_SUMM.Count; _CommentIdx++)
				{
					if (order.BUI_SUMM[_BuiIdx].COMMENT_SUMM[_CommentIdx].COMMENT_KBN.TrimData == "10")
					{
						_ComName = order.BUI_SUMM[_BuiIdx].COMMENT_SUMM[_CommentIdx].COMMENT_CODE.TrimData;
						_NameStr = GetOpenCloseInspection(_ComName);
						if (_OpenClose != "")
						{
							_OpenClose = _OpenClose + ", ";
						}
						_OpenClose = _OpenClose + "【検査区分】 " + _NameStr;
					}
				}
			}

			if (_OpenClose != "")   //修飾情報と部位フリーコメントの間に改行を挿入
			{
				_OpenClose = _OpenClose + "|";
			}

			//★★★2.検査前投薬★★★★★★★★★
			GetPartsString(order, ref _PartsStr);
			if (_PartsStr != "")
			{
				_PartsStr = "【検査前投薬】|" + _PartsStr + "||";
			}

			_PartsStr = _OpenClose + _PartsStr; //OpenCloseが先頭。GetPartsStringがあれなのでこのようにした

			//★★★3.シェーマ画像の有無★★★★★
			for (_BuiIdx  = 0; _BuiIdx < order.BUI_SUMM.Count; _BuiIdx++)
			{
				if (order.BUI_SUMM[_BuiIdx].BUI1_C.TrimData != "" ||
					order.BUI_SUMM[_BuiIdx].BUI2_C.TrimData != "" ||
					order.BUI_SUMM[_BuiIdx].BUI3_C.TrimData != "")
				{
					_Flg = "1";
				}
			}

			if (_Flg == "1")
			{
				_PartsStr = _PartsStr + "【オーダシェーマ】 あり||";
			}

			//★★★4.ＲＩの日渡り検査日★★★★★★★★★★★
			if (order.XX_KBN.TrimData == XX_KBN_RI)
			{

				for (_YKIdx = 0; _YKIdx < order.YK_SUMM.Count; _YKIdx++)
				{
					if (order.YK_SUMM.Count > 1)
					{
						if (_YKIdx > 0)
						{
							if (_YKIdx > 1)
							{
								_DateTime = _DateTime + "\r\n";
							}

							_DateYYYY = StringUtils.Mid(order.YK_SUMM[_YKIdx].YK_DATE.TrimData, 1, 4);
							_DateMM = StringUtils.Mid(order.YK_SUMM[_YKIdx].YK_DATE.TrimData, 5, 2);
							_DateDD = StringUtils.Mid(order.YK_SUMM[_YKIdx].YK_DATE.TrimData, 7, 2);
							_Time_JI = StringUtils.Mid(order.YK_SUMM[_YKIdx].YK_TIME.TrimData,1, 2);
							_Time_FUN = StringUtils.Mid(order.YK_SUMM[_YKIdx].YK_TIME.TrimData, 3, 2);
							_Time_BYO = StringUtils.Mid(order.YK_SUMM[_YKIdx].YK_TIME.TrimData, 5, 2);
							_DateTime = _DateTime + "【第" + _YKIdx.ToString() + "回検査開始日時】";
							_DateTime = _DateTime + "　" + _DateYYYY + "/" + _DateMM + "/" + _DateDD;
							_DateTime = _DateTime + "　" + _Time_JI + ":" + _Time_FUN + ":" + _Time_BYO;
						}
					}
				}
			}

			if (_DateTime != "")
			{
				_PartsStr = _PartsStr + _DateTime + "||";
			}

			//★★★5.RIの場合の機能検査★★★★★★★★
			if (order.XX_KBN.TrimData == XX_KBN_RI)
			{
				for (_CommentIdx = 0; _CommentIdx < order.BUI_SUMM[0].COMMENT_SUMM.Count; _CommentIdx++)
				{
					if (order.BUI_SUMM[0].COMMENT_SUMM[_CommentIdx].COMMENT_KBN.TrimData == "02")
					{
						_IDStr = "02" + order.BUI_SUMM[0].COMMENT_SUMM[_CommentIdx].COMMENT_CODE.TrimData;
						_NameStr = GetInfuseName(_IDStr);
						if (_InfuseStr != "")
						{
							_InfuseStr = _InfuseStr + "|";
						}
						_InfuseStr = _InfuseStr + " " + _NameStr;
					}
				}
			}


			if (_InfuseStr != "")
			{
				//_InfuseStr = "【機能検査】|" + _InfuseStr + "||";
				_InfuseStr = "【機能検査】" + _InfuseStr + "||";
			}

			if (_KensaStr != "")
			{
				_KensaStr = "【撮影部位】|" + _KensaStr + "||";
			}

			_PartsStr = _PartsStr + _InfuseStr + _KensaStr;

			//★★★6.部位コメント★★★★★★★★★★★★★★★
			//放射線検査の場合
			for (_BuiIdx  = 0; _BuiIdx <order.BUI_SUMM.Count; _BuiIdx++)
			{
				_BUiComStr = "";
				for (_CommentIdx = 0; _CommentIdx < order.BUI_SUMM[_BuiIdx].COMMENT_SUMM.Count; _CommentIdx++)
				{
					if (order.BUI_SUMM[_BuiIdx].COMMENT_SUMM[_CommentIdx].COMMENT_KBN.TrimData == "34")
					{
						_ComName = "34" + order.BUI_SUMM[_BuiIdx].COMMENT_SUMM[_CommentIdx].COMMENT_CODE.TrimData;
						_NameStr = GetCommentName(_ComName);
						if (_BUiComStr != "")
						{
							_BUiComStr = _BUiComStr + ", ";
						}

						_BUiComStr = _BUiComStr + _NameStr;
					}
				}

				//RI検査の場合
				_KinouKensaStr = "";
				for (_CommentIdx  = 0; _CommentIdx < order.BUI_SUMM[_BuiIdx].COMMENT_SUMM.Count; _CommentIdx++)
				{
					if (order.BUI_SUMM[_BuiIdx].COMMENT_SUMM[_CommentIdx].COMMENT_KBN.TrimData == "02")
					{
						_InfuseName = "02" + order.BUI_SUMM[_BuiIdx].COMMENT_SUMM[_CommentIdx].COMMENT_CODE.TrimData;
						_NameStr = GetInfuseName(_ComName);
						if (_BUiComStr != "")
						{
							_KinouKensaStr = _BUiComStr + "|";
						}
						_KinouKensaStr = _BUiComStr + _NameStr;
					}
				}

				if (_KinouKensaStr != "")
				{
					//_PartsStr = _PartsStr + "【機能検査】|" + _KinouKensaStr + "|";
					_PartsStr = _PartsStr + "【機能検査】" + _KinouKensaStr + "|";
				}

				for (_CommentIdx = 0; _CommentIdx < order.BUI_SUMM[_BuiIdx].COMMENT_SUMM.Count; _CommentIdx++)
				{
					if (order.BUI_SUMM[_BuiIdx].COMMENT_SUMM[_CommentIdx].COMMENT_KBN.TrimData == "07")
					{
						_ComName = "07" + order.BUI_SUMM[_BuiIdx].COMMENT_SUMM[_CommentIdx].COMMENT_CODE.TrimData;
						_NameStr = GetCommentName(_ComName);
						if (_BUiComStr != "")
						{
							_BUiComStr = _BUiComStr + ", ";
						}
						_BUiComStr = _BUiComStr + _NameStr;
					}
				}


				if (_BUiComStr != "")   //修飾情報と部位フリーコメントの間に改行を挿入
				{
					_BUiComStr = _BUiComStr + "|";
				}

				//部位フリーコメント
				if (order.BUI_SUMM[_BuiIdx].FREE_C.TrimData != "")
				{
					if (order.KNS_SYBT1.TrimData == "05")
					{
						_BUiFreeComStr = order.BUI_SUMM[_BuiIdx].FREE_C.TrimData + "|";
					}
					else
					{
						_BUiFreeComStr = " " + order.BUI_SUMM[_BuiIdx].FREE_C.TrimData + "|";
					}
				}

				if (order.KNS_SYBT1.TrimData == "05")
				{
					_ComStr = _ComStr + _BUiComStr + _BUiFreeComStr;
				}
				else
				{
					if (_BUiComStr == "")
					{
						_ComStr = _ComStr + _BUiComStr + _BUiFreeComStr;
					}
					else
					{
						_ComStr = _ComStr + " " + _BUiComStr + _BUiFreeComStr;
					}
				}
			}


			if (_ComStr != "")
			{
				//_PartsStr  = _PartsStr + "【部位コメント】|" + _ComStr + "|";
				//_PartsStr = _PartsStr + _ComStr + "|";
				_PartsStr  = _PartsStr + "【部位コメント】" + _ComStr + "|";
			}

			SetStringToCommand(PARAM_NAME_ORDERCOMMENT_ID, _PartsStr, command);
			SetStringToCommand(PARAM_NAME_KENSA_SIJI, order.KNS_PURPOSE.TrimData, command);
			SetStringToCommand(PARAM_NAME_RINSYOU, order.IRAI_BYOMEI.TrimData, command);
			SetStringToCommand(PARAM_NAME_REMARKS, GetREMARKS(order), command);
		}

		//---------------------------------------------------
		//オープン検査/クローズ検査区分取得
		//pCOMMENT_CODE: string; コメントコード
		//Result: string; ORDERINDICATETABLE.ORDERCOMMENT_IDへ付加するする値
		//---------------------------------------------------
		public string GetOpenCloseInspection(string pCOMMENT_CODE)
		{
			string Result = "";
			if (pCOMMENT_CODE == "001")
			{
				//Result = "オープン検査";
				Result = "オープン";
				return Result;
			}
			if (pCOMMENT_CODE == "002")
			{
				//Result = "クローズ検査";
				Result = "クローズ";
				return Result;
			}
			return Result;
		}


		//------------------------------------------------------------------------------
		//造影剤、薬品、材料を取得(GetPartsString)
		//------------------------------------------------------------------------------
		public void GetPartsString(HISRISOrderInfoAggregate order, ref string PartsStr)
		{
			int PartsIdx;
			string _partsTanniID;

			PartsStr = "";
			_partsTanniID = "";

			for (PartsIdx  = 0; PartsIdx < order.YKH_SUMM.Count; PartsIdx++)
			{
				if (PartsIdx > 0)
				{
					PartsStr = PartsStr + "|";
				}

				PartsStr = PartsStr + " " +  order.YKH_SUMM[PartsIdx].YKH_HYOUJI_1.TrimData;
				if (PartsStr == "")
				{
					PartsStr = PartsStr + order.YKH_SUMM[PartsIdx].YOURYO.TrimData;
				}
				else
				{
					PartsStr = PartsStr + " " + order.YKH_SUMM[PartsIdx].YOURYO.TrimData;
				}
				PartsStr = PartsStr + order.YKH_SUMM[PartsIdx].DSP_TANI.TrimData;
			}
		}


		//------------------------------------------------------------------------------
		//GetInfuseName(InfuseName取得)
		//------------------------------------------------------------------------------
		public string GetInfuseName(string pInfuseID)
		{
			string SQL_GET_INFUSE_NAME = "select INFUSE_NAME from INFUSEMASTER where INFUSE_ID = :INFUSE_ID";

			DataTable _Results = new DataTable();

			string Result  = "";

			try
			{
				//TDBMgr.GetDBMgr.OpenSQL(Format(SQL_GET_INFUSE_NAME, [SingleQuote(pInfuseID)]), nil, _Results);
				using (IDbCommand command = connection.CreateCommand())
				{
					command.InitCommandODP(ConfigurationManager.AppSettings["CommandTimeout"].StringToInt32());
					command.CommandText = SQL_GET_INFUSE_NAME;

					IDataParameter param = command.CreateParameter();
					param.SetInputString(PARAM_NAME_INFUSE_ID, pInfuseID);
					command.Parameters.Add(param);

					MiscUtils.WriteDbCommandLogForLog4net(command, _log);

					IDataReader reader = command.ExecuteReader();
					try
					{
						_Results.Load(reader);
						if (_Results.Rows.Count == 0)
						{
							//throw new DataNotFoundException(string.Format(
							//	"データが見つかりませんでした。INFUSE_ID={0}", pInfuseID));
						}

						//MiscUtils.WriteDataReaderLogForLog4net(reader, _log);

					}
					finally
					{
						reader.Close();
					}
				}

				if (_Results.Rows.Count == 0)
				{
					_log.Error("INFUSEMASTERに対象レコードなし：INFUSE_ID=" + pInfuseID);
					return Result;
				}

				Result = _Results.Rows[0][0].ToString();
			}
			finally
			{
				_Results = null;
			}
			return Result;
		}


		//------------------------------------------------------------------------------
		//GetCommentName(コメント名取得)
		//------------------------------------------------------------------------------
		public string GetCommentName(string pCommentID)
		{
			string SQL_GET_COMMENT_NAME = "select COMMENT_NAME from PREDEFINEDCOMMENTMASTER where COMMENT_ID = :COMMENT_ID";
			DataTable _Results = new DataTable();

			string Result  = "";
			try
			{
				using (IDbCommand command = connection.CreateCommand())
				{
					command.InitCommandODP(ConfigurationManager.AppSettings["CommandTimeout"].StringToInt32());
					command.CommandText = SQL_GET_COMMENT_NAME;

					IDataParameter param = command.CreateParameter();
					param.SetInputString(PARAM_NAME_COMMENT_ID, pCommentID);
					command.Parameters.Add(param);

					MiscUtils.WriteDbCommandLogForLog4net(command, _log);

					IDataReader reader = command.ExecuteReader();
					try
					{
						_Results.Load(reader);
						if (_Results.Rows.Count == 0)
						{
							//throw new DataNotFoundException(string.Format(
							//	"データが見つかりませんでした。COMMENT_ID={0}", pCommentID));
						}

						//MiscUtils.WriteDataReaderLogForLog4net(reader, _log);

					}
					finally
					{
						reader.Close();
					}
				}

				if (_Results.Rows.Count == 0)
				{
					_log.Error("PREDEFINEDCOMMENTMASTERに対象レコードなし：Comment_ID=" + pCommentID);
					return Result;;
				}

				Result = _Results.Rows[0][0].ToString();
			}
			finally
			{
				_Results = null;
			}
			return Result;
		}


		//---------------------------------------------------
		//OrderIndicate.Remarksに設定する値を取得する
		//pOrderInfo: TH2ROrderRoot; 取得元データ
		//Result: string; OrderIndicate.Remarksに設定する値
		//---------------------------------------------------
		public string GetREMARKS(HISRISOrderInfoAggregate pOrderInfo)
		{
			string _tmpResult;

			string Result  = "";

			// 2020.09.11 del start cosmo@taira
			//if (pOrderInfo.KEKKA2.Data != "") //血糖値(値)血糖値(検査日)
			//{
			//	if (Result!= "")
			//	{
			//		Result = Result  + "\r\n";
			//	}

			//	//Result = Result + fom_DownstreamMain.ExamDataHelper.Values["KEKKA2"];
			//	Result = Result + ConfigurationManager.AppSettings[PARAM_NAME_REMARKS + "_" + pOrderInfo.KEKKA2.TrimData].StringToString();
			//	Result = Result + " ";
			//	Result = Result + pOrderInfo.KEKKA2.TrimData + "mg/dl";
			//	Result = Result + " ";
			//	Result = Result + pOrderInfo.KEKKA2_DATE.TrimData;
			//}
			// 2020.09.11 del start cosmo@taira

			if (pOrderInfo.ODR_COMMENT.TrimData != "") //補足コメント
			{
				if (Result != "")
				{
					Result = Result  + "\r\n";
				}
			}
			_tmpResult = Regex.Replace(pOrderInfo.ODR_COMMENT.TrimData, " ", "", RegexOptions.IgnoreCase);
			Result = Result + Regex.Replace(_tmpResult.TrimEnd(), ",", "\r\n", RegexOptions.IgnoreCase);
			Result = RemoveDust(StringUtils.Mid(Result, 1, 1024));
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
			if (!string.IsNullOrEmpty(pSrc))
			{
				if (isZenkaku(Result.Substring(Result.Length - 1, 1)))
				{
					Result = Result.Substring(0, Result.Length - 1);
				}

			}
			return Result;
		}

		public static bool isZenkaku(string str)
		{
			int num = Encoding.GetEncoding("Shift_JIS").GetByteCount(str);
			return num == str.Length * 2;
		}
	}
}
