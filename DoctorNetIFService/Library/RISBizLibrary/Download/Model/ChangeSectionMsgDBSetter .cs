using System.Configuration;
using System.Data;
using RISBizLibrary.Data;
using RISBizLibrary.Download.Data;
using RISBizLibrary.Updater;
using RISCommonLibrary.Lib.Utils;
using RISODPLibrary.Lib.Utils;

namespace RISBizLibrary.Download.Model
{
	/// <summary>
	/// メッセージからDBへ更新する
	/// </summary>
	internal class ChangeSectionMsgDBSetter : BaseMsgDBSetter
	{
		#region field

		#endregion

		#region property

		#endregion

		#region コンストラクタ

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public ChangeSectionMsgDBSetter()
			: base()
		{

		}

		#endregion

		#region method

		/// <summary>
		/// メッセージデータ保持クラス生成
		/// </summary>
		/// <returns></returns>
		protected override BaseMsgData CreateMsgData()
		{
			return new ChangeSectionMsgData();
		}

		/// <summary>
		/// 内部処理
		/// </summary>
		/// <param name="msgData"></param>
		/// <param name="cn"></param>
		/// <returns></returns>
		protected override bool SetDataToDatabaseInner(BaseMsgData msgData, IDbConnection cnRis)
		{
			ChangeSectionMsgData data =  (ChangeSectionMsgData)msgData;

			ValidateMaster(data, cnRis);
			ChangeSectionUpdater updater = new ChangeSectionUpdater();
			updater.InsertOrUpdate(data, cnRis);
			return true;
		}

		/// <summary>
		/// マスタチェック
		/// </summary>
		/// <param name="omsg"></param>
		private void ValidateMaster(ChangeSectionMsgData msgData, IDbConnection cn)
		{
			using (IDbCommand command = cn.CreateCommand())
			{
				command.InitCommandODP(ConfigurationManager.AppSettings["CommandTimeout"].StringToInt32());

				#region 患者情報部
				//ValidatePatient(msgData.Request.MsgBody.PatientAttribute, command);
				#endregion
			}
		}

		#endregion
	}
}
