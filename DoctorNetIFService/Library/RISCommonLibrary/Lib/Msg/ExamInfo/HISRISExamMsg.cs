using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RISCommonLibrary.Lib.Msg.ExamInfo
{
	public class HISRISExamMsg : BaseMsg
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
				return "放射線実施データ";
			}
		}

		/// <summary>
		/// 電文種別
		/// </summary>
		public override string[] TelegraphKinds
		{
			get
			{
				return new[] {
					MsgConst.DENBUN_SYBT_EXAM_RIS,
					MsgConst.DENBUN_SYBT_EXAM_CHANGE_RIS
				};
			}
		}

		/// <summary>
		/// メッセージ長
		/// </summary>
		public override int MsgLength
		{
			get
			{
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
				return MsgConst.CONTROLCODE_COST;
			}
		}

		/// <summary>
		/// ディレクトリ名
		/// </summary>
		public override string DirName
		{
			get
			{
				return MsgConst.DIR_COST;
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
		public HISRISExamRoot MsgBody
		{
			get
			{
				return (HISRISExamRoot)Body;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public HISRISExamMsg()
			: base()
		{
			Body = new HISRISExamRoot();
		}
		#endregion
	}
}
