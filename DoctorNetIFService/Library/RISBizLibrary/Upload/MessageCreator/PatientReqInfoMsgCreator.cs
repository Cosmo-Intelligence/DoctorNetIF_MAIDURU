using System;
using System.Data;
using RISBizLibrary.Data;
using RISBizLibrary.Upload.Data;
using RISCommonLibrary.Lib.Msg;
using RISCommonLibrary.Lib.Msg.Common.PatientRequest;
using RISCommonLibrary.Lib.Msg.PatientRequest;
using RISCommonLibrary.Lib.Utils;

namespace RISBizLibrary.Upload.MessageCreator
{
	internal class PatientReqInfoMsgCreator : BaseMsgCreator
	{
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
				return "患者要求";
			}
		}

		#endregion

		#region constractor

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public PatientReqInfoMsgCreator()
			: base()
		{
		}
		#endregion

		#region method

		#region IMessageCreator メンバ

		public override string[] GetRequestTypes()
		{
			return new[]
			{
				RQRISDBConst.REQUEST_TYPE_PATIENT_REQUEST
			};
		}

		public override BaseMsg CreateMsg(ToHisInfo toHisInfo, IDbConnection cnRis, string pRISID, string pAllRisId)
		{
			_log.Info("患者要求情報を取得します");

			PatientRequestMsg msg = new PatientRequestMsg();
			PatientRequestAttributeAggregate p = msg.MsgBody.PatientRequestAttribute;

			#region ヘッダー情報部
			// 2020.08.28 Mod H.Taira@COSMO Start
			//p.DENBUN_SYBT.Data = MsgConst.DENBUN_SYBT_PATIENT_REQUEST;
			p.DENBUN_SYBT.Data = MsgConst.DENBUN_SYBT_REQUEST_PATIENT;
			// 2020.08.28 Mod H.Taira@COSMO End
			DateTime _SakuseiDate = DateTime.Now;
			p.SAKUSEI_DATE.Data = _SakuseiDate.ToString("yyyyMMdd");
			p.SAKUSEI_TIME.Data = _SakuseiDate.ToString("HHmmss");
			p.S_SYS_CD.Data = msg.SrcSysCode;
			p.R_SYS_CD.Data = msg.DstSysCode;
			p.HEADER_CNT.Data = "00000001";
			p.SYORI_KBN.Data = MsgConst.SYORI_KBN_NEW;
			p.SYORI_DATE.Data = _SakuseiDate.ToString("yyyyMMdd");
			p.SYORI_TIME.Data = _SakuseiDate.ToString("HHmmss");
            #endregion

            #region 受付(進捗)情報部
            p.PT_ID.Data = StringUtils.Mid(toHisInfo.MessageID1, 1, 10);
            #endregion

            return msg;
		}

		public override BaseMsgData CreateMsgData()
		{
			return new PatientRequestMsgData();
		}

		#endregion

		#endregion
	}
}
