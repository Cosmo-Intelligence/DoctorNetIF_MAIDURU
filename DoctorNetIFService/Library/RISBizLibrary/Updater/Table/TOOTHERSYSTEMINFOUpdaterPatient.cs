using RISBizLibrary.Data;
using RISBizLibrary.Updater.Table.TOOTHERSYSTEMINFO;
using RISBizLibrary.Updater.Table.TOSYNAPSEINFO;
using RISCommonLibrary.Lib.Exceptions;
using RISCommonLibrary.Lib.Msg;
using RISCommonLibrary.Lib.Msg.Common.Patient;

namespace RISBizLibrary.Updater.Table
{
	internal class TOOTHERSYSTEMINFOUpdaterPatient : TOOTHERSYSTEMINFOUpdater
	{
		protected override TOOTHERSYSTEMINFOState GetState(BaseMsgData data)
		{
			PatientAggregate d = ((IPatient)(data.Request.Body)).Patient;
			if (d.DENBUN_SYBT.TrimData == MsgConst.DENBUN_SYBT_PATIENT)
			{
				return new TOOTHERSYSTEMINFOStatePatient(data as BaseMsgData);
			}
			throw new MsgAnomalyException(string.Format(
				"想定していない電文種別を受信しました。電文種別={0}",
					d.DENBUN_SYBT.TrimData));
		}
	}
}
