namespace RISCommonLibrary.Lib.Msg.Common.OrderInfo
{
	public interface HISRISIOrderInfo
	{
		/// <summary>
		/// 実施情報部
		/// </summary>
		HISRISOrderInfoAggregate OrderInfo
		{
			get;
			set;
		}
	}
}
