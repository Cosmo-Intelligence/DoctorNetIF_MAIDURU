using RISBizLibrary.Data;

namespace RISBizLibrary.Updater.Table.FROMHISINFO
{
	public abstract class  FROMHISINFOState
	{
		public virtual BaseMsgData Data
		{
			get;
			set;
		}

		public FROMHISINFOState(BaseMsgData data)
		{
			Data = data;
		}

		public abstract string GetRIS_ID();

		public abstract string GetMESSAGETYPE();

		public abstract string GetDeleteMESSAGETYPE();

		public abstract string GetMESSAGEID1();

		public abstract string GetMESSAGEID2();

	}
}
