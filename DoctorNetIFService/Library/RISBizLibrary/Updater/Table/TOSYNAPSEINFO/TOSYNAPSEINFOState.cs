using RISBizLibrary.Data;

namespace RISBizLibrary.Updater.Table.TOSYNAPSEINFO
{
	public abstract class TOSYNAPSEINFOState
	{
		public virtual BaseMsgData Data
		{
			get;
			set;
		}

		public TOSYNAPSEINFOState(BaseMsgData data)
		{
			Data = data;
		}

		public abstract string GetMESSAGETYPE();

		public abstract string GetDeleteMESSAGETYPE();

		public abstract string GetREQUESTUSER();

		public abstract string GetREQUESTTERMINALID();

		public abstract string GetMESSAGEORDERID();

		public abstract string GetMESSAGEPATIENTID();

	}
}
