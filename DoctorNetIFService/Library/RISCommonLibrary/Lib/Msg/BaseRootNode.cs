using RISCommonLibrary.Lib.Msg.Common;

namespace RISCommonLibrary.Lib.Msg
{
	/// <summary>
	/// ルート基底
	/// </summary>
	public abstract class BaseRootNode: AggregateNode
	{
		#region field
		
		#endregion

		#region property
		
		#endregion

		#region コンストラクタ
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public BaseRootNode(NodeInfo define)
			: base(define)
		{
		}
		#endregion

		#region method

		/// <summary>
		/// データ長を再計算する
		/// </summary>
		public void ReCalcDataLength()
		{
			//CommunicationControl.DATA_LENGTH.Data = this.Size.ToString();
		}

		/// <summary>
		/// 電文種別取得
		/// </summary>
		/// <param name="src"></param>
		/// <returns></returns>
		public string GetDenbunSybt(string src)
		{
			return MsgUtils.GetDenbunSybt(src);
		}

		#endregion
	}
}
