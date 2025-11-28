using System;
using System.Text;

namespace RISCommonLibrary.Lib.Msg
{
	//public enum RequestKindEnum
	//{
	//	rkOrder,                //依頼情報
	//	rkOrderCancel,          //依頼中止情報
	//	rkOrderReq,             //依頼再送要求情報
	//	rkReceipt,              //受付情報
	//	rkReceiptCancel,        //受付キャンセル情報
	//	rkExam,                 //実施情報
	//	rkExamUpdate,           //実施変更情報
	//	rkPatient,              //患者情報
	//	rkHospitalize,          //入院情報
	//	rkHospitalizeCancel,    //入院取消情報
	//	rkChangeWard,           //転棟情報
	//	rkChangeSection,        //転科情報
	//	rkLeaveHospital,        //退院情報
	//	rkLeaveHospitalCancel,  //退院取消情報
	//	rkLocus,                //部位情報
	//	rkRILocus,              //RI部位情報
	//	rkComment,              //コメント情報
	//	rkRIComment,            //RIコメント情報
	//	rkOrderType,            //オーダ種別情報
	//	rkRIOrderType,          //RI種別情報
	//	rkFilm,                 //フィルム情報
	//	rkDrug,                 //薬剤情報
	//	rkMaterial,             //器材情報
	//	rkUnit,                 //単位情報
	//	rkStaff,                //職員情報
	//	rkSection,              //診療科情報
	//	rkJobType,              //職種情報
	//	rkWard,                 //病棟情報
	//	rkRoom                  //病室情報
	//}

	/// <summary>
	/// 電文クラス
	/// </summary>
	public abstract class BaseMsg
	{

		#region field
		/// <summary>
		/// オリジナル電文
		/// </summary>
		private string _originalMessage;
		#endregion

		#region property

		/// <summary>
		/// 処理種別
		/// </summary>
		public string RequestType
		{
			get;
			set;
		}

		#region abstruct
		/// <summary>
		/// 電文名
		/// </summary>
		public abstract string MessageNameJ
		{
			get;
		}

		/// <summary>
		/// メッセージ長
		/// </summary>
		/// <remarks>
		/// 可変長の場合は0を設定
		/// </remarks>
		public abstract int MsgLength
		{
			get;
		}

		/// <summary>
		/// 電文種別
		/// </summary>
		public abstract string[] TelegraphKinds
		{
			get;
		}

		/// <summary>
		/// 制御コード
		/// </summary>
		public abstract string ControlCode
		{
			get;
		}

		/// <summary>
		/// ディレクトリ名
		/// </summary>
		public abstract string DirName
		{
			get;
		}

		/// <summary>
		/// システムコード：部門システム
		/// </summary>
		public abstract string SrcSysCode
		{
			get;
		}

		/// <summary>
		/// システムコード：オーダーシステム
		/// </summary>
		public abstract string DstSysCode
		{
			get;
		}

		#endregion

		#region virtual

		/// <summary>
		/// メッセージを文字列で設定・取得
		/// </summary>
		public virtual string TextMessage
		{
			get
			{
				StringBuilder sb = new StringBuilder();
				//sb.Append(MsgConst.MSG_ENCLOSURE_START);
				sb.Append(this.Body.Encode());
				//sb.Append(MsgConst.MSG_ENCLOSURE_END);
				return sb.ToString();
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					return;
				}
				_originalMessage = value;
				//string mesasgeTrim = MsgUtils.TrimEnclosure(value);
				StringIterator si = new StringIterator(value);
				this.Body.Decode(si);
			}
		}

		#endregion

		///// <summary>
		///// 要求種別
		///// </summary>
		//public RequestKindEnum RequestKind
		//{
		//	get;
		//	set;
		//}

		/// <summary>
		/// メッセージ本体
		/// </summary>
		public BaseRootNode Body
		{
			get;
			set;
		}

		/// <summary>
		/// 文字列から設定されたときのオリジナルメッセージ
		/// </summary>
		/// <remarks>送信の場合、まだ送信されていないときは""</remarks>
		public string OriginalMessage
		{
			get
			{
				return _originalMessage;
			}
		}

		#endregion

		#region コンストラクタ
		
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public BaseMsg()
		{

		}

		#endregion

		#region method
		
		/// <summary>
		/// 復元できるか
		/// </summary>
		/// <param name="src"></param>
		/// <returns></returns>
		public virtual bool CanDecode(string src)
		{
			if (string.IsNullOrEmpty(src))
			{
				return false;
			}

			//長さチェックはしないでおく
			#region 固定長電文の長さチェック
			if (!ValidateDataLength(src))
			{
				return false;
			}
			#endregion

			if (!ValidateDenbunSybt(src))
			{
				return false;
			}

			return true;
		}

		/// <summary>
		/// OriginalMessageに反映する
		/// </summary>
		public void ReflectOriginalMessage()
		{
			this._originalMessage = this.TextMessage;
		}


		#region protected

		/// <summary>
		/// データ長評価
		/// </summary>
		/// <param name="src"></param>
		/// <returns></returns>
		/// <remarks>ここでは固定長の評価にとどめる</remarks>
		protected bool ValidateDataLength(string src)
		{
			if (MsgLength== MsgConst.MSG_LENGTH_FLEXIBLE)
			{
				return true;
			}
			//string dataLengthString = GetDataLength(src);
			//int dataLength;
			//if (!int.TryParse(dataLengthString, out dataLength))
			//{
			//	throw new MsgException(string.Format("データ長が数値ではありません:{0}", dataLengthString));
			//}
			return true;
		}

		/// <summary>
		/// 電文種別評価
		/// </summary>
		/// <param name="src"></param>
		/// <returns></returns>
		protected bool ValidateDenbunSybt(string src)
		{
			string kind = GetDenbunSybt(src);
			return Array.Exists(TelegraphKinds, s => s == kind);
		}
		#endregion

		#region private
		
		/// <summary>
		/// 電文種別取得
		/// </summary>
		/// <param name="src"></param>
		/// <returns></returns>
		private string GetDenbunSybt(string src)
		{
			return this.Body.GetDenbunSybt(src);
		}
		#endregion

		#endregion

	}
}
