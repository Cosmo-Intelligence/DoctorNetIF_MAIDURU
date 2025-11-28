using Oracle.DataAccess.Client;
using DoctorNetIFService.Data;
using RISCommonLibrary.Lib.Utils;
using RISODPLibrary.Lib.Utils;
using RISReportService.util;
using System;
using System.Collections.Generic;
using System.Data;

namespace DoctorNetIFService.Model
{
    internal static class TableInfoHelper
    {
        /// <summary>
        /// log4netインスタンス
        /// </summary>
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(
            System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private const string PARAM_RECORDCOUNT = "recordcount";

        #region 参照
        // TOOTHERSYSTEMINFOの定周期監視
        public static ToOtherSystemInfo[] GetDataToOtherSystemInfo(IDbConnection cnRISDB, string requesttype, int systemno, int recordcount)
        {
            const string queryParts =
                "SELECT" +
                "   REQUESTID" +
                "   ,RIS_ID" +
                " FROM" +
                "    TOOTHERSYSTEMINFO " +
                " WHERE" +
                "    REQUESTTYPE in ({RTYPEVAL}) " +
                " AND" +
                "    SYSTEMNO  = :systemno " +
                " AND" +
                "    TRANSFERSTATUS = '00' " +
                " AND" +
                "    rownum <= :recordcount " +
                "    ORDER BY REQUESTID ASC";

            using (IDbCommand command = cnRISDB.CreateCommand())
            {
                command.InitCommandODP(AppConfigController.GetInstance().GetValueString(AppConfigParameter.commandTimeout).StringToInt32());

                #region パラメータ設定

                command.Parameters.Clear();
                IDataParameter param = command.CreateParameter();
                string[] arrRequesttype = requesttype.Split(',');
                List<string> paramNames = new List<string>();
                int i = 0;
                foreach (var rtype in arrRequesttype)
                {
                    param = command.CreateParameter();
                    string paramName = $":{ToOtherSystemInfoEntity.FIELD_REQUESTTYPE}{i}";
                    paramNames.Add(paramName);

                    param.ParameterName = ToOtherSystemInfoEntity.FIELD_REQUESTTYPE + i;
                    param.Value = rtype;
                    command.Parameters.Add(param);

                    i++;
                }

                param = command.CreateParameter();
                param.SetInputInt32(ToOtherSystemInfoEntity.FIELD_SYSTENO, systemno);
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.SetInputInt32(PARAM_RECORDCOUNT, recordcount);
                command.Parameters.Add(param);

                #endregion

                string query = null;
                IDataReader reader = null;

                try
                {

                    ToOtherSystemInfo target = null;
                    List<ToOtherSystemInfo> list = new List<ToOtherSystemInfo>();

                    query = queryParts.Replace("{RTYPEVAL}", string.Join(", ", paramNames));
                    command.CommandText = query;

                    MiscUtils.WriteDbCommandLogForLog4net(command, _log);

                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        target = new ToOtherSystemInfo();

                        target.requestid = reader.GetStringByDBInt32(ToOtherSystemInfoEntity.FIELD_REQUESTID);
                        target.ris_id = reader.GetStringByDBString(ToOtherSystemInfoEntity.FIELD_RIS_ID);
                        list.Add(target);
                    }

                    ToOtherSystemInfo[] ToOtherSystemInfoArray = list.ToArray();

                    if (ToOtherSystemInfoArray.Length < 1)
                    {
                        ToOtherSystemInfoArray = null;
                    }

                    return ToOtherSystemInfoArray;
                }
                finally
                {
                    if (reader != null)
                    {
                        reader.Close();
                    }
                }
            }
        }

