using RISCommonLibrary.Lib.Msg;
using RISCommonLibrary.Lib.Msg.OrderInfo;

namespace RISBizLibrary.Download.Model
{
	public class MessageHandlerOrderInfo : MessageHandler
	{

		#region コンストラクタ

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public MessageHandlerOrderInfo():base()
		{

		}

		#endregion

		/// <summary>
		/// DB処理を任せるクラスを生成する
		/// </summary>
		/// <param name="msg"></param>
		/// <returns></returns>
		protected override bool SetDBSetter(BaseMsg msg)
		{
			_log.Info("オーダ情報を受信しました");
			OrderInfoMsgDBSetter dbsetter = new OrderInfoMsgDBSetter();
			return dbsetter.SetDataToDatabase(msg as HISRISOrderMsg);
		}

		/// <summary>
		/// メッセージファクトリに登録する
		/// </summary>
		protected override void RegistFactory()
		{
			MsgFactory.Instance.RegistMsg(typeof(HISRISOrderMsg));
		}

		public override string[] GetDenbunSybt()
		{
			return new[]
			{
				MsgConst.DENBUN_SYBT_ORDER_RIS,
				MsgConst.DENBUN_SYBT_ORDERCANCEL_RIS
			};
		}

	}
}
