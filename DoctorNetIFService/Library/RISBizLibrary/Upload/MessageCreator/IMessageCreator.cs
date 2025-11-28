using System.Data;
using RISBizLibrary.Data;
using RISBizLibrary.Upload.Data;
using RISCommonLibrary.Lib.Msg;

namespace RISBizLibrary.Upload.MessageCreator
{
	interface IMessageCreator
	{

		//bool Connected
		//{
		//	get;
		//}

		//void ConnectTcp();
		//void DisConnectTcp();

		//BaseMsgData RequestOpen();
		//BaseMsgData RequestClose();

		BaseMsg CreateMsg(ToHisInfo toHisInfo, IDbConnection cnRis, string pRISID, string pAllRisId);

		string[] GetRequestTypes();

		BaseMsgData CreateMsgData();

		// 2020.08.28 Mod H.Taira@COSMO Start
		//void Send(BaseMsgData msgData);
		void Send(BaseMsgData msgData, IDbConnection connection);
		// 2020.08.28 Mod H.Taira@COSMO End

	}
}
