using RISBizLibrary.Data;
using RISCommonLibrary.Lib.Msg.OrderInfo;

namespace RISBizLibrary.Download.Data
{
	public class OrderInfoMsgData : BaseMsgData
	{
		#region 外からもらってくるもの

		/// <summary>
		/// 対象RIS_ID
		/// </summary>
		public string RIS_ID
		{
			get;
			set;
		}
		#endregion

		#region メッセージ

		/// <summary>
		/// オーダメッセージ
		/// </summary>
		public new HISRISOrderMsg Request
		{
			get
			{
				return base.Request as HISRISOrderMsg;
			}
			set
			{
				base.Request = value;
			}
		}

		#endregion

		#region メッセージから取得

		#endregion
	}
}
