using RISBizLibrary.Data;

namespace RISBizLibrary.Updater.Table.TOOTHERSYSTEMINFO
{
	public abstract class TOOTHERSYSTEMINFOState
	{
		public virtual BaseMsgData Data
		{
			get;
			set;
		}

		public TOOTHERSYSTEMINFOState(BaseMsgData data)
		{
			Data = data;
		}
		public abstract string GetRIS_ID();

		public abstract string GetMESSAGETYPE();

		public abstract string GetDeleteMESSAGETYPE();

		public abstract string GetREQUESTUSER();

		public abstract string GetREQUESTTERMINALID();

		public abstract string GetMESSAGEID1();

		public abstract string GetMESSAGEID2();

	}
}
