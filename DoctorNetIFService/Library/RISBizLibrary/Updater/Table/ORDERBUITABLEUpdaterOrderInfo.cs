using System;
using System.Configuration;
using System.Data;
using System.Text;
using RISBizLibrary.Data;
using RISBizLibrary.Download.Data;
using RISCommonLibrary.Lib.Exceptions;
using RISCommonLibrary.Lib.Msg.Common.OrderInfo;
using RISCommonLibrary.Lib.Utils;
using RISODPLibrary.Lib.Utils;

namespace RISBizLibrary.Updater.Table
{
	internal class ORDERBUITABLEUpdaterOrderInfo : BaseUpdater
	{
		#region const

		private const string XX_KBN_RI        = "17";
		private const string XX_KBN_RADIOLOGY        = "16";
		#region InsertSQL

		/// <summary>
		/// InsertSQL
		/// </summary>
		private const string INSERT_SQL =
		"MERGE INTO ORDERBUITABLE p " +
		"USING " +
		"( " +
			"SELECT " +
				":RIS_ID RIS_ID," +
				":NO NO," +
				":BUI_ID BUI_ID," +
				":ADDENDUM01 ADDENDUM01," +
				":ADDENDUM02 ADDENDUM02," +
				":ADDENDUM03 ADDENDUM03," +
				":ADDENDUM04 ADDENDUM04," +
				":HOUKOU_ID HOUKOU_ID," +
				":SAYUU_ID SAYUU_ID," +
				":BUICOMMENT BUICOMMENT," +
				":KENSAHOUHOU_ID KENSAHOUHOU_ID " +
			"FROM " +
				"DUAL " +
		") pn " +
		"ON " +
		//"( p.RIS_ID = pn.RIS_ID) " +
		"( p.RIS_ID = pn.RIS_ID and p.NO = pn.NO) " +
		//"WHEN MATCHED THEN " + //-- 既存レコードの更新
		//	"UPDATE SET " +
		//		"NO = pn.NO," +
		//		"BUI_ID = pn.BUI_ID," +
		//		"ADDENDUM01 = pn.ADDENDUM01," +
		//		"ADDENDUM02 = pn.ADDENDUM02," +
		//		"ADDENDUM03 = pn.ADDENDUM03," +
		//		"ADDENDUM04 = pn.ADDENDUM04," +
		//		"HOUKOU_ID = pn.HOUKOU_ID," +
		//		"SAYUU_ID = pn.SAYUU_ID," +
		//		"KENSAHOUHOU_ID = pn.KENSAHOUHOU_ID " +
		"WHEN NOT MATCHED THEN " + //新規レコードの作成
			"INSERT " +
			"( " +
				"RIS_ID, " +
				"NO, " +
				"BUI_ID, " +
				"ADDENDUM01, " +
				"ADDENDUM02, " +
				"ADDENDUM03, " +
				"ADDENDUM04, " +
				"HOUKOU_ID, " +
				"SAYUU_ID, " +
				"BUICOMMENT, " +
				"KENSAHOUHOU_ID " +
			") " +
			"VALUES " +
			"( " +
				"pn.RIS_ID, " +
				"pn.NO, " +
				"pn.BUI_ID, " +
				"pn.ADDENDUM01, " +
				"pn.ADDENDUM02, " +
				"pn.ADDENDUM03, " +
				"pn.ADDENDUM04, " +
				"pn.HOUKOU_ID, " +
				"pn.SAYUU_ID, " +
				"pn.BUICOMMENT, " +
				"pn.KENSAHOUHOU_ID " +
			") " +
			"";

		#endregion

		#region param
		/// <summary>
		/// RIS_ID
		/// </summary>
		private const string PARAM_NAME_RIS_ID = "RIS_ID";

		/// <summary>
		/// NO
		/// </summary>
		private const string PARAM_NAME_NO = "NO";

		/// <summary>
		/// BUI_ID
		/// </summary>
		private const string PARAM_NAME_BUI_ID = "BUI_ID";

		/// <summary>
		/// ADDENDUM01
		/// </summary>
		private const string PARAM_NAME_ADDENDUM01 = "ADDENDUM01";

		/// <summary>
		/// ADDENDUM02
		/// </summary>
		private const string PARAM_NAME_ADDENDUM02 = "ADDENDUM02";

		/// <summary>
		/// ADDENDUM03
		/// </summary>
		private const string PARAM_NAME_ADDENDUM03 = "ADDENDUM03";

		/// <summary>
		/// ADDENDUM04
		/// </summary>
		private const string PARAM_NAME_ADDENDUM04 = "ADDENDUM04";

		/// <summary>
		/// HOUKOU_ID
		/// </summary>
		private const string PARAM_NAME_HOUKOU_ID = "HOUKOU_ID";

		/// <summary>
		/// SAYUU_ID
		/// </summary>
		private const string PARAM_NAME_SAYUU_ID = "SAYUU_ID";

