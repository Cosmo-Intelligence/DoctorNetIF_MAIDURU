using RISCommonLibrary.Lib.Msg.ReceiptInfo;

namespace RISBizLibrary.Upload.Data
{
	/// <summary>
	/// 受付メッセージのデータを保持する
	/// </summary>
	public class ReceiptMsgData : BaseSendMsgData
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
		public new HISRISReceiptInfoMsg Request
		{
			get
			{
				return base.Request as HISRISReceiptInfoMsg;
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