        public static XmlOutPutData[] GetDataXmlOutPutData(IDbConnection cnRISDB, string ris_id)
        {
            const string queryParts =
                "SELECT" +
                "  EM.RIS_ID" +
                "  , PI.KANJA_ID" +
                "  , PI.KANJISIMEI" +
                "  , PI.KANASIMEI" +
                "  , PI.ROMASIMEI" +
                "  , PI.BIRTHDAY" +
                "  , PI.SEX" +
                "  , PI.BLOOD" +
                "  , TRUNC(PI.TALL, 1) as TALL " +
                "  , PI.WEIGHT" +
                "  , PI.JUSYO1" +
                "  , PI.INFECTION" +
                "  , DECODE(PI.INFECTIONMARK, 1, '+', '-') AS INFECTIONMARK" +
                "  , PI.CONTRAINDICATION" +
                "  , DECODE(PI.CONTRAINDICATIONMARK, 1, '+', '-') AS CONTRAINDICATIONMARK" +
                "  , EM.ENDCOUNT" +
                "  , OM.ACCESSIONNO" +
                "  , SM.SECTION_NAME" +
                "  , OM.IRAI_SECTION_ID" +
                "  , KTM.KENSATYPE_NAME" +
                "  , OM.IRAI_DOCTOR_NAME" +
                "  , OM.IRAI_DOCTOR_NO" +
                "  , PI.KANJA_NYUGAIKBN" +
                "  , BTM.BYOUTOU_NAME" +
                "  , PI.BYOUTOU_ID" +
                "  , OI.RINSYOU" +
                "  , OI.KENSA_SIJI" +
                "  , OI.ORDERCOMMENT_ID" +
                "  , DECODE(EO.SIKYU_FLG, 1, '1', NULL) AS SIKYU_FLG" +
                "  , BM.BUI_NAME" +
                "  , EB.BUI_ID" +
                "  , EM.KENSA_DATE" +
                "  , TO_CHAR(EM.EXAMSTARTDATE, 'hh24:mi:ss') as EXAMSTARTDATE" +
                "  , TO_CHAR(EM.EXAMENDDATE, 'hh24:mi:ss') as EXAMENDDATE" +
                "  , KTM.MODALITY" +
                "  , OM.KENSATYPE_ID" +
                "  , HM.HOUKOU_NAME" +
                "  , EB.HOUKOU_ID" +
                "  , OM.STUDYINSTANCEUID" +
                "  , EM.BIKOU" +
                " FROM" +
                "   EXMAINTABLE EM " +
                "   LEFT JOIN ORDERMAINTABLE OM" +
                "   ON EM.RIS_ID = OM.RIS_ID" +
                "   LEFT JOIN EXTENDORDERINFO EO" +
                "   ON EM.RIS_ID = EO.RIS_ID" +
                "   LEFT JOIN ORDERINDICATETABLE OI" +
                "   ON EM.RIS_ID = OI.RIS_ID" +
                "   LEFT JOIN PATIENTINFO PI" +
                "   ON EM.KANJA_ID = PI.KANJA_ID" +
                "   LEFT JOIN EXBUITABLE EB" +
                "   ON EM.RIS_ID = EB.RIS_ID" +
                "   AND EB.SATUEISTATUS = '1'" +
                "   LEFT JOIN SECTIONMASTER SM" +
                "   ON OM.IRAI_SECTION_ID = SM.SECTION_ID" +
                "   LEFT JOIN KENSATYPEMASTER KTM" +
                "   ON OM.KENSATYPE_ID = KTM.KENSATYPE_ID" +
                "   LEFT JOIN BYOUTOUMASTER BTM" +
                "   ON PI.BYOUTOU_ID = BTM.BYOUTOU_ID" +
                "   LEFT JOIN HOUKOUMASTER HM" +
                "   ON EB.HOUKOU_ID = HM.HOUKOU_ID" +
                "   LEFT JOIN BUIMASTER BM" +
                "   ON EB.BUI_ID = BM.BUI_ID" +
                " WHERE" +
                "  EM.RIS_ID = :ris_id " +
                "  ORDER BY EB.NO ASC, EB.BUI_ID ASC ";


            string query = queryParts;

            using (IDbCommand command = cnRISDB.CreateCommand())
            {
                command.InitCommandODP(AppConfigController.GetInstance().GetValueString(AppConfigParameter.commandTimeout).StringToInt32());
                command.CommandText = query;

                #region パラメータ設定

                command.Parameters.Clear();
                IDataParameter param = command.CreateParameter();
                param.SetInputString(XmlOutPutDataEntity.FIELD_RIS_ID, ris_id);
                command.Parameters.Add(param);

                #endregion

                IDataReader reader = null;
                XmlOutPutData target = null;

                try
                {
                    command.CommandText = query;

                    MiscUtils.WriteDbCommandLogForLog4net(command, _log);

                    reader = command.ExecuteReader();

                    target = new XmlOutPutData();
                    List<XmlOutPutData> list = new List<XmlOutPutData>();

                    while (reader.Read())
                    {
                        target = new XmlOutPutData();

                        target.ris_id = reader.GetStringByDBString(XmlOutPutDataEntity.FIELD_RIS_ID);
                        target.kanja_id = reader.GetStringByDBString(XmlOutPutDataEntity.FIELD_KANJA_ID);
                        target.kanjisimei = reader.GetStringByDBString(XmlOutPutDataEntity.FIELD_KANJISIMEI);
                        target.kanasimei = reader.GetStringByDBString(XmlOutPutDataEntity.FIELD_KANASIMEI);
                        target.romasimei = reader.GetStringByDBString(XmlOutPutDataEntity.FIELD_ROMASIMEI);
                        target.birthday = reader.GetStringByDBInt32(XmlOutPutDataEntity.FIELD_BIRTHDAY);
                        target.sex = reader.GetStringByDBString(XmlOutPutDataEntity.FIELD_SEX);
                        target.blood = reader.GetStringByDBString(XmlOutPutDataEntity.FIELD_BLOOD);
                        target.tall = reader.GetStringByDBDecimal(XmlOutPutDataEntity.FIELD_TALL);
                        target.weight = reader.GetStringByDBDecimal(XmlOutPutDataEntity.FIELD_WEIGHT);
                        target.jusyo1 = reader.GetStringByDBString(XmlOutPutDataEntity.FIELD_JUSYO1);
                        target.infection = reader.GetStringByDBString(XmlOutPutDataEntity.FIELD_INFECTION);
                        target.infectionmark = reader.GetStringByDBString(XmlOutPutDataEntity.FIELD_INFECTIONMARK);
                        target.contraindication = reader.GetStringByDBString(XmlOutPutDataEntity.FIELD_CONTRAINDICATION);
                        target.contraindicationmark = reader.GetStringByDBString(XmlOutPutDataEntity.FIELD_CONTRAINDICATIONMARK);
                        target.endcount = reader.GetStringByDBInt32(XmlOutPutDataEntity.FIELD_ENDCOUNT);
                        target.accessionno = reader.GetStringByDBString(XmlOutPutDataEntity.FIELD_ACCESSIONNO);
                        target.section_name = reader.GetStringByDBString(XmlOutPutDataEntity.FIELD_SECTION_NAME);
                        target.irai_section_id = reader.GetStringByDBString(XmlOutPutDataEntity.FIELD_IRAI_SECTION_ID);
                        target.kensatype_name = reader.GetStringByDBString(XmlOutPutDataEntity.FIELD_KENSATYPE_NAME);
                        target.kensatype_id = reader.GetStringByDBString(XmlOutPutDataEntity.FIELD_KENSATYPE_ID);
                        target.irai_doctor_name = reader.GetStringByDBString(XmlOutPutDataEntity.FIELD_IRAI_DOCTOR_NAME);
                        target.irai_doctor_no = reader.GetStringByDBString(XmlOutPutDataEntity.FIELD_IRAI_DOCTOR_NO);
                        target.kanja_nyugaikbn = reader.GetStringByDBString(XmlOutPutDataEntity.FIELD_KANJA_NYUGAIKBN);
                        target.byoutou_name = reader.GetStringByDBString(XmlOutPutDataEntity.FIELD_BYOUTOU_NAME);
                        target.byoutou_id = reader.GetStringByDBString(XmlOutPutDataEntity.FIELD_BYOUTOU_ID);
                        target.rinsyou = reader.GetStringByDBString(XmlOutPutDataEntity.FIELD_RINSYOU);
                        target.kensa_siji = reader.GetStringByDBString(XmlOutPutDataEntity.FIELD_KENSA_SIJI);
                        target.ordercomment_id = reader.GetStringByDBString(XmlOutPutDataEntity.FIELD_ORDERCOMMENT_ID);
                        target.sikyu_flg = reader.GetStringByDBString(XmlOutPutDataEntity.FIELD_SIKYU_FLG);
                        target.bui_name = reader.GetStringByDBString(XmlOutPutDataEntity.FIELD_BUI_NAME);
                        target.bui_id = reader.GetStringByDBString(XmlOutPutDataEntity.FIELD_BUI_ID);
                        target.kensa_date = reader.GetStringByDBInt32(XmlOutPutDataEntity.FIELD_KENSA_DATE);
                        target.examstartdate = reader.GetStringByDBString(XmlOutPutDataEntity.FIELD_EXAMSTARTDATE);
                        target.examenddate = reader.GetStringByDBString(XmlOutPutDataEntity.FIELD_EXAMENDDATE);
                        target.modality = reader.GetStringByDBString(XmlOutPutDataEntity.FIELD_MODALITY);
                        target.houkou_name = reader.GetStringByDBString(XmlOutPutDataEntity.FIELD_HOUKOU_NAME);
                        target.houkou_id = reader.GetStringByDBString(XmlOutPutDataEntity.FIELD_HOUKOU_ID);
                        target.studyinstanceuid = reader.GetStringByDBString(XmlOutPutDataEntity.FIELD_STUDYINSTANCEUID);
                        target.bikou = reader.GetStringByDBString(XmlOutPutDataEntity.FIELD_BIKOU);
                        list.Add(target);
                    }

                    XmlOutPutData[] xmlOutPutDataArray = list.ToArray();

                    if (xmlOutPutDataArray.Length < 1)
                    {
                        xmlOutPutDataArray = null;
                    }

                    return xmlOutPutDataArray;
                }
                finally
                {
                    reader.Close();
                }
            }
        }