		/// <summary>
		/// BUICOMMENT
		/// </summary>
		private const string PARAM_NAME_BUICOMMENT = "BUICOMMENT";

		/// <summary>
		/// KENSAHOUHOU_ID
		/// </summary>
		private const string PARAM_NAME_KENSAHOUHOU_ID = "KENSAHOUHOU_ID";


		/// <summary>
		/// COMMENT_ID
		/// </summary>
		private const string PARAM_NAME_COMMENT_ID = "COMMENT_ID";

		#endregion

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

		/// <summary>
		/// SQL実行手続き
		/// </summary>
		/// <param name="data"></param>
		/// <param name="command"></param>
		public override void ExecuteAndSetParam(BaseMsgData data, IDbCommand command)
		{
			OrderInfoMsgData orderData = (OrderInfoMsgData)data;
			HISRISOrderInfoAggregate order = orderData.Request.MsgBody.OrderInfo;
			int fBuiNoCnt = 0;
			for (int _BUIIdx = 0; _BUIIdx < order.BUI_SUMM.Count; _BUIIdx++)
			{
				StringBuilder _ComList = new StringBuilder();
				string _ComKbn = "", _ComCode = "", _HouhouId = "", _BuiCmt = "", _SayuuId = "";
				//int _HoukouCnt, _idx, fBuiNoCnt = 0;
				int _HoukouCnt, _idx;
				string _BUiFreeComStr = "";

				_HoukouCnt = 0;
				try
				{
					for (_idx  = 0; _idx < order.BUI_SUMM[_BUIIdx].COMMENT_SUMM.Count; _idx++)
					{
						//コメント区分取得
						_ComKbn = order.BUI_SUMM[_BUIIdx].
														COMMENT_SUMM[_idx].COMMENT_KBN.TrimData;
						//コメントコード取得
						_ComCode = order.BUI_SUMM[_BUIIdx].
													 COMMENT_SUMM[_idx].COMMENT_CODE.TrimData;

						//放射線オーダ
						if (order.XX_KBN.TrimData == XX_KBN_RADIOLOGY)
						{
							if (_ComKbn == "32")
							{
								_HoukouCnt = _HoukouCnt + 1;
							}
							else if (_ComKbn == "33")
							{
								_HouhouId = _ComCode;
							}
							else if (_ComKbn == "34")
							{
								//部位フリーコメント
								if (order.BUI_SUMM[_BUIIdx].FREE_C.TrimData != "")
								{
									_BUiFreeComStr = " " + order.BUI_SUMM[_BUIIdx].FREE_C.TrimData;
								}

								//_ComList.Append(GetCommentName(_ComKbn + _ComCode) + " , ");
								_ComList.Append(GetCommentName(_ComKbn + _ComCode) + " , " + _BUiFreeComStr);

								string knsSybt = ConfigurationManager.AppSettings["SAYUU_CONVERT_KENSATYPE"].StringToString();
								string[] knsArr = knsSybt.Split(',');
								if (0 <= Array.IndexOf(knsArr, order.KNS_SYBT1.TrimData))
								{
									
									string connectCode = _ComKbn + _ComCode;
									string sayuuType1 = ConfigurationManager.AppSettings["SAYUUTYPE_1"].StringToString();
									string sayuuType2 = ConfigurationManager.AppSettings["SAYUUTYPE_2"].StringToString();
									string sayuuType3 = ConfigurationManager.AppSettings["SAYUUTYPE_3"].StringToString();
									string sayuuType4 = ConfigurationManager.AppSettings["SAYUUTYPE_4"].StringToString();
									string sayuuType5 = ConfigurationManager.AppSettings["SAYUUTYPE_5"].StringToString();
									string sayuuType6 = ConfigurationManager.AppSettings["SAYUUTYPE_6"].StringToString();

									if (connectCode == sayuuType1)
									{
										_SayuuId = ConfigurationManager.AppSettings["SAYUUTYPENMARK_1"].StringToString();
									}
									else if (connectCode == sayuuType2)
									{
										_SayuuId = ConfigurationManager.AppSettings["SAYUUTYPENMARK_2"].StringToString();
									}
									else if (connectCode == sayuuType3)
									{
										_SayuuId = ConfigurationManager.AppSettings["SAYUUTYPENMARK_3"].StringToString();
									}
									else if (connectCode == sayuuType4)
									{
										_SayuuId = ConfigurationManager.AppSettings["SAYUUTYPENMARK_4"].StringToString();
									}
									else if (connectCode == sayuuType5)
									{
										_SayuuId = ConfigurationManager.AppSettings["SAYUUTYPENMARK_5"].StringToString();
									}
									else if (connectCode == sayuuType6)
									{
										_SayuuId = ConfigurationManager.AppSettings["SAYUUTYPENMARK_6"].StringToString();
									}
									else
									{
										_SayuuId = "0";
									}
								}
							}
						}
						else
						{
						}
						//RIオーダ
						if (order.XX_KBN.TrimData == XX_KBN_RI)
						{
							if (_ComKbn == "04" ||_ComKbn == "07" || _ComKbn == "09")
							{
								_ComList.Append(GetCommentName(_ComKbn + _ComCode) + " , ");
							}
						}
					}

						if (!string.IsNullOrEmpty(_ComList.ToString()))
					{
						//最後のカンマを除去
						//_BuiCmt = _ComList.ToString().Substring(1, _ComList.ToString().Length -3);
						_BuiCmt = _ComList.ToString().Substring(0, _ComList.ToString().Length -2);
					}
				}
				finally
				{
					_ComList = null;
				}

				if (order.BUI_SUMM[_BUIIdx].COMMENT_SUMM.Count != 0 && _HoukouCnt > 0)
				{
					for (_idx  = 0; _idx < order.BUI_SUMM[_BUIIdx].COMMENT_SUMM.Count; _idx++)
					{
						if (order.BUI_SUMM[_BUIIdx].COMMENT_SUMM[_idx].COMMENT_KBN.TrimData == "32")
						{
							//SetOrderBuiParams(_HouhouId, _BuiCmt, _BUIIdx, 0, _idx, order, orderData, command, ref fBuiNoCnt);
							SetOrderBuiParams(_HouhouId, _BuiCmt, _BUIIdx, 0, _idx, order, orderData, command, ref fBuiNoCnt, _SayuuId);
							ExecuteSQLInner(command);
						}
					}
				}
				else
				{
					//SetOrderBuiParams(_HouhouId, _BuiCmt, _BUIIdx, 0, 0, order, orderData, command, ref fBuiNoCnt);
					SetOrderBuiParams(_HouhouId, _BuiCmt, _BUIIdx, 0, 0, order, orderData, command, ref fBuiNoCnt, _SayuuId);
					ExecuteSQLInner(command);
				}
			}
		}

