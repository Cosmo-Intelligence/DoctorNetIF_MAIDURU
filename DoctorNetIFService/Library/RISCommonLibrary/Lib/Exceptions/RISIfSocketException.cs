using System;

namespace RISCommonLibrary.Lib.Exceptions
{

	/// <summary>
	/// ソケットシステム例外基底
	/// </summary>
	public class RISIfSocketException : RISIfExceptionFatalException
	{
		public RISIfSocketException()
			: base()
		{

		}

		public RISIfSocketException(string message)
			: base(message)
		{


		}

		public RISIfSocketException(string message, Exception inner)
			: base(message, inner)
		{

		}
	}
}
