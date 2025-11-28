using RISBizLibrary.Data;
using RISBizLibrary.Updater.Table.FROMHISINFO;
using RISCommonLibrary.Lib.Msg;
using RISCommonLibrary.Lib.Msg.Common.ChangeWard;

namespace RISBizLibrary.Updater.Table.FROMHISINFO
{
	public class FROMHISINFOStateChangeWard : FROMHISINFOState
	{

		public FROMHISINFOStateChangeWard(BaseMsgData data)
			: base(data)
		{

		}

		public override string GetRIS_ID()
		{
			return "";
		}

		public override string GetMESSAGETYPE()
		{
			ChangeWardAggregate d = ((IChangeWard)(Data.Request.Body)).ChangeWard;
				return RQRISDBConst.FROMHISINFO_MESSAGETYPE_CHANGEWARD;
		}

		public override string GetDeleteMESSAGETYPE()
		{
			string[] value = new string[]
				{
					"'" + RQRISDBConst.FROMHISINFO_MESSAGETYPE_CHANGEWARD + "'"
				};
			return string.Join(",", value);
		}

		public override string GetMESSAGEID1()
		{
			if (Data == null)
			{
				return "";
			}

			ChangeWardAggregate hospital = ((IChangeWard)(Data.Request.Body)).ChangeWard;
			return hospital.PT_ID.TrimData;
		}

		public override string GetMESSAGEID2()
		{
			return "";
		}

	}
}
