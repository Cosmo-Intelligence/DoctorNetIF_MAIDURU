using System;
using System.Configuration;
using System.Data;
using RISBizLibrary.Data;
using RISBizLibrary.Upload.Data;
using RISCommonLibrary.Lib.Exceptions;
using RISCommonLibrary.Lib.Msg;
using RISCommonLibrary.Lib.Msg.Common.ReceiptInfo;
using RISCommonLibrary.Lib.Msg.ReceiptInfo;
using RISCommonLibrary.Lib.Utils;
using RISODPLibrary.Lib.Utils;

namespace RISBizLibrary.Upload.MessageCreator
{
	internal class ReceiptInfoMsgCreator : BaseMsgCreator
	{
		#region const

		private const string JIGO_KBN_NORMAL = "0"; //通常入力

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
				return "受付情報メッセージ作成";
			}
		}

		#endregion

		#region constractor

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public ReceiptInfoMsgCreator()
			: base()
		{
		}
		#endregion

		#region IMessageCreator メンバ

		public override string[] GetRequestTypes()
		{
			return new[]
			{
				RQRISDBConst.REQUEST_TYPE_RECEIPT,
				RQRISDBConst.REQUEST_TYPE_RECEIPT_CANCEL
			};
		}

		public override BaseMsg CreateMsg(ToHisInfo toHisInfo, IDbConnection cnRis, string pRISID, string pSyoriKbn)
		{
			_log.Info("受付情報を取得します");

			HISRISReceiptInfoMsg ret_Msg = new HISRISReceiptInfoMsg();
			HISRISReceiptInfoAggregate _Msg = ret_Msg.MsgBody.ReceiptInfoRIS;

			DataTable _OrderResult = new DataTable();
			DataTable _ExtendResult = new DataTable();
			DataTable _ExMainResult = new DataTable();
			TOrderMainTable _Order = new TOrderMainTable();
			TExtendOrderInfo _Extend = new TExtendOrderInfo();
			TExMainTable _ExMain = new TExMainTable();
			DataRow _OrderRecord;
			DataRow _ExtendRecord;
			DataRow _ExMainRecord;

			string _SQL, _SQL2, _SQL3;

			//Result := nil;
			//_OrderResult = TRecordList.Create;
			//_ExtendResult = TRecordList.Create;
			//_ExMainResult = TRecordList.Create;
			//_Order = TOrderMainTable.Create;
			//_Extend = TExtendOrderInfo.Create;
			//_ExMain = TExMainTable.Create;

			try
			{
				_SQL = "";
				// 2020.08.28 Mod H.Taira@COSMO Start
				//_SQL = _SQL + "select RIS_ID, ORDERNO, KENSATYPE_ID, KANJA_ID from ORDERMAINTABLE ";
				//_SQL = _SQL + "where RIS_ID = '" + toHisInfo.RIS_ID + "'";

				_SQL = _SQL + " SELECT ";
				_SQL = _SQL + "  OM.RIS_ID, ";
				_SQL = _SQL + "  OM.ORDERNO, ";
				_SQL = _SQL + "  OM.KENSATYPE_ID, ";
				_SQL = _SQL + "  OM.KANJA_ID, ";
				_SQL = _SQL + "  EO.ADDENDUM01, ";
				_SQL = _SQL + "  EO.ADDENDUM02, ";
				_SQL = _SQL + "  EO.ADDENDUM03, ";
				_SQL = _SQL + "  EO.ADDENDUM04, ";
				_SQL = _SQL + "  EO.ADDENDUM05, ";
				_SQL = _SQL + "  EO.ADDENDUM06, ";
				_SQL = _SQL + "  EO.ADDENDUM07 ";
				_SQL = _SQL + " FROM ";
				_SQL = _SQL + "  ORDERMAINTABLE OM ";
				_SQL = _SQL + " INNER JOIN ";
				_SQL = _SQL + "  EXTENDORDERINFO EO ";
				_SQL = _SQL + " ON ";
				_SQL = _SQL + "  OM.RIS_ID = EO.RIS_ID ";
				_SQL = _SQL + " WHERE ";
				_SQL = _SQL + "  OM.RIS_ID = '" + toHisInfo.RIS_ID + "'";
				// 2020.08.28 Mod H.Taira@COSMO End

				//TDBMgr.GetDBMgr.OpenSQL(_SQL, nil, _OrderResult);
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
						_OrderResult.Load(reader);
						if (_OrderResult.Rows.Count == 0)
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

				_SQL2 = "";
				_SQL2 = _SQL2 + "select ";
				_SQL2 = _SQL2 +    "RIS_ID, ADDENDUM01, ";
				_SQL2 = _SQL2 +    "ADDENDUM02, ADDENDUM03, ";
				_SQL2 = _SQL2 +    "ADDENDUM04, ADDENDUM05, ";
				_SQL2 = _SQL2 +    "ADDENDUM06, ADDENDUM07 ";
				_SQL2 = _SQL2 + "from ";
				_SQL2 = _SQL2 +    "EXTENDORDERINFO ";
				_SQL2 = _SQL2 + "where ";
				_SQL2 = _SQL2 +    "RIS_ID = '" + toHisInfo.RIS_ID + "'";
				//TDBMgr.GetDBMgr.OpenSQL(_SQL2, nil, _ExtendResult);
				using (IDbCommand command = cnRis.CreateCommand())
				{
					command.InitCommandODP(ConfigurationManager.AppSettings["CommandTimeout"].StringToInt32());
					// 2020.08.28 Mod H.Taira@COSMO Start
					//command.CommandText = _SQL;
					command.CommandText = _SQL2;
					// 2020.08.28 Mod H.Taira@COSMO End

					//IDataParameter param = command.CreateParameter();
					//param.SetInputString(PARAM_RIS_ID, toHisInfo.RIS_ID);
					//command.Parameters.Add(param);

					MiscUtils.WriteDbCommandLogForLog4net(command, _log);

					IDataReader reader = command.ExecuteReader();
					try
					{
						_ExtendResult.Load(reader);
						if (_ExtendResult.Rows.Count == 0)
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

				_SQL3 = "";
				_SQL3 = _SQL3 + "select ";
				_SQL3 = _SQL3 +     "RECEIPTDATE ";
				_SQL3 = _SQL3 + "from ";
				_SQL3 = _SQL3 +     "EXMAINTABLE ";
				_SQL3 = _SQL3 + "where ";
				_SQL3 = _SQL3 +     "RIS_ID = '" + toHisInfo.RIS_ID + "'";
				//TDBMgr.GetDBMgr.OpenSQL(_SQL3, nil, _ExMainResult);
				using (IDbCommand command = cnRis.CreateCommand())
				{
					command.InitCommandODP(ConfigurationManager.AppSettings["CommandTimeout"].StringToInt32());
					// 2020.08.28 Mod H.Taira@COSMO Start
					//command.CommandText = _SQL;
					command.CommandText = _SQL3;
					// 2020.08.28 Mod H.Taira@COSMO End

					//IDataParameter param = command.CreateParameter();
					//param.SetInputString(PARAM_RIS_ID, toHisInfo.RIS_ID);
					//command.Parameters.Add(param);

					MiscUtils.WriteDbCommandLogForLog4net(command, _log);

					IDataReader reader = command.ExecuteReader();
					try
					{
						_ExMainResult.Load(reader);
						if (_ExMainResult.Rows.Count == 0)
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


				//該当オーダが見つからなければ抜ける
				if (_OrderResult.Rows.Count == 0 || _ExtendResult.Rows.Count == 0 || _ExMainResult.Rows.Count == 0)
				{
					return ret_Msg;
				}

				_OrderRecord = _OrderResult.Rows[0];
				_Order.OrderNo       = StringUtils.Mid(_OrderRecord["ORDERNO"].ToString(), 1, 16);
				_Order.KensaType_ID  = StringUtils.Mid(_OrderRecord["KENSATYPE_ID"].ToString(), 1, 2);
				_Order.Kanja_ID      = StringUtils.Mid(_OrderRecord["KANJA_ID"].ToString(), 1, 10);

				_ExtendRecord = _ExtendResult.Rows[0];
				_Extend.ADDENDUM01  = StringUtils.Mid(_ExtendRecord["ADDENDUM01"].ToString(), 1, 8);
				_Extend.ADDENDUM02  = StringUtils.Mid(_ExtendRecord["ADDENDUM02"].ToString(), 1, 6);
				_Extend.ADDENDUM03  = StringUtils.Mid(_ExtendRecord["ADDENDUM03"].ToString(), 1, 4);
				_Extend.ADDENDUM04  = StringUtils.Mid(_ExtendRecord["ADDENDUM04"].ToString(), 1, 1);
				_Extend.ADDENDUM05  = StringUtils.Mid(_ExtendRecord["ADDENDUM05"].ToString(), 1, 2);
				_Extend.ADDENDUM06  = StringUtils.Mid(_ExtendRecord["ADDENDUM06"].ToString(), 1, 3);
				_Extend.ADDENDUM07  = StringUtils.Mid(_ExtendRecord["ADDENDUM07"].ToString(), 1, 5);

				_ExMainRecord = _ExMainResult.Rows[0];
				_ExMain.ReceiptDate  = StringUtils.Mid(_ExMainRecord["RECEIPTDATE"].ToString(), 1, 4) +
										StringUtils.Mid(_ExMainRecord["RECEIPTDATE"].ToString(), 6, 2) +
										StringUtils.Mid(_ExMainRecord["RECEIPTDATE"].ToString(), 9, 2);

				ret_Msg = InternalCreateMsg(toHisInfo, _Order, _Extend, _ExMain);
			}
			finally
			{
				_Order = null;
				_Extend = null;
				_ExMain = null;
				_OrderResult = null;
				_ExtendResult = null;
				_ExMainResult = null;
			}
			return ret_Msg;

		}

		/// <summary>
		/// メッセージを作成する
		/// </summary>
		/// <param name="toHisInfo"></param>
		/// <param name="pOrder"></param>
		/// <param name="pExtend"></param>
		/// <param name="pExMain"></param>
		/// <returns></returns>
		public HISRISReceiptInfoMsg InternalCreateMsg(ToHisInfo toHisInfo, TOrderMainTable pOrder,
			TExtendOrderInfo pExtend, TExMainTable pExMain)
		{
			HISRISReceiptInfoMsg ret_Msg = new HISRISReceiptInfoMsg();
			HISRISReceiptInfoAggregate _Msg = ret_Msg.MsgBody.ReceiptInfoRIS;
			string _RequestKind;
			DateTime _SakuseiDate;
			DateTime _SyoriDate;

			//Result  = TH2RReceiptMsg.Create;
			//_Msg = TH2RReceiptMsg(Result).MsgBody;

			//ヘッダー情報
			_RequestKind = toHisInfo.RequestType;

			//要求種別が受付の場合、電文種別＝受付
			if (_RequestKind == RQRISDBConst.REQUEST_TYPE_RECEIPT)
			{
				_Msg.DENBUN_SYBT.Data  = MsgConst.DENBUN_SYBT_RECEIPT_RIS;
			}
			//要求種別が受付キャンセルの場合、電文種別＝受付キャンセル
			else if (_RequestKind == RQRISDBConst.REQUEST_TYPE_RECEIPT_CANCEL)
			{
				_Msg.DENBUN_SYBT.Data  = MsgConst.DENBUN_SYBT_RECEIPT_CANCEL_RIS;
			}
			//共通ヘッダ
			_SakuseiDate = DateTime.Now;
			_Msg.SAKUSEI_DATE.Data  = _SakuseiDate.ToString("yyyyMMdd");
			_Msg.SAKUSEI_TIME.Data  = _SakuseiDate.ToString("hhmmss");
			_Msg.S_SYS_CD.Data  = ret_Msg.SrcSysCode;
			_Msg.R_SYS_CD.Data  = ret_Msg.DstSysCode;
			_Msg.HEADER_CNT.Data  = "00000001";

			if (_Msg.DENBUN_SYBT.Data == MsgConst.DENBUN_SYBT_RECEIPT_RIS)
			{
				_Msg.SYORI_KBN.Data  = MsgConst.SYORI_KBN_NEW;
			}
			else if (_Msg.DENBUN_SYBT.Data == MsgConst.DENBUN_SYBT_RECEIPT_CANCEL_RIS)
			{
				_Msg.SYORI_KBN.Data  = MsgConst.SYORI_KBN_CANCEL;
			}

			if (DateTime.TryParse(toHisInfo.RequestDate, out _SyoriDate))
			{
				_Msg.SYORI_DATE.Data  = _SyoriDate.ToString("yyyyMMdd");
				_Msg.SYORI_TIME.Data  = _SyoriDate.ToString("hhmmss");
			}

			//ＫＥＹ情報
			_Msg.PT_ID.Data        = pOrder.Kanja_ID;
			//受付情報
			_Msg.HASSEI_DATE.Data  = pExtend.ADDENDUM01;
			_Msg.SEQ_NO.Data       = pExtend.ADDENDUM02;
			_Msg.WS_NO.Data        = pExtend.ADDENDUM03;
			_Msg.INDEX_KBN.Data    = pExtend.ADDENDUM04;
			_Msg.XX_KBN.Data       = pExtend.ADDENDUM05;
			_Msg.XX_SYBT.Data      = pExtend.ADDENDUM06;
			_Msg.XX_SEQ.Data       = pExtend.ADDENDUM07;
			_Msg.ORDER_NO.Data     = pOrder.OrderNo;
			_Msg.FILLER.Data       = "      ";
			_Msg.PROC_SYBT.Data    = pOrder.KensaType_ID;

			if (_RequestKind == RQRISDBConst.REQUEST_TYPE_RECEIPT)
			{
				_Msg.YK_KJ_ST4.Data  = "0";
			}
			else if (_RequestKind == RQRISDBConst.REQUEST_TYPE_RECEIPT_CANCEL)
			{
				_Msg.YK_KJ_ST4.Data  = "9";
			}

			_Msg.CNCL_RSN.Data     = "  ";
			_Msg.YK_CR_DT.Data  = pExMain.ReceiptDate;
			_Msg.RESERVE.Data      = "               ";

			return ret_Msg;
		}

		public override BaseMsgData CreateMsgData()
		{
			return new ReceiptMsgData();
		}
		#endregion
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
		}
		public class TExMainTable
		{
			public string ReceiptDate;
		}
	}


}