		public void SetOrderBuiParams(string pHouhouId, string pBuiCmt, int pBuiIdx, int pOrderType, int pComIdx
			, HISRISOrderInfoAggregate order, OrderInfoMsgData orderData, IDbCommand command, ref int fBuiNoCnt
			, string _SayuuId)
		{
			command.Parameters.Clear();
			string _ComKbn = "", _ComCode = "", _HoukouId = "";

			SetStringToCommand(PARAM_NAME_RIS_ID, orderData.RIS_ID, command);
			fBuiNoCnt = fBuiNoCnt + 1;
			SetStringToCommand(PARAM_NAME_NO, fBuiNoCnt.ToString(), command);
			SetStringToCommand(PARAM_NAME_BUI_ID, StringUtils.Mid(order.BUI_SUMM[pBuiIdx].BUI_CD.TrimData, 1, 6), command);

			SetStringToCommand(PARAM_NAME_ADDENDUM01, order.BUI_SUMM[pBuiIdx].BUI_IMG_CD.TrimData, command);
			SetStringToCommand(PARAM_NAME_ADDENDUM02, order.BUI_SUMM[pBuiIdx].BUI1_C.TrimData, command);
			SetStringToCommand(PARAM_NAME_ADDENDUM03, order.BUI_SUMM[pBuiIdx].BUI2_C.TrimData, command);
			SetStringToCommand(PARAM_NAME_ADDENDUM04, order.BUI_SUMM[pBuiIdx].BUI3_C.TrimData, command);

			if (order.BUI_SUMM[pBuiIdx].COMMENT_SUMM.Count != 0)
			{
				//コメント区分取得
				_ComKbn = order.BUI_SUMM[pBuiIdx].COMMENT_SUMM[pComIdx].COMMENT_KBN.TrimData;

				if (_ComKbn == "32")
				{
					if (pOrderType == 0)
					{
						//コメントコード取得
						_ComCode = order.BUI_SUMM[pBuiIdx].COMMENT_SUMM[pComIdx].COMMENT_CODE.TrimData;
						_HoukouId = _ComCode;
					}
					else
					{
						_HoukouId = order.KNS_SYBT1.TrimData + "000";
					}
				}
				else
				{
					_HoukouId = order.KNS_SYBT1.TrimData + "000";
				}
			}
			else
			{
				_HoukouId = order.KNS_SYBT1.TrimData + "000";
			}

			SetStringToCommand(PARAM_NAME_HOUKOU_ID, _HoukouId, command);
			//SetStringToCommand(PARAM_NAME_SAYUU_ID, "0", command);
			SetStringToCommand(PARAM_NAME_SAYUU_ID, _SayuuId, command);
			SetStringToCommand(PARAM_NAME_BUICOMMENT, pBuiCmt, command);
			if (pHouhouId == "")
			{
				pHouhouId = order.KNS_SYBT1.TrimData + "000";
			}
			SetStringToCommand(PARAM_NAME_KENSAHOUHOU_ID, pHouhouId, command);
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
	}
}
