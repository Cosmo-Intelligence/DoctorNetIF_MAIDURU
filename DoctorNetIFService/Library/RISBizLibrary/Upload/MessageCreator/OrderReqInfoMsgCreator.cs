using System;
using System.Collections.Generic;
using System.Data;
using RISBizLibrary.Data;
using RISBizLibrary.Upload.Data;
using RISCommonLibrary.Lib.Msg;
using RISCommonLibrary.Lib.Msg.Common.OrderRequestInfo;
using RISCommonLibrary.Lib.Msg.OrderRequestInfo;
using RISCommonLibrary.Lib.Utils;

namespace RISBizLibrary.Upload.MessageCreator
{
	internal class OrderReqInfoMsgCreator : BaseMsgCreator
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
				return "依頼再送要求";
			}
		}

		#endregion

		#region constractor

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public OrderReqInfoMsgCreator()
			: base()
		{
		}
		#endregion

		#region IMessageCreator メンバ

		public override string[] GetRequestTypes()
		{
			return new[]
			{
				RQRISDBConst.REQUEST_TYPE_ORDER_REQUEST
			};
		}

		public override BaseMsg CreateMsg(ToHisInfo toHisInfo, IDbConnection cnRis, string pRISID, string pSyoriKbn)
		{
			_log.Info("依頼再送要求情報を取得します");

			HISRISOrderRequestMsg ret_Msg = new HISRISOrderRequestMsg();
			HISRISOrderRequestInfoAggregate _Msg = ret_Msg.MsgBody.OrderRequestInfoRIS;
			DateTime _SakuseiDate;
			DateTime _SyoriDate;
			List<string> _Message2;

			//ヘッダー情報
			_Msg.DENBUN_SYBT.Data  = MsgConst.DENBUN_SYBT_REQUEST_RIS;
			_SakuseiDate = DateTime.Now;
			_Msg.SAKUSEI_DATE.Data  = _SakuseiDate.ToString("yyyyMMdd");
			_Msg.SAKUSEI_TIME.Data  = _SakuseiDate.ToString("hhmmss");
			_Msg.S_SYS_CD.Data  = ret_Msg.SrcSysCode;
			_Msg.R_SYS_CD.Data  = ret_Msg.DstSysCode;
			_Msg.HEADER_CNT.Data  = "00000001";
			_Msg.SYORI_KBN.Data  = MsgConst.SYORI_KBN_NEW;

			if (DateTime.TryParse(toHisInfo.RequestDate, out _SyoriDate))
			{
				_Msg.SYORI_DATE.Data = _SyoriDate.ToString("yyyyMMdd");
				_Msg.SYORI_TIME.Data = _SyoriDate.ToString("hhmmss");
			}

			_Message2 = new List<string>();
			try
			{
				_Message2.Add(toHisInfo.MessageID2);

				_log.Info("MESSAGEID2の文字数：" + _Message2[0].Length);

				if (StringUtils.Mid(_Message2[0], 11, 1) == ",")
				{
					// 2020.09.16 mod start cosmo@nishihara 検査種別を３桁に変更
					switch (_Message2[0].Length)
					{
						case 15: //パターン１
							_log.Info("MESSAGEID2が16桁の場合の処理を開始します。(パターン1)");
							_Msg.PT_ID.Data    = StringUtils.Mid(_Message2[0], 1, 10);
							_Msg.XX_KBN.Data = StringUtils.Mid(_Message2[0], 12, 2);
							_Msg.XX_SYBT.Data  = "";
							_Msg.YK_DATE.Data  = "";
							_Msg.FILLER.Data   = "";
							_log.Info("MESSAGEID2が16桁の場合の処理が完了しました。(パターン1)");
							break;
						case 23: //パターン２
							_log.Info("MESSAGEID2が24桁の場合の処理を開始します。(パターン2)");
							_Msg.PT_ID.Data    = StringUtils.Mid(_Message2[0], 1, 10);
							_Msg.XX_KBN.Data   = StringUtils.Mid(_Message2[0], 12, 2);
							_Msg.XX_SYBT.Data  = "";
							_Msg.YK_DATE.Data  = StringUtils.Mid(_Message2[0], 16, 8);
							_Msg.FILLER.Data   = "";
							_log.Info("MESSAGEID2が24桁の場合の処理が完了しました。(パターン2)");
							break;
						//case 17: //パターン３
						case 18: //パターン３
							_log.Info("MESSAGEID2が18桁の場合の処理を開始します。(パターン3)");
							_Msg.PT_ID.Data    = StringUtils.Mid(_Message2[0], 1, 10);
							_Msg.XX_KBN.Data   = StringUtils.Mid(_Message2[0], 12, 2);
							//_Msg.XX_SYBT.Data  = StringUtils.Mid(_Message2[0], 15, 2);
							_Msg.XX_SYBT.Data = StringUtils.Mid(_Message2[0], 15, 3);
							_Msg.YK_DATE.Data  = "";
							_Msg.FILLER.Data   = "";
							_log.Info("MESSAGEID2が18桁の場合の処理が完了しました。(パターン3)");
							break;
						//case 25: //パターン４
						case 26: //パターン４
							_log.Info("MESSAGEID2が26桁の場合の処理を開始します。(パターン4)");
							_Msg.PT_ID.Data    = StringUtils.Mid(_Message2[0], 1, 10);
							_Msg.XX_KBN.Data   = StringUtils.Mid(_Message2[0], 12, 2);
							//_Msg.XX_SYBT.Data  = StringUtils.Mid(_Message2[0], 15, 2);
							//_Msg.YK_DATE.Data  = StringUtils.Mid(_Message2[0], 18, 8);
							_Msg.XX_SYBT.Data = StringUtils.Mid(_Message2[0], 15, 3);
							_Msg.YK_DATE.Data = StringUtils.Mid(_Message2[0], 19, 8);
							_Msg.FILLER.Data   = "";
							_log.Info("MESSAGEID2が26桁の場合の処理が完了しました。(パターン4)");
							break;
					}
				}
				else
				{
					switch (_Message2[0].Length)
					{
						// 2020.07.16 mod start cosmo@nishihara caseの文字数修正
						//case 15: //パターン５
						case 13: //パターン５
								 // 2020.07.16 mod end cosmo@nishihara caseの文字数修正
							_log.Info("MESSAGEID2が14桁の場合の処理を開始します。(パターン5)");
							_Msg.PT_ID.Data    = "";
							_Msg.XX_KBN.Data   = StringUtils.Mid(_Message2[0], 2, 2);
							_Msg.XX_SYBT.Data  = "";
							_Msg.YK_DATE.Data  = StringUtils.Mid(_Message2[0], 6, 8);
							_Msg.FILLER.Data   = "";
							_log.Info("MESSAGEID2が14桁の場合の処理が完了しました。(パターン5)");
							break;

						// 2020.07.16 mod start cosmo@nishihara caseの文字数、予約日取得位置修正
						//case 18: //パターン６
						case 16: //パターン６
							_log.Info("MESSAGEID2が16桁の場合の処理を開始します。(パターン6)");
							_Msg.PT_ID.Data    = "";
							_Msg.XX_KBN.Data   = StringUtils.Mid(_Message2[0], 2, 2);
							//_Msg.XX_SYBT.Data  = StringUtils.Mid(_Message2[0], 5, 2);
							//_Msg.YK_DATE.Data  = StringUtils.Mid(_Message2[0], 9, 8);
							_Msg.XX_SYBT.Data = StringUtils.Mid(_Message2[0], 5, 3);
							_Msg.YK_DATE.Data = StringUtils.Mid(_Message2[0], 9, 8);
							_Msg.FILLER.Data   = "";
							_log.Info("MESSAGEID2が16桁の場合の処理が完了しました。(パターン6)");
							break;
							// 2020.07.16 mod end cosmo@nishihara caseの文字数、予約日取得位置修正
					}
					// 2020.09.16 mod end cosmo@nishihara 検査区分を３桁に変更
				}
			}
			finally
			{
				_Message2 = null;
			}
			return ret_Msg;

		}

		public override BaseMsgData CreateMsgData()
		{
			return new ReceiptMsgData();
		}
		#endregion
	}
}