        #endregion

        // TOOTHERSYSTEMINFOのキュー更新
        public static void UpdateToOtherSystemInfo(IDbConnection cnRISDB, string requestid, string ris_id, string resultText, string status, string result)
        {
            const string queryParts =
                "UPDATE " +
                    "TOOTHERSYSTEMINFO " +
                "SET " +
                    "TRANSFERSTATUS = :transferstatus, " +
                    "TRANSFERDATE = SYSDATE, " +
                    "TRANSFERRESULT = :transferresult, " +
                    "TRANSFERTEXT = :transfertext " +
                "WHERE " +
                    "requestid = :requestid " +
                "AND " +
                    "ris_id = :ris_id ";
            try
            {
                using (IDbCommand command = cnRISDB.CreateCommand())
                {
                    command.InitCommandODP(AppConfigController.GetInstance().GetValueString(AppConfigParameter.commandTimeout).StringToInt32());
                    command.CommandText = queryParts;

                    #region パラメータ設定
                    command.Parameters.Clear();
                    IDataParameter param = command.CreateParameter();
                    param.SetInputString(ToOtherSystemInfoEntity.FIELD_REQUESTID, requestid);
                    command.Parameters.Add(param);

                    param = command.CreateParameter();
                    param.SetInputString(ToOtherSystemInfoEntity.FIELD_RIS_ID, ris_id);
                    command.Parameters.Add(param);

                    param = command.CreateParameter();
                    param.SetInputString(ToOtherSystemInfoEntity.FIELD_TRANSFERSTATUS, status);
                    command.Parameters.Add(param);

                    param = command.CreateParameter();
                    param.SetInputString(ToOtherSystemInfoEntity.FIELD_TRANSFERRESULT, result);
                    command.Parameters.Add(param);

                    param = command.CreateParameter();
                    param.SetInputString(ToOtherSystemInfoEntity.FIELD_TRANSFERTEXT, resultText);
                    command.Parameters.Add(param);

                    #endregion

                    MiscUtils.WriteDbCommandLogForLog4net(command, _log);
                    _log.Debug("ToOtherSystemInfoテーブル更新します。");

                    command.ExecuteNonQuery();

                    _log.Debug("ToOtherSystemInfoテーブル更新しました。");

                }
            }
            catch (OracleException oex)
            {
                _log.Debug("ToOtherSystemInfoテーブル更新時にエラーが発生しました。");
                throw oex;
            }
            catch (Exception e)
            {
                _log.Debug("ToOtherSsystemInfoテーブル更新時にエラーが発生しました。");
                throw e;
            }
        }
    }
}
