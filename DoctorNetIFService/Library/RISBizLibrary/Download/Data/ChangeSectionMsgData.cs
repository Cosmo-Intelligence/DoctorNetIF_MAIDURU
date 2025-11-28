using RISBizLibrary.Data;
using RISCommonLibrary.Lib.Msg.ChangeSection;

namespace RISBizLibrary.Download.Data
{
	public class ChangeSectionMsgData : BaseMsgData
	{

		#region メッセージ

		/// <summary>
		/// 転棟メッセージ
		/// </summary>
		public new ChangeSectionMsg Request
		{
			get
			{
				return base.Request as ChangeSectionMsg;
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
