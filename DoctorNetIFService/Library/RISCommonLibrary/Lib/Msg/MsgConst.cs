using System;

namespace RISCommonLibrary.Lib.Msg
{
	/// <summary>
	/// 電文定義
	/// </summary>
	public class MsgConst
	{
		#region メッセージ定義
		
		/// <summary>
		/// メッセージパディング文字
		/// </summary>
		public const Char MSG_PADDING_CHAR = ' ';

		/// <summary>
		/// パス区切り文字列
		/// </summary>
		public const Char PATH_DELIMITER = '\\';

		#endregion

		#region 電文長定義

		#region 部

		///// <summary>
		///// 通信制御部電文長
		///// </summary>
		//public const int PART_LENGTH_COMMUNICATION_CONTROL = 52;

		///// <summary>
		///// 患者属性電文長
		///// </summary>
		//public const int PART_LENGTH_PATIENT_ATTRIBUTE = 1880;

		///// <summary>
		///// 受付（進捗）情報電文長
		///// </summary>
		//public const int PART_LENGTH_RECEIPT = 40;

		#endregion

		#region 電文
		
		#endregion

		/// <summary>
		/// 可変長の場合の電文長
		/// </summary>
		public const int MSG_LENGTH_FLEXIBLE = 0;

		#endregion

		#region 電文種別

		// システムコード
		public const string SYSTEMCODE_ORDER_SYSTEM = "AB"; //オーダーシステム
		public const string SYSTEMCODE_RTRIS        = "RT"; //放射線治療部門システム
		public const string SYSTEMCODE_RIS          = "BH"; //放射線部門システム

		// 制御コード
		public const string CONTROLCODE_ORDER     = "01"; //放射線検査オーダ依頼情報
		public const string CONTROLCODE_CHECKIN   = "02"; //部門受付情報
		public const string CONTROLCODE_COST      = "03"; //放射線検査実施情報
		public const string CONTROLCODE_PATIENT   = "05"; //患者情報
		public const string CONTROLCODE_ORDER_REQ = "06"; //依頼再送要求情報 

		public const string CONTROLCODE_HOSPITALIZE      = "S2"; //患者入院情報
		public const string CONTROLCODE_CHANGEWARD       = "S3"; //患者転棟情報
		public const string CONTROLCODE_LEAVEHOSPITAL    = "S4"; //患者退院情報
		public const string CONTROLCODE_PATIENT_REQ      = "S5"; //患者情報要求情報
		public const string CONTROLCODE_RT_ORDER         = "R1"; //治療予約情報
		public const string CONTROLCODE_RT_CHECKIN       = "R2"; //部門受付情報
		public const string CONTROLCODE_RT_COST          = "R3"; //治療実施情報
		public const string CONTROLCODE_RT_ORDER_RIS     = "01"; //依頼情報
		public const string CONTROLCODE_RT_CHECKIN_RIS   = "02"; //受付情報
		public const string CONTROLCODE_RT_COST_RIS      = "03"; //実施情報
		public const string CONTROLCODE_RT_ORDER_REQ     = "06"; //依頼再送要求情報

		// 対象ディレクトリ名
		public const string DIR_CHECKIN        = "CHECKIN";
		public const string DIR_PATIENT        = "PATIENT";
		public const string DIR_COST           = "COST";
		public const string DIR_ORDER          = "ORDER";
		public const string DIR_ORDER_REQ      = "ORDER_REQ";
		public const string DIR_RT_ORDER       = "RT_ORDER";
		public const string DIR_PATIENT_REQ    = "PATIENT_REQ";
		public const string DIR_RAD_ORDER      = "RAD_ORDER";
		public const string DIR_ORDER_REQ_RIS  = "FROM_RT_ORDER_REQ";
		public const string DIR_CHECKIN_RIS    = "FROM_RT_CHECKIN";
		public const string DIR_COST_RIS       = "FROM_RT_COST";

		// 処理区分
		public const string SYORI_KBN_NEW     = "1";
		public const string SYORI_KBN_CHANGE  = "2";
		public const string SYORI_KBN_CANCEL  = "3";

		// 電文種別
		public const string DENBUN_SYBT_RECEIPT = "U1";
		public const string DENBUN_SYBT_RECEIPT_CANCEL = "U2";
		public const string DENBUN_SYBT_ORDER = "O1";
		public const string DENBUN_SYBT_ORDERCHANGE = "O2";
		public const string DENBUN_SYBT_ORDERCANCEL = "O3";
		public const string DENBUN_SYBT_EXAM = "C1";
		public const string DENBUN_SYBT_EXAM_CHANGE = "C2";
		public const string DENBUN_SYBT_PATIENT_REQUEST = "R1";

