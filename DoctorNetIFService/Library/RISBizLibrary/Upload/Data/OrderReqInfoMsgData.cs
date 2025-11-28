using RISCommonLibrary.Lib.Msg.OrderRequestInfo;

namespace RISBizLibrary.Upload.Data
{
	/// <summary>
	/// メッセージのデータを保持する
	/// </summary>
	public class OrderReqInfoMsgData : BaseSendMsgData
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
		public new HISRISOrderRequestMsg Request
		{
			get
			{
				return base.Request as HISRISOrderRequestMsg;
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
