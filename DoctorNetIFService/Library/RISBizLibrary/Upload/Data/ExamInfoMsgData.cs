using RISCommonLibrary.Lib.Msg.ExamInfo;

namespace RISBizLibrary.Upload.Data
{
	/// <summary>
	/// メッセージのデータを保持する
	/// </summary>
	public class ExamInfoMsgData : BaseSendMsgData
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
		public new HISRISExamMsg Request
		{
			get
			{
				return base.Request as HISRISExamMsg;
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
