using System;
using System.Data;

namespace RISCommonLibrary.Lib.Utils
{
	/// <summary>
	/// パラメータ補助
	/// </summary>
	public static class ParameterUtils
	{
		/// <summary>
		/// 入力文字列パラメータ設定
		/// </summary>
		/// <param name="param"></param>
		/// <param name="name"></param>
		/// <param name="value"></param>
		public static void SetInputString(this IDataParameter param, String name, String value)
		{
			param.Direction = ParameterDirection.Input;
			param.DbType = DbType.String;
			param.ParameterName = name;
			param.Value = value;
		}

		/// <summary>
		/// 入力数値パラメータ設定
		/// </summary>
		/// <param name="param"></param>
		/// <param name="name"></param>
		/// <param name="value"></param>
		public static void SetInputInt32(this IDataParameter param, String name, Int32 value)
		{
			param.Direction = ParameterDirection.Input;
			param.DbType = DbType.Int32;
			param.ParameterName = name;
			param.Value = value;
		}

		/// <summary>
		/// 入力数値パラメータ設定
		/// </summary>
		/// <param name="param"></param>
		/// <param name="name"></param>
		/// <param name="value"></param>
		public static void SetInputInt32Nullable(this IDataParameter param, String name, Nullable<Int32> value)
		{
			param.Direction = ParameterDirection.Input;
			param.DbType = DbType.Int32;
			param.ParameterName = name;
			if (!value.HasValue)
			{
				param.Value = DBNull.Value;
				return;
			}
			param.Value = value;
		}

		/// <summary>
		/// 入力数値パラメータ設定
		/// </summary>
		/// <param name="param"></param>
		/// <param name="name"></param>
		/// <param name="value"></param>
		public static void SetInputInt32FromString(this IDataParameter param, String name, String value)
		{
			param.Direction = ParameterDirection.Input;
			param.DbType = DbType.Int32;
			param.ParameterName = name;
			int dstValue;
			if (!Int32.TryParse(value, out dstValue))
			{
				param.Value = DBNull.Value;
				return;
			}
			param.Value = dstValue;
		}

		/// <summary>
		/// 入力Decimalパラメータ設定
		/// </summary>
		/// <param name="param"></param>
		/// <param name="name"></param>
		/// <param name="value"></param>
		public static void SetInputDecimalFromString(this IDataParameter param, String name, String value)
		{
			param.Direction = ParameterDirection.Input;
			param.DbType = DbType.Decimal;
			param.ParameterName = name;
			decimal dstValue;
			if (!Decimal.TryParse(value, out dstValue))
			{
				param.Value = DBNull.Value;
				return;
			}
			param.Value = dstValue;
		}

		/// <summary>
		/// 入力64Bit数値パラメータ設定
		/// </summary>
		/// <param name="param"></param>
		/// <param name="name"></param>
		/// <param name="value"></param>
		public static void SetInputInt64(this IDataParameter param, String name, Int64 value)
		{
			param.Direction = ParameterDirection.Input;
			param.DbType = DbType.Int64;
			param.ParameterName = name;
			param.Value = value;
		}

		/// <summary>
		/// 入力日時パラメータ設定
		/// </summary>
		/// <param name="param"></param>
		/// <param name="name"></param>
		/// <param name="value"></param>
		public static void SetInputDateTime(this IDataParameter param, String name, DateTime value)
		{
			param.Direction = ParameterDirection.Input;
			param.DbType = DbType.DateTime;
			param.ParameterName = name;
			param.Value = value;
		}

		/// <summary>
		/// 入力日時パラメータ設定
		/// </summary>
		/// <param name="param"></param>
		/// <param name="name"></param>
		/// <param name="value"></param>
		public static void SetInputDateTimeNullable(this IDataParameter param, String name, Nullable<DateTime> value)
		{
			param.Direction = ParameterDirection.Input;
			param.DbType = DbType.DateTime;
			param.ParameterName = name;
			if (!value.HasValue)
			{
				param.Value = DBNull.Value;
				return;
			}
			param.Value = value;
		}

		// 2020.07.29 mod start cosmo@nishihara
		/// <summary>
		/// 入力日時パラメータ設定
		/// </summary>
		/// <param name="param"></param>
		/// <param name="name"></param>
		/// <param name="value"></param>
		//public static void SetInputDateTimeFromString(this IDataParameter param, String name, String value)
		//{
		//	string _Year;
		//	string _Month;
		//	string _Day;
		//	string _Hour;
		//	string _Minute;
		//	string _Second;

		//	try
		//	{
		//		param.Direction = ParameterDirection.Input;
		//		param.DbType = DbType.DateTime;
		//		param.ParameterName = name;
		//		DateTime dstValue;

		//		_Year = StringUtils.Mid(value, 1, 4);
		//		_Month = StringUtils.Mid(value, 5, 2);
		//		_Day = StringUtils.Mid(value, 7, 2);

		//		// "YYYYMMDDHHMMSS"の値が入ってきたら"YYYY/MM/DD HH:MM:SS"にする
		//		if (value.Length == 14)
		//		{
		//			_Hour = StringUtils.Mid(value, 9, 2);
		//			_Minute = StringUtils.Mid(value, 11, 2);
		//			_Second = StringUtils.Mid(value, 13, 2);
		//			value = _Year + "/" + _Month + "/" + _Day + " " + _Hour + ":" + _Minute + ":" + _Second;
		//		}
		//		// "YYYYMMDD"の値が入ってきたら"YYYY/MM/DD"にする
		//		else if (value.Length == 8)
		//		{ 
		//			value = _Year + "/" + _Month + "/" + _Day;
		//		}

		//		if (!DateTime.TryParse(value, out dstValue))
		//		{
		//			param.Value = DBNull.Value;
		//			return;
		//		}
		//		param.Value = dstValue;

		//	}
		//	catch (Exception)
		//	{
		//		param.Value = DBNull.Value;
		//		return;
		//	}
		//}

		public static void SetInputDateTimeFromString(this IDataParameter param, String name, String value)
		{
			param.Direction = ParameterDirection.Input;
			param.DbType = DbType.DateTime;
			param.ParameterName = name;
			DateTime dstValue;
			if (!DateTime.TryParse(value, out dstValue))
			{
				param.Value = DBNull.Value;
				return;
			}
			param.Value = dstValue;
		}
		// 2020.07.29 mod end cosmo@nishihara

		/// <summary>
		/// 入力数値パラメータNull設定
		/// </summary>
		/// <param name="param"></param>
		/// <param name="name"></param>
		public static void SetInputInt32Null(this IDataParameter param, String name)
		{
			param.Direction = ParameterDirection.Input;
			param.DbType = DbType.Int32;
			param.ParameterName = name;
			param.Value = DBNull.Value;
		}

		/// <summary>
		/// 入力日時パラメータNull設定
		/// </summary>
		/// <param name="param"></param>
		/// <param name="name"></param>
		public static void SetInputDateTimeNull(this IDataParameter param, String name)
		{
			param.Direction = ParameterDirection.Input;
			param.DbType = DbType.DateTime;
			param.ParameterName = name;
			param.Value = DBNull.Value;
		}
	}
}