		public const string DENBUN_SYBT_HOSPITALIZE = "3H";
		public const string DENBUN_SYBT_HOSPITALIZE_CANCEL = "3I";
		public const string DENBUN_SYBT_LEAVE_HOSPITAL = "3K";
		public const string DENBUN_SYBT_LEAVE_HOSPITAL_CANCEL = "3L";
		public const string DENBUN_SYBT_CHANGEWARD = "3J";
		public const string DENBUN_SYBT_CHANGESECTION = "3M";
		public const string DENBUN_SYBT_PATIENT = "3G";
		// 2020.08.28 Add H.Taira@COSMO Start
		public const string DENBUN_SYBT_REQUEST_PATIENT = "3N";
		// 2020.08.28 Add H.Taira@COSMO End
		public const string DENBUN_SYBT_ORDER_RIS = "3E";
		public const string DENBUN_SYBT_ORDERCANCEL_RIS = "3F";
		public const string DENBUN_SYBT_RECEIPT_RIS = "2Q";
		public const string DENBUN_SYBT_RECEIPT_CANCEL_RIS = "2R";
		public const string DENBUN_SYBT_EXAM_RIS = "2S";
		public const string DENBUN_SYBT_EXAM_CHANGE_RIS = "2T";
		public const string DENBUN_SYBT_REQUEST_RIS = "2P";

		#endregion

		#region 要求種別テーブル
		/// <summary>
		/// 要求種別テーブル
		/// </summary>
		public static string[] KIND_CHAR_TABLE  = new []
		{
			"3E",     //依頼情報
			"3F",     //依頼中止情報
			"2P",     //依頼再送要求
			"2Q",     //受付情報
			"2R",     //受付取消情報
			"2S",     //実施情報
			"2T",     //実施変更情報
			"3G",     //患者情報
			"3H",     //入院情報
			"3I",     //入院取消情報
			"3J",     //転棟情報
			"3M",     //転科情報
			"3K",     //退院情報
			"3L",     //退院取消
			"",       //これ以降はマスタ情報用の為、電文種別の取り決めはなし
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			""
		};
		#endregion

		#region 電文エラーステータス
		/// <summary>
		/// 正常
		/// </summary>
		public const string ERR_STATUS_NORMAL = "00";

		/// <summary>
		/// 電文長エラー
		/// </summary>
		public const string ERR_STATUS_DATA_LENGTH = "10";

		/// <summary>
		/// 電文の必須項目のエラー
		/// </summary>
		public const string ERR_STATUS_NOT_NULL = "11";

		/// <summary>
		/// 電文の部位項目の繰り返し順番エラー
		/// </summary>
		public const string ERR_STATUS_NOT_SEQUENCE = "12";

		/// <summary>
		/// 例外エラー（型変換など）
		/// </summary>
		public const string ERR_STATUS_ANOMALY = "13";

		/// <summary>
		/// ＨＩＳマスタ存在なしのエラー
		/// </summary>
		public const string ERR_STATUS_HIS_MASTER_NO_EXIST = "20";

		/// <summary>
		/// ＨＩＳ側DBのエラー
		/// </summary>
		public const string ERR_STATUS_HIS_DB_ERR = "21";

		/// <summary>
		/// 受付データなし
		/// </summary>
		public const string ERR_STATUS_NO_RECEIPT_DATA = "22";

		/// <summary>
		/// 実施データ重複（新規）
		/// </summary>
		public const string ERR_STATUS_NO_EXAM_DATA = "23";

		/// <summary>
		/// 実施済み
		/// </summary>
		public const string ERR_STATUS_DONE_EXAM = "24";

		/// <summary>
		/// 受付済み
		/// </summary>
		public const string ERR_STATUS_DONE_RECEIPT = "25";

		/// <summary>
		/// 会計済み
		/// </summary>
		public const string ERR_STATUS_DONE_ACCOUNT = "26";

		/// <summary>
		/// RISマスタ存在なしのエラー
		/// </summary>
		public const string ERR_STATUS_RIS_MASTER_NOT_EXIST = "30";

		/// <summary>
		/// RIS側DBのエラー
		/// </summary>
		public const string ERR_STATUS_RIS_DB_ERR = "31";

		/// <summary>
		/// 検査種別エラー
		/// </summary>
		public const string ERR_STATUS_EXAM_KIND_ERR = "32";

		#endregion

		#region 継続フラグ
		/// <summary>
		/// 継続なし
		/// </summary>
		public const string CONTINUANCE_FLAG_NOT_EXIST = "0";

		/// <summary>
		/// 継続あり
		/// </summary>
		public const string CONTINUANCE_FLAG_EXIST = "1";
		#endregion

		#region 処理タイプ
		/// <summary>
		/// 処理タイプ-新規
		/// </summary>
		public const string PROCESSING_TYPE_NEW = "1";
		
		/// <summary>
		/// 処理タイプ-削除
		/// </summary>
		public const string PROCESSING_TYPE_DELETE = "2";

		/// <summary>
		/// 処理タイプ-患者情報
		/// </summary>
		public const string PROCESSING_TYPE_PATIENT = "3";

