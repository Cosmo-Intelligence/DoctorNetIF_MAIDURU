using DoctorNetIFService.Data;
using Oracle.DataAccess.Client;
using RISCommonLibrary.Lib.Utils;
using RISReportService.util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace DoctorNetIFService.Model
{
    internal class TableInfoManager
    {
        #region const

        #region 更新するステータスの値

        public const string TRANSFERSTATUS_OK = "01";
        public const string TRANSFERSTATUS_NG = "02";
        public const string TRANSFERRESULT_OK = "OK";
        public const string TRANSFERRESULT_NG = "NG";

        #endregion

        #endregion

        #region field

        /// <summary>
        /// ログ
        /// </summary>
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(
            System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region 初期処理

        #endregion

        #region 実行
        /// <summary>
        /// 処理実行
        /// </summary>
        /// <param name="cnRISDB">接続情報(RIS)</param>
        /// <param name="toOtherSystemInfo">ToOtherSystemInfoの取得データ(1件分)</param>
        /// <returns>検索結果の一覧</returns>
        public void Execute(IDbConnection cnRISDB, ToOtherSystemInfo toOtherSystemInfo)
        {

            // 出力先パス(設定ファイル値)
            string outPutDirPath = AppConfigController.GetInstance().GetValueString(AppConfigParameter.outputFolder);
            // ファイル出力時のみエラーで落としたいので、ここだけフラグで管理する。
            bool saveFileFlg = true;
            try
            {
                // ToOtherSystemInfoの対象データのRIS_IDを条件にXML出力用のデータを取得する。
                DbContentBuilder dbContent = ExeSelectDb(cnRISDB, toOtherSystemInfo);

                if (dbContent == null)
                {
                    _log.Fatal("XML出力用データに該当するレコードがありませんでした。RIS_ID = " + toOtherSystemInfo.ris_id);

                    // ToOtherSystemInfoの更新する値をセット(異常終了時)
                    TableInfoHelper.UpdateToOtherSystemInfo(cnRISDB, toOtherSystemInfo.requestid, toOtherSystemInfo.ris_id, null, TRANSFERSTATUS_NG, TRANSFERRESULT_NG);
                    return;
                }         

                string strDateTime = DateTime.Now.ToString("yyyyMMddHHmm");
                XmlOutPutData[] xmlOutPutDataArray = dbContent.xmlOutPutDataArray;
                // XMLファイル名
                string xmlFileName = SetXmlFileName(strDateTime, xmlOutPutDataArray);

                // XMLファイルの内容作成
                XmlDocument xmlDoc = CreateXML(dbContent);

                try { 
                    // XML、datファイルの保存
                    SaveTargetFile(xmlDoc, xmlFileName);
                }
                catch (Exception ex)
                {
                    saveFileFlg = false;
                    throw ex;
                }

                // ToOtherSystemInfoの更新(正常終了時)
                TableInfoHelper.UpdateToOtherSystemInfo(cnRISDB, toOtherSystemInfo.requestid, toOtherSystemInfo.ris_id, xmlFileName + ".xml", TRANSFERSTATUS_OK, TRANSFERRESULT_OK);

            }
            catch (Exception ex)
            {
                if (!saveFileFlg)
                {
                    _log.Error("ファイル作成に失敗しました。");
                    throw ex;
                }
                else
                {
                    string errMessage = MiscUtils.BuildErrMessage(ex, null);
                    _log.ErrorFormat("エラーが発生しました。{0}", errMessage);
                    TableInfoHelper.UpdateToOtherSystemInfo(cnRISDB, toOtherSystemInfo.requestid, toOtherSystemInfo.ris_id, null, TRANSFERSTATUS_NG, TRANSFERRESULT_NG);

                }
            }
        }

        #endregion

        #region DB検索

        /// <summary>
        /// DB検索
        /// </summary>
        /// <param name="cnRISDB">接続情報(RIS)</param>
        /// <param name="toOtherSystemInfo">ToOtherSystemInfoの取得データ(1件分)</param>
        /// <returns>検索結果の一覧</returns>
        private DbContentBuilder ExeSelectDb
            (IDbConnection cnRISDB, ToOtherSystemInfo toOtherSystemInfo)
        {
            DbContentBuilder dbContent = null;

            try
            {
                string ris_id = toOtherSystemInfo.ris_id;

                #region XML出力情報(XmlOutPutData)

                XmlOutPutData[] xmlOutPutDataArray = null;

                try
                {
                    xmlOutPutDataArray = TableInfoHelper.GetDataXmlOutPutData(cnRISDB, ris_id);
                }
                catch (Exception)
                {
                    throw;
                }

                if (xmlOutPutDataArray == null)
                {
                    return null;
                }

                #endregion

                // Builderクラスにまとめる
                dbContent = new DbContentBuilder(
                    toOtherSystemInfo
                    , xmlOutPutDataArray);

                return dbContent;
            }
            catch (Exception)
            {
                _log.Error("XML出力用データ取得でエラーが発生しました。");
                throw;
            }
        }

        #endregion

        #region XMLファイル作成

        /// <summary>
        /// 出力内容の作成
        /// </summary>
        /// <param name="dbContent">DB検索結果</param>
        /// <returns></returns>
        private XmlDocument CreateXML(DbContentBuilder dbContent)
        {
            XmlOutPutData[] xopdataArray = dbContent.xmlOutPutDataArray;

            XmlDocument xmlDoc = new XmlDocument();
            // DiagnosticRequest(ルート要素)
            XmlElement kml = CreateElement(xmlDoc, "DiagnosticRequest");
            xmlDoc.AppendChild(kml);

            // PatientInfo(患者情報)
            XmlElement patientinfo = CreateElement(xmlDoc, "PatientInfo");
            kml.AppendChild(patientinfo);

            // PatientID(患者ID)
            XmlElement patientID = CreateElement(xmlDoc, "PatientID");
            patientinfo.AppendChild(patientID);
            AddNodeValue(xmlDoc, patientID, xopdataArray[0].kanja_id);

            // PatientName(患者名)
            XmlElement patientName = CreateElement(xmlDoc, "PatientName");
            patientinfo.AppendChild(patientName);
            AddNodeValue(xmlDoc, patientName, xopdataArray[0].kanjisimei);

            // PatientNameKana(患者名(カナ))
            XmlElement patientNameKana = CreateElement(xmlDoc, "PatientNameKana");
            patientinfo.AppendChild(patientNameKana);
            AddNodeValue(xmlDoc, patientNameKana, xopdataArray[0].kanasimei);

            // PatientNameRoman(患者名(英字))
            XmlElement patientNameRoman = CreateElement(xmlDoc, "PatientNameRoman");
            patientinfo.AppendChild(patientNameRoman);
            AddNodeValue(xmlDoc, patientNameRoman, xopdataArray[0].romasimei);

            // BirthDate(生年月日)
            XmlElement birthDate = CreateElement(xmlDoc, "BirthDate");
            patientinfo.AppendChild(birthDate);
            AddNodeValue(xmlDoc, birthDate, ConvertDateFormatStr(xopdataArray[0].birthday));

            // Sex(性別)
            XmlElement sex = CreateElement(xmlDoc, "Sex");
            patientinfo.AppendChild(sex);
            AddNodeValue(xmlDoc, sex, xopdataArray[0].sex);

            // BloodType(血液型)
            XmlElement bloodType = CreateElement(xmlDoc, "BloodType");
            patientinfo.AppendChild(bloodType);
            AddNodeValue(xmlDoc, bloodType, xopdataArray[0].blood);

            // Height(身長)
            XmlElement height = CreateElement(xmlDoc, "Height");
            patientinfo.AppendChild(height);
            AddNodeValue(xmlDoc, height, xopdataArray[0].tall);

            // Weight(体重)
            XmlElement weight = CreateElement(xmlDoc, "Weight");
            patientinfo.AppendChild(weight);
            AddNodeValue(xmlDoc, weight, xopdataArray[0].weight);

            // ZipCode(郵便番号)
            XmlElement zipCode = CreateElement(xmlDoc, "ZipCode");
            patientinfo.AppendChild(zipCode);
            AddNodeValue(xmlDoc, zipCode, "");

            // Address(住所)
            XmlElement address = CreateElement(xmlDoc, "Address");
            patientinfo.AppendChild(address);
            AddNodeValue(xmlDoc, address, xopdataArray[0].jusyo1);

            // Telephone(電話番号)
            XmlElement telephone = CreateElement(xmlDoc, "Telephone");
            patientinfo.AppendChild(telephone);
            AddNodeValue(xmlDoc, telephone, "");

            // MobileTelephone(携帯番号)
            XmlElement mobileTelephone = CreateElement(xmlDoc, "MobileTelephone");
            patientinfo.AppendChild(mobileTelephone);
            AddNodeValue(xmlDoc, mobileTelephone, "");

            // email(Eメールアドレス)
            XmlElement email = CreateElement(xmlDoc, "email");
            patientinfo.AppendChild(email);
            AddNodeValue(xmlDoc, email, "");

            // Comment(患者用コメント)
            XmlElement pComment = CreateElement(xmlDoc, "Comment");
            patientinfo.AppendChild(pComment);
            AddNodeValue(xmlDoc, pComment, "");

            // InfectionCollection(感染症情報)
            XmlElement infectionCollection = CreateElement(xmlDoc, "InfectionCollection");
            patientinfo.AppendChild(infectionCollection);

            // Infection(感染症情報)
            XmlElement infection = CreateElement(xmlDoc, "Infection");
            infectionCollection.AppendChild(infection);

            // Name(感染症名)
            XmlElement infectionName = CreateElement(xmlDoc, "Name");
            infection.AppendChild(infectionName);
            AddNodeValue(xmlDoc, infectionName, xopdataArray[0].infection);

            // Value(パラメータ)
            XmlElement infectionValue = CreateElement(xmlDoc, "Value");
            infection.AppendChild(infectionValue);
            AddNodeValue(xmlDoc, infectionValue, xopdataArray[0].infectionmark);

            // ContraindicationCollection(禁忌情報)
            XmlElement contraindicationCollection = CreateElement(xmlDoc, "ContraindicationCollection");
            patientinfo.AppendChild(contraindicationCollection);

            // Contraindication(禁忌情報)
            XmlElement contraindication = CreateElement(xmlDoc, "Contraindication");
            contraindicationCollection.AppendChild(contraindication);

            // Name(禁忌名)
            XmlElement contraindicationName = CreateElement(xmlDoc, "Name");
            contraindication.AppendChild(contraindicationName);
            AddNodeValue(xmlDoc, contraindicationName, xopdataArray[0].contraindication);

            // Value(パラメータ)
            XmlElement contraindicationValue = CreateElement(xmlDoc, "Value");
            contraindication.AppendChild(contraindicationValue);
            AddNodeValue(xmlDoc, contraindicationValue, xopdataArray[0].contraindicationmark);

            // AnamnesisCollection(既往歴情報)
            XmlElement anamnesisCollection = CreateElement(xmlDoc, "AnamnesisCollection");
            patientinfo.AppendChild(anamnesisCollection);

            // Anamnesis(既往歴情報)
            XmlElement anamnesis = CreateElement(xmlDoc, "Anamnesis");
            anamnesisCollection.AppendChild(anamnesis);

            // Name(病名)
            XmlElement anamnesisName = CreateElement(xmlDoc, "Name");
            anamnesis.AppendChild(anamnesisName);
            AddNodeValue(xmlDoc, anamnesisName, "");

            // Value(罹患日または診断日)
            XmlElement anamnesisValue = CreateElement(xmlDoc, "Value");
            anamnesis.AppendChild(anamnesisValue);
            AddNodeValue(xmlDoc, anamnesisValue, "");

            // Status(状態（罹患中or完治）)
            XmlElement anamnesisStatus = CreateElement(xmlDoc, "Status");
            anamnesis.AppendChild(anamnesisStatus);
            AddNodeValue(xmlDoc, anamnesisStatus, "");

            // PrescriptionCollection(処方情報)
            XmlElement prescriptionCollection = CreateElement(xmlDoc, "PrescriptionCollection");
            patientinfo.AppendChild(prescriptionCollection);

            // Prescription(処方情報)
            XmlElement prescription = CreateElement(xmlDoc, "Prescription");
            prescriptionCollection.AppendChild(prescription);

            // Name(処方名)
            XmlElement prescriptionName = CreateElement(xmlDoc, "Name");
            prescription.AppendChild(prescriptionName);
            AddNodeValue(xmlDoc, prescriptionName, "");

            // Quantity(量)
            XmlElement prescriptionQuantity = CreateElement(xmlDoc, "Quantity");
            prescription.AppendChild(prescriptionQuantity);
            AddNodeValue(xmlDoc, prescriptionQuantity, "");

            // Status(単位)
            XmlElement prescriptionUnit = CreateElement(xmlDoc, "Unit");
            prescription.AppendChild(prescriptionUnit);
            AddNodeValue(xmlDoc, prescriptionUnit, "");

            // OrderInfo(依頼情報)
            XmlElement orderInfo = CreateElement(xmlDoc, "OrderInfo");
            kml.AppendChild(orderInfo);

            // Revision(版数)
            XmlElement revision = CreateElement(xmlDoc, "Revision");
            orderInfo.AppendChild(revision);
            AddNodeValue(xmlDoc, revision, xopdataArray[0].endcount);

            // OrderNumber(オーダ番号(AccessionNo.))
            XmlElement orderNumber = CreateElement(xmlDoc, "OrderNumber");
            orderInfo.AppendChild(orderNumber);
            AddNodeValue(xmlDoc, orderNumber, xopdataArray[0].accessionno);

            // Institution(依頼元施設名)
            XmlElement institution = CreateElement(xmlDoc, "Institution");
            orderInfo.AppendChild(institution);
            AddNodeValue(xmlDoc, institution, "");

            // Department(依頼科名)
            XmlElement department = CreateElement(xmlDoc, "Department");    
            if (!string.IsNullOrEmpty(xopdataArray[0].irai_section_id))
            {
                department.SetAttribute("code", xopdataArray[0].irai_section_id);
            }
            orderInfo.AppendChild(department);
            AddNodeValue(xmlDoc, department, xopdataArray[0].section_name);

            // OrderKind(依頼区分)
            XmlElement orderKind = CreateElement(xmlDoc, "OrderKind");
            if (!string.IsNullOrEmpty(xopdataArray[0].kensatype_id))
            {
                orderKind.SetAttribute("code", xopdataArray[0].kensatype_id);
            }
            orderInfo.AppendChild(orderKind);
            AddNodeValue(xmlDoc, orderKind, xopdataArray[0].kensatype_name);

            // RequestDoctor(依頼医名)
            XmlElement requestDoctor = CreateElement(xmlDoc, "RequestDoctor");
            if (!string.IsNullOrEmpty(xopdataArray[0].irai_doctor_no))
            {
                requestDoctor.SetAttribute("code", xopdataArray[0].irai_doctor_no);
            }
            orderInfo.AppendChild(requestDoctor);
            AddNodeValue(xmlDoc, requestDoctor, xopdataArray[0].irai_doctor_name);

            // Hospitalization(入院/外来区分)
            XmlElement hospitalization = CreateElement(xmlDoc, "Hospitalization");
            orderInfo.AppendChild(hospitalization);
            AddNodeValue(xmlDoc, hospitalization, xopdataArray[0].kanja_nyugaikbn);

            // Ward(病棟名)
            XmlElement ward = CreateElement(xmlDoc, "Ward");
            if (!string.IsNullOrEmpty(xopdataArray[0].byoutou_id))
            {
                ward.SetAttribute("code", xopdataArray[0].byoutou_id);
            }
            orderInfo.AppendChild(ward);
            AddNodeValue(xmlDoc, ward, xopdataArray[0].byoutou_name);

            // IntroductionInstitution(紹介依頼元施設名)
            XmlElement introductionInstitution = CreateElement(xmlDoc, "IntroductionInstitution");
            orderInfo.AppendChild(introductionInstitution);
            AddNodeValue(xmlDoc, introductionInstitution, "");

            // Disease(病名)
            XmlElement disease = CreateElement(xmlDoc, "Disease");
            orderInfo.AppendChild(disease);
            AddNodeValue(xmlDoc, disease, xopdataArray[0].rinsyou);

            // Purpose(検査目的)
            XmlElement purpose = CreateElement(xmlDoc, "Purpose");
            orderInfo.AppendChild(purpose);
            AddNodeValue(xmlDoc, purpose, xopdataArray[0].kensa_siji);

            // TreatmentProgress(治癒経過)
            XmlElement treatmentProgress = CreateElement(xmlDoc, "TreatmentProgress");
            orderInfo.AppendChild(treatmentProgress);
            AddNodeValue(xmlDoc, treatmentProgress, "");

            // Comment(依頼時コメント)
            XmlElement oComment = CreateElement(xmlDoc, "Comment");
            orderInfo.AppendChild(oComment);
            AddNodeValue(xmlDoc, oComment, xopdataArray[0].ordercomment_id);

            // OrderType(読影オーダ種別)
            XmlElement orderType = CreateElement(xmlDoc, "OrderType");
            orderInfo.AppendChild(orderType);
            AddNodeValue(xmlDoc, orderType, xopdataArray[0].sikyu_flg);

            // SpecifiedDoctor(指定読影医名)
            XmlElement specifiedDoctor = CreateElement(xmlDoc, "SpecifiedDoctor");
            orderInfo.AppendChild(specifiedDoctor);
            AddNodeValue(xmlDoc, specifiedDoctor, "");

            // BodyPartCollection(読影依頼部位情報)
            XmlElement oBodyPartCollection = CreateElement(xmlDoc, "BodyPartCollection");
            orderInfo.AppendChild(oBodyPartCollection);

            for (int i = 0; i < xopdataArray.Length; i++)
            {
                // BodyPart(部位名)
                XmlElement oBodyPart = CreateElement(xmlDoc, "BodyPart");
                if (!string.IsNullOrEmpty(xopdataArray[i].bui_id))
                {
                    oBodyPart.SetAttribute("code", xopdataArray[i].bui_id);
                }
                oBodyPartCollection.AppendChild(oBodyPart);
                AddNodeValue(xmlDoc, oBodyPart, xopdataArray[i].bui_name);
            }

            // OrderFileCollection(依頼書ファイル情報)
            XmlElement orderFileCollection = CreateElement(xmlDoc, "OrderFileCollection");
            orderInfo.AppendChild(orderFileCollection);

            // OrderFile(依頼書ファイル名)
            XmlElement orderFile = CreateElement(xmlDoc, "OrderFile");
            orderFileCollection.AppendChild(orderFile);
            AddNodeValue(xmlDoc, orderFile, "");

            // KeyImageFileCollection(キー画像ファイル情報)
            XmlElement keyImageFileCollection = CreateElement(xmlDoc, "KeyImageFileCollection");
            orderInfo.AppendChild(keyImageFileCollection);

            // KeyImageFile(キー画像ファイル名)
            XmlElement keyImageFile = CreateElement(xmlDoc, "KeyImageFile");
            keyImageFileCollection.AppendChild(keyImageFile);
            AddNodeValue(xmlDoc, keyImageFile, "");

            // SchemaImageFileCollection(シェーマ画像ファイル情報)
            XmlElement schemaImageFileCollection = CreateElement(xmlDoc, "SchemaImageFileCollection");
            orderInfo.AppendChild(schemaImageFileCollection);

            // SchemaImageFile(シェーマ画像ファイル名)
            XmlElement schemaImageFile = CreateElement(xmlDoc, "SchemaImageFile");
            schemaImageFileCollection.AppendChild(schemaImageFile);
            AddNodeValue(xmlDoc, schemaImageFile, "");

            // StudyInfo(検査情報)
            XmlElement studyInfo = CreateElement(xmlDoc, "StudyInfo");
            kml.AppendChild(studyInfo);

            // StudyDate(検査日)
            XmlElement studyDate = CreateElement(xmlDoc, "StudyDate");
            studyInfo.AppendChild(studyDate);
            AddNodeValue(xmlDoc, studyDate, ConvertDateFormatStr(xopdataArray[0].kensa_date));

            // StudyTimeStart(検査開始時間)
            XmlElement studyTimeStart = CreateElement(xmlDoc, "StudyTimeStart");
            studyInfo.AppendChild(studyTimeStart);
            AddNodeValue(xmlDoc, studyTimeStart, xopdataArray[0].examstartdate);

            // StudyTimeEnd(検査終了時間)
            XmlElement studyTimeEnd = CreateElement(xmlDoc, "StudyTimeEnd");
            studyInfo.AppendChild(studyTimeEnd);
            AddNodeValue(xmlDoc, studyTimeEnd, xopdataArray[0].examenddate);

            // Modality(モダリティ)
            XmlElement modality = CreateElement(xmlDoc, "Modality");
            studyInfo.AppendChild(modality);
            AddNodeValue(xmlDoc, modality, xopdataArray[0].modality);

            // StudyType(検査種別)
            XmlElement studyType = CreateElement(xmlDoc, "StudyType");
            if (!string.IsNullOrEmpty(xopdataArray[0].kensatype_id))
            {
                studyType.SetAttribute("code", xopdataArray[0].kensatype_id);
            }
            studyInfo.AppendChild(studyType);
            AddNodeValue(xmlDoc, studyType, xopdataArray[0].kensatype_name);

            // Direction(撮影方向)
            XmlElement direction = CreateElement(xmlDoc, "Direction");
            if (!string.IsNullOrEmpty(xopdataArray[0].kensatype_id))
            {
                direction.SetAttribute("code", xopdataArray[0].houkou_id);
            }
            studyInfo.AppendChild(direction);
            AddNodeValue(xmlDoc, direction, xopdataArray[0].houkou_name);


            // BodyPartCollection(検査部位情報)
            XmlElement sBodyPartCollection = CreateElement(xmlDoc, "BodyPartCollection");
            studyInfo.AppendChild(sBodyPartCollection);

            // BodyPart(検査部位名)
            XmlElement sBodyPart = CreateElement(xmlDoc, "BodyPart");
            if (!string.IsNullOrEmpty(xopdataArray[0].kensatype_id))
            {
                sBodyPart.SetAttribute("code", xopdataArray[0].bui_id);
            }
            sBodyPartCollection.AppendChild(sBodyPart);
            AddNodeValue(xmlDoc, sBodyPart, xopdataArray[0].bui_name);

            // ContrastCollection(造影剤情報)
            XmlElement contrastCollection = CreateElement(xmlDoc, "ContrastCollection");
            studyInfo.AppendChild(contrastCollection);

            // Contrast(造影剤名)
            XmlElement contrast = CreateElement(xmlDoc, "Contrast");
            contrastCollection.AppendChild(contrast);
            AddNodeValue(xmlDoc, contrast, "");

            // StudyInstanceUID(検査インスタンスUID)
            XmlElement studyInstanceUID = CreateElement(xmlDoc, "StudyInstanceUID");
            studyInfo.AppendChild(studyInstanceUID);
            AddNodeValue(xmlDoc, studyInstanceUID, xopdataArray[0].studyinstanceuid);

            // Comment(検査時コメント)
            XmlElement comment = CreateElement(xmlDoc, "Comment");
            studyInfo.AppendChild(comment);
            AddNodeValue(xmlDoc, comment, "");

            // TechnologistComment(技師コメント)
            XmlElement technologistComment = CreateElement(xmlDoc, "TechnologistComment");
            studyInfo.AppendChild(technologistComment);
            AddNodeValue(xmlDoc, technologistComment, xopdataArray[0].bikou);

            // DiagGroupId(依頼送信グループID)
            XmlElement diagGroupId = CreateElement(xmlDoc, "DiagGroupId");
            studyInfo.AppendChild(diagGroupId);
            AddNodeValue(xmlDoc, diagGroupId, "");

            return xmlDoc;
        }

        #region 値編集
        /// <summary>
        /// 日付フォーマット変換(数値(8桁)→yyyy/mm/ddに変換)
        /// </summary>
        /// <param name="numDate">数値の日付</param>
        /// <returns>yyyy/mm/dd(引数が8桁未満 or 値なしの場合はNULLで返す)</returns>
        private string ConvertDateFormatStr(string numDate)
        {
            string formattedDate = null;

            if (!string.IsNullOrEmpty(numDate))
            {
                string strDate = numDate.PadLeft(8, '0'); // 8桁に補正
                if (DateTime.TryParseExact(strDate, "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out DateTime dt))
                {
                    formattedDate = dt.ToString("yyyy/MM/dd");
                }
            }
            return formattedDate;
        }
        #endregion


        #region タグへの値追加

        /// <summary>
        /// タグへの値追加
        /// </summary>
        /// <param name="xmlDoc">作成中のXMLドキュメント</param>
        /// <param name="xmlElm">XMLの要素</param>
        /// <param name="nodeVal">要素に入れる値</param>
        private void AddNodeValue(XmlDocument xmlDoc, XmlElement xmlElm, string nodeVal)
        {
            if (!string.IsNullOrEmpty(nodeVal))
            {
                AddNode(xmlDoc, xmlElm, nodeVal);
            }
        }

        #endregion

        /// <summary>
        /// XMLファイル作成
        /// </summary>
        /// <param name="xmlDoc">XML出力内容</param>
        /// <param name="xmlFileName">出力XMLファイル名</param>
        private void SaveTargetFile(XmlDocument xmlDoc, string xmlFileName)
        {

            string outPutDirPath = AppConfigController.GetInstance().GetValueString(AppConfigParameter.outputFolder);
            string xmlFileFullPath = Path.Combine(outPutDirPath, xmlFileName + ".xml");
            string datFileFullPath = Path.Combine(outPutDirPath, xmlFileName + ".dat");

            // XML作成
            xmlDoc.Save(xmlFileFullPath);

            string addContent =
                "<?xml version=\"1.0\" encoding=\"Shift_JIS\"?>" +
                Environment.NewLine;

            // XML編集
            ExeXmlEdit(xmlFileFullPath, addContent);
            // 作成したXMLをコピーしてdatファイルを同じ場所に作成する
            File.Copy(xmlFileFullPath, datFileFullPath, overwrite: true);
        }

        #endregion

        #region レポート編集

        /// <summary>
        /// レポート編集
        /// </summary>
        /// <param name="filePath">ファイルパス</param>
        /// <param name="addContent">追記内容</param>
        private void ExeXmlEdit(string filePath, string addContent)
        {
            string content = File.ReadAllText(filePath);
            string editContent = addContent + content;

            // 追記した内容で上書き(SJIS)
            File.WriteAllText(filePath, editContent, Encoding.GetEncoding("shift_jis"));
        }

        #endregion

        #region XMLファイル名

        /// <summary>
        /// XMLファイル名の設定
        /// </summary>
        /// <param name="strDateTime">現在日時(yyyyMMddhh24mi)</param>
        /// <param name="xmlOutPutDataArray">XML出力用データリスト</param>
        /// <returns>XMLファイル名</returns>
        private string SetXmlFileName(string strDateTime, XmlOutPutData[] xmlOutPutDataArray)
        {
            string fileComName =
                xmlOutPutDataArray[0].kanja_id + "_" +
                xmlOutPutDataArray[0].kensa_date + "_" +
                xmlOutPutDataArray[0].modality + "_" +
                xmlOutPutDataArray[0].accessionno + "_" +
                strDateTime;

            return fileComName;
        }

        #endregion

        #region XML - 読み込み

        /// <summary>
        /// エレメントの設定値取得
        /// </summary>
        /// <param name="element">エレメント</param>
        /// <param name="tagname">タグ名</param>
        /// <returns>設定値</returns>
        private string GetElementValue(XElement element, string tagname)
        {
            string value = "";

            if (element.Element(tagname) != null)
            {
                value = element.Element(tagname).Value;
            }

            return value;
        }

        #endregion

        #region kmlHeader部分の追加

        #region XML - エレメント作成

        /// <summary>
        /// エレメント作成
        /// </summary>
        /// <param name="xmlDoc"></param>
        /// <param name="tagName"></param>
        /// <returns>エレメント</returns>
        private XmlElement CreateElement(XmlDocument xmlDoc, string tagName)
        {
            XmlElement element = xmlDoc.CreateElement(tagName);

            return element;
        }

         /// <summary>
        /// エレメントの紐付け
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="child"></param>
        /// <returns>エレメント</returns>
        private XmlElement AddChildElement(XmlElement parent, XmlElement child)
        {
            parent.AppendChild(child);

            return parent;
        }

        #endregion
        #endregion

        #region ノード追加

        private XmlElement AddNode(XmlDocument xmlDoc, XmlElement element, string value)
        {
            XmlNode node = xmlDoc.CreateNode(XmlNodeType.Text, "", "");
            node.Value = value;

            element.AppendChild(node);

            return element;
        }

        #endregion

    }

    #region Builderクラス

    internal class DbContentBuilder
    {
        public readonly ToOtherSystemInfo toOtherSystemInfo;
        public readonly XmlOutPutData[] xmlOutPutDataArray;

        internal DbContentBuilder
            (ToOtherSystemInfo toOtherSystemInfo
            , XmlOutPutData[] xmlOutPutDataArray)
        {
            this.toOtherSystemInfo = toOtherSystemInfo;
            this.xmlOutPutDataArray = xmlOutPutDataArray;
        }
    }

    #endregion
}