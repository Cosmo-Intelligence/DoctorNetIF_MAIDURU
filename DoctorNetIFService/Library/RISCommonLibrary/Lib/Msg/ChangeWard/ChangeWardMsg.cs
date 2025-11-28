namespace RISCommonLibrary.Lib.Msg.ChangeWard
{
	/// <summary>
	/// 転棟情報ハンドリングクラス
	/// </summary>
	public class ChangeWardMsg : BaseMsg
	{
		#region field
		#endregion

		#region property

		/// <summary>
		/// 対象電文名
		/// </summary>
		public override string MessageNameJ
		{
			get
			{
				return "転棟情報ﾃﾞｰﾀ";
			}
		}

		/// <summary>
		/// 電文種別
		/// </summary>
		public override string[] TelegraphKinds
		{
			get
			{
				return new[] { MsgConst.DENBUN_SYBT_CHANGEWARD };
			}
		}

		/// <summary>
		/// メッセージ長
		/// </summary>
		public override int MsgLength
		{
			get
			{
				//固定長
				return MsgConst.MSG_LENGTH_FLEXIBLE;
			}
		}

		/// <summary>
		/// 制御コード
		/// </summary>
		public override string ControlCode
		{
			get
			{
				return MsgConst.CONTROLCODE_PATIENT_REQ;
			}
		}

		/// <summary>
		/// ディレクトリ名
		/// </summary>
		public override string DirName
		{
			get
			{
				return MsgConst.DIR_PATIENT_REQ;
			}
		}

		/// <summary>
		/// システムコード：部門システム
		/// </summary>
		public override string SrcSysCode
		{
			get
			{
				return MsgConst.SYSTEMCODE_RIS;
			}
		}

		/// <summary>
		/// システムコード：オーダーシステム
		/// </summary>
		public override string DstSysCode
		{
			get
			{
				return MsgConst.SYSTEMCODE_ORDER_SYSTEM;
			}
		}

		/// <summary>
		/// メッセージツリールートクラス
		/// </summary>
		/// <remarks>キャストの手間を避けるために作成</remarks>
		public ChangeWardRoot MsgBody
		{
			get
			{
				return (ChangeWardRoot)Body;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public ChangeWardMsg()
			: base()
		{
			Body = new ChangeWardRoot();
		}
		#endregion
	}
}
