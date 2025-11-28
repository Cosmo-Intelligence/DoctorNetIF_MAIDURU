using RISCommonLibrary.Lib.Msg.PatientRequest;

namespace RISBizLibrary.Upload.Data
{
	/// <summary>
	/// 患者要求メッセージのデータを保持する
	/// </summary>
	public class PatientRequestMsgData : BaseSendMsgData
	{
		#region field

		#endregion

		#region property

		#region 外からもらってくるもの

		#endregion

		#region メッセージ
		
		/// <summary>
		/// メッセージ
		/// </summary>
		public new PatientRequestMsg Request
		{
			get
			{
				return base.Request as PatientRequestMsg;
			}
			set
			{
				base.Request = value;
			}
		}

		#endregion

		#region メッセージから取得
		
		#endregion

		#endregion

		#region method

		#endregion
	}
}
