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
	internal class PatientInfoMsgDBSetter : BaseMsgDBSetter
	{
		#region field

		#endregion

		#region property

		#endregion

		#region コンストラクタ

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public PatientInfoMsgDBSetter()
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
			return new PatientInfoMsgData();
		}

		/// <summary>
		/// 内部処理
		/// </summary>
		/// <param name="msgData"></param>
		/// <param name="cn"></param>
		/// <returns></returns>
		protected override bool SetDataToDatabaseInner(BaseMsgData msgData, IDbConnection cnRis)
		{
			PatientInfoMsgData patientMsgData =  (PatientInfoMsgData)msgData;

			ValidateMaster(patientMsgData, cnRis);
			PatientUpdater updater = new PatientUpdater();
			updater.InsertOrUpdate(patientMsgData, cnRis);
			return true;
		}

		/// <summary>
		/// マスタチェック
		/// </summary>
		/// <param name="omsg"></param>
		private void ValidateMaster(PatientInfoMsgData msgData, IDbConnection cn)
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
