using RISBizLibrary.Data;
using RISBizLibrary.Updater.Table.FROMHISINFO;
using RISCommonLibrary.Lib.Msg;
using RISCommonLibrary.Lib.Msg.Common.ChangeSection;

namespace RISBizLibrary.Updater.Table.FROMHISINFO
{
	public class FROMHISINFOStateChangeSection : FROMHISINFOState
	{

		public FROMHISINFOStateChangeSection(BaseMsgData data)
			: base(data)
		{

		}

		public override string GetRIS_ID()
		{
			return "";
		}

		public override string GetMESSAGETYPE()
		{
			ChangeSectionAggregate d = ((IChangeSection)(Data.Request.Body)).ChangeSection;
			if (d.DENBUN_SYBT.TrimData == MsgConst.DENBUN_SYBT_CHANGESECTION)
			{
				return RQRISDBConst.FROMHISINFO_MESSAGETYPE_CHANGESECTION;
			}
			return "";
		}

		public override string GetDeleteMESSAGETYPE()
		{
			string[] value = new string[]
				{
					"'" + RQRISDBConst.FROMHISINFO_MESSAGETYPE_CHANGESECTION + "'"
				};
			return string.Join(",", value);
		}

		public override string GetMESSAGEID1()
		{
			if (Data == null)
			{
				return "";
			}

			ChangeSectionAggregate hospital = ((IChangeSection)(Data.Request.Body)).ChangeSection;
			return hospital.PT_ID.TrimData;
		}

		public override string GetMESSAGEID2()
		{
			return "";
		}

	}
}