		/// <summary>
		/// 処理タイプ-画像
		/// </summary>
		public const string PROCESSING_TYPE_IMAGE = "10";

		/// <summary>
		/// 処理タイプ-1次所見
		/// </summary>
		public const string PROCESSING_TYPE_REMARK_FIRST = "20";

		/// <summary>
		/// 処理タイプ-2次所見
		/// </summary>
		public const string PROCESSING_TYPE_REMARK_SECOND = "30";

		/// <summary>
		/// 処理タイプ-2次所見解除
		/// </summary>
		public const string PROCESSING_TYPE_REMARK_SECOND_CANCEL = "31";

		#region なぜか実施だけコード体系が違う
		/// <summary>
		/// 処理タイプ-新規(実施)
		/// </summary>
		public const string PROCESSING_TYPE_NEW_EXAM = "1";
		
		/// <summary>
		/// 処理タイプ-修正(実施)
		/// </summary>
		public const string PROCESSING_TYPE_UPDATE_EXAM = "3";

		/// <summary>
		/// 処理タイプ-中止(実施)
		/// </summary>
		public const string PROCESSING_TYPE_STOP_EXAM = "4";
		
		#endregion

		#endregion

		#region 患者属性部
		/// <summary>
		/// 患者入外区分-入院
		/// </summary>
		public const string PATIENT_INOUT_ADMISSION = "1";

		/// <summary>
		/// 患者入外区分-外来
		/// </summary>
		public const string PATIENT_INOUT_CLINIC = "2";

		/// <summary>
		/// 結果値-検索結果-検査コード-クレアチニン
		/// </summary>
		public const string PATIENT_RESULT_VALUE_EXAMDATE_EXAM_CODE_CRE = "15";

		/// <summary>
		/// 結果値-検索結果-検査コード-eGFR
		/// </summary>
		public const string PATIENT_RESULT_VALUE_EXAMDATE_EXAM_CODE_EGFR = "234";

		#endregion

		#region オーダ部

		#region 所見要否
		/// <summary>
		/// 所見要否-至急所見
		/// </summary>
		public const string ORDER_REMARK_NECESSITY_IMMEDIATE = "1";

		/// <summary>
		/// 所見要否-所見有り
		/// </summary>
		public const string ORDER_REMARK_NECESSITY_EXIST = "2";
	
		/// <summary>
		/// 所見要否-所見無し
		/// </summary>
		public const string ORDER_REMARK_NECESSITY_NOT_EXIST = "3";

		#endregion

		#region 明細

		#region 項目区分
		/// <summary>
		/// 項目区分-撮影主行為
		/// </summary>
		public const string ORDER_ITEM_KIND_ACT = "JA";

		/// <summary>
		/// 項目区分-部位
		/// </summary>
		public const string ORDER_ITEM_KIND_BUI = "JB";

		/// <summary>
		/// 項目区分-方向
		/// </summary>
		public const string ORDER_ITEM_KIND_HOUKOU = "JH";

		/// <summary>
		/// 項目区分-体位
		/// </summary>
		public const string ORDER_ITEM_KIND_TAII = "JT";

		/// <summary>
		/// 項目区分-行為コメント
		/// </summary>
		public const string ORDER_ITEM_KIND_ACT_COMMENT = "JV";

		/// <summary>
		/// 項目区分-薬剤
		/// </summary>
		public const string ORDER_ITEM_KIND_DRUG = "JD";

		/// <summary>
		/// 項目区分-フィルム
		/// </summary>
		public const string ORDER_ITEM_KIND_FILM = "JF";

		/// <summary>
		/// 項目区分-手技
		/// </summary>
		public const string ORDER_ITEM_KIND_MANIPULATE = "JJ";

		/// <summary>
		/// 項目区分-加算
		/// </summary>
		public const string ORDER_ITEM_KIND_KASAN = "JK";

		/// <summary>
		/// 項目区分-材料
		/// </summary>
		public const string ORDER_ITEM_KIND_MATERIAL = "JL";
		 
		#endregion

		#region コメント区分

		/// <summary>
		/// コメント区分-初期値
		/// </summary>
		public const string ORDER_COMMENT_KIND_DEFAULT = "00";

		/// <summary>
		/// コメント区分-オーダーコメント
		/// </summary>
		public const string ORDER_COMMENT_KIND_ORDERCOMMENT = "73";

		/// <summary>
		/// コメント区分-検査種別ｺコメント
		/// </summary>
		public const string ORDER_COMMENT_KIND_KENSA_TYPE = "79";

		/// <summary>
		/// コメント区分-項目別コメント
		/// </summary>
		public const string ORDER_COMMENT_KIND_ITEMIZED = "71";

		#endregion

		#region 部分中止

		/// <summary>
		/// 部分中止-部分中止
		/// </summary>
		public const string SOME_CANCEL_CANCEL = "1";
		

		#endregion

		#endregion

		#endregion

	}
}
