namespace RISCommonLibrary.Lib.Msg.Common.ReceiptInfo
{
	public interface HISRISIReceiptInfo
	{
		/// <summary>
		/// 実施情報部
		/// </summary>
		HISRISReceiptInfoAggregate ReceiptInfoRIS
		{
			get;
			set;
		}
	}
}
