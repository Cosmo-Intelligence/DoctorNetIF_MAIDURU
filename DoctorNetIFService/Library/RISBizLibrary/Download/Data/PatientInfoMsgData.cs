using RISBizLibrary.Data;
using RISCommonLibrary.Lib.Msg.Patient;

namespace RISBizLibrary.Download.Data
{
	public class PatientInfoMsgData : BaseMsgData
	{

		#region メッセージ

		/// <summary>
		/// オーダメッセージ
		/// </summary>
		public new PatientMsg Request
		{
			get
			{
				return base.Request as PatientMsg;
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
