using RISBizLibrary.Data;
using RISCommonLibrary.Lib.Msg.Hospitalize;

namespace RISBizLibrary.Download.Data
{
	public class HospitalMsgData : BaseMsgData
	{

		#region メッセージ

		/// <summary>
		/// 入院メッセージ
		/// </summary>
		public new HospitalizeMsg Request
		{
			get
			{
				return base.Request as HospitalizeMsg;
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
