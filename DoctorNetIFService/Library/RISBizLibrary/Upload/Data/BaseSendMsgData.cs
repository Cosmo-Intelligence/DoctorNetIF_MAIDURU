using RISBizLibrary.Data;

namespace RISBizLibrary.Upload.Data
{
	public class BaseSendMsgData : BaseMsgData
	{
		#region property

		#region 外からもらってくるもの

		/// <summary>
		/// データ元ソース
		/// </summary>
		public ToHisInfo DataSource
		{
			get;
			set;
		}

		#endregion

		#endregion

	}
}
