using RISBizLibrary.Data;
using RISCommonLibrary.Lib.Msg.ChangeWard;

namespace RISBizLibrary.Download.Data
{
	public class ChangeWardMsgData : BaseMsgData
	{

		#region メッセージ

		/// <summary>
		/// 転棟メッセージ
		/// </summary>
		public new ChangeWardMsg Request
		{
			get
			{
				return base.Request as ChangeWardMsg;
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
