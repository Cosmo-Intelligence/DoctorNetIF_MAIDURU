namespace RISCommonLibrary.Lib.Msg.Common.OrderRequestInfo
{
	public interface HISRISIOrderRequestInfo
	{
		/// <summary>
		/// 実施情報部
		/// </summary>
		HISRISOrderRequestInfoAggregate OrderRequestInfoRIS
		{
			get;
			set;
		}
	}
}
