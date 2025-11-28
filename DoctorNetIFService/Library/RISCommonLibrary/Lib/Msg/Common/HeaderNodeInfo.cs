namespace RISCommonLibrary.Lib.Msg.Common
{
	/// <summary>
	/// 共通ヘッダーのノード定義
	/// </summary>
	class HeaderNodeInfo
	{
		public static NodeInfo HEADER_DENBUN_SYBT = new NodeInfo("DENBUN_SYBT", "電文種別", NodeTypeEnum.ntData, 2);
		public static NodeInfo HEADER_SAKUSEI_DATE = new NodeInfo("SAKUSEI_DATE", "作成日", NodeTypeEnum.ntData, 8);
		public static NodeInfo HEADER_SAKUSEI_TIME = new NodeInfo("SAKUSEI_TIME", "作成時刻", NodeTypeEnum.ntData, 6);
		public static NodeInfo HEADER_S_SYS_CD = new NodeInfo("S_SYS_CD", "送信側システムコード", NodeTypeEnum.ntData, 2);
		public static NodeInfo HEADER_R_SYS_CD = new NodeInfo("R_SYS_CD", "受信側システムコード", NodeTypeEnum.ntData, 2);
		public static NodeInfo HEADER_HEADER_CNT = new NodeInfo("HEADER_CNT", "システム間共通ヘッダ件数", NodeTypeEnum.ntData, 8);
		public static NodeInfo HEADER_SYORI_KBN = new NodeInfo("SYORI_KBN", "処理区分", NodeTypeEnum.ntData, 1);
		public static NodeInfo HEADER_SYORI_DATE = new NodeInfo("SYORI_DATE", "処理日", NodeTypeEnum.ntData, 8);
		public static NodeInfo HEADER_SYORI_TIME = new NodeInfo("SYORI_TIME", "処理時刻", NodeTypeEnum.ntData, 6);
	}
}
