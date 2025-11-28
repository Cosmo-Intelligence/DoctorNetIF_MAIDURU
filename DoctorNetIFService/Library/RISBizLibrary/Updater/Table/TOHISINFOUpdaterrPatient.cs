using RISBizLibrary.Data;
using RISBizLibrary.Updater.Table.TOHISINFO;
using RISCommonLibrary.Lib.Exceptions;
using RISCommonLibrary.Lib.Msg;
using RISCommonLibrary.Lib.Msg.Common.Hospitalize;
using RISCommonLibrary.Lib.Msg.Common.OrderInfo;
using RISCommonLibrary.Lib.Msg.Common.Patient;

namespace RISBizLibrary.Updater.Table
{
	internal class TOHISINFOUpdaterrPatient : TOHISINFOUpdater
	{
		protected override TOHISINFOState GetState(BaseMsgData data)
		{
			PatientAggregate d = ((IPatient)(data.Request.Body)).Patient;
			return new TOHISINFOStatePatient(data as BaseMsgData);
		}
	}
}
