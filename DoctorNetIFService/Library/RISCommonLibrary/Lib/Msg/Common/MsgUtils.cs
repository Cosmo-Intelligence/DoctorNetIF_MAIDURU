using System.Text;
using RISCommonLibrary.Lib.Utils;

namespace RISCommonLibrary.Lib.Msg.Common
{
	/// <summary>
	/// メッセージユーティリティ
	/// </summary>
	public class MsgUtils
	{
		/// <summary>
		/// 前ゼロパディングするフォーマットを取得する
		/// </summary>
		/// <param name="length"></param>
		/// <returns></returns>
		public static string GetFormatZeroPading(int length)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("{0:d");
			sb.Append(length.ToString());
			sb.Append("}");
			return sb.ToString();
		}

		/// <summary>
		/// 電文種別取得
		/// </summary>
		/// <param name="src"></param>
		/// <returns></returns>
		public static string GetDenbunSybt(string src)
		{
			return MBCSHelper.Copy(src,
				0,
				HeaderNodeInfo.HEADER_DENBUN_SYBT.FieldLength
				);
		}
	}
}
