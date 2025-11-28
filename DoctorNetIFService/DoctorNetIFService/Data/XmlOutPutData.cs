using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorNetIFService.Data
{
    class XmlOutPutDataEntity
    {
        #region 項目名
        public const string FIELD_RIS_ID = "ris_id";
        public const string FIELD_KANJA_ID = "kanja_id";
        public const string FIELD_KANJISIMEI = "kanjisimei";
        public const string FIELD_KANASIMEI = "kanasimei";
        public const string FIELD_ROMASIMEI = "romasimei";
        public const string FIELD_BIRTHDAY = "birthday";
        public const string FIELD_SEX = "sex";
        public const string FIELD_BLOOD = "blood";
        public const string FIELD_TALL = "tall";
        public const string FIELD_WEIGHT = "weight";
        public const string FIELD_JUSYO1 = "jusyo1";
        public const string FIELD_INFECTION = "infection";
        public const string FIELD_INFECTIONMARK = "infectionmark";
        public const string FIELD_CONTRAINDICATION = "contraindication";
        public const string FIELD_CONTRAINDICATIONMARK = "contraindicationmark";
        public const string FIELD_ENDCOUNT = "endcount";
        public const string FIELD_ACCESSIONNO = "accessionno";
        public const string FIELD_SECTION_NAME = "section_name";
        public const string FIELD_IRAI_SECTION_ID = "irai_section_id";
        public const string FIELD_KENSATYPE_NAME = "kensatype_name";
        public const string FIELD_KENSATYPE_ID = "kensatype_id";
        public const string FIELD_IRAI_DOCTOR_NAME = "irai_doctor_name";
        public const string FIELD_IRAI_DOCTOR_NO = "irai_doctor_no";
        public const string FIELD_KANJA_NYUGAIKBN = "kanja_nyugaikbn";
        public const string FIELD_BYOUTOU_NAME = "byoutou_name";
        public const string FIELD_BYOUTOU_ID = "byoutou_id";
        public const string FIELD_RINSYOU = "rinsyou";
        public const string FIELD_KENSA_SIJI = "kensa_siji";
        public const string FIELD_ORDERCOMMENT_ID = "ordercomment_id";
        public const string FIELD_SIKYU_FLG = "sikyu_flg";
        public const string FIELD_BUI_NAME = "bui_name";
        public const string FIELD_BUI_ID = "bui_id";
        public const string FIELD_KENSA_DATE = "kensa_date";
        public const string FIELD_EXAMSTARTDATE = "examstartdate";
        public const string FIELD_EXAMENDDATE = "examenddate";
        public const string FIELD_MODALITY = "modality";
        public const string FIELD_HOUKOU_NAME = "houkou_name";
        public const string FIELD_HOUKOU_ID = "houkou_id";
        public const string FIELD_STUDYINSTANCEUID = "studyinstanceuid";
        public const string FIELD_BIKOU = "bikou";

        #endregion
    }

    internal class XmlOutPutData
    {
        public string ris_id
        {
            get;
            set;
        }
        public string kanja_id
        {
            get;
            set;
        }
        public string kanjisimei
        {
            get;
            set;
        }
        public string kanasimei
        {
            get;
            set;
        }

        public string romasimei
        {
            get;
            set;
        }
        public string birthday
        {
            get;
            set;
        }
        public string sex
        {
            get;
            set;
        }
        public string blood
        {
            get;
            set;
        }
        public string tall
        {
            get;
            set;
        }
        public string weight
        {
            get;
            set;
        }
        public string jusyo1
        {
            get;
            set;
        }
        public string infection
        {
            get;
            set;
        }
        public string infectionmark
        {
            get;
            set;
        }
        public string contraindication
        {
            get;
            set;
        }
        public string contraindicationmark
        {
            get;
            set;
        }
        public string endcount
        {
            get;
            set;
        }
        public string accessionno
        {
            get;
            set;
        }
        public string section_name
        {
            get;
            set;
        }
        public string irai_section_id
        {
            get;
            set;
        }
        public string kensatype_name
        {
            get;
            set;
        }
        public string kensatype_id
        {
            get;
            set;
        }
        public string irai_doctor_name
        {
            get;
            set;
        }
        public string irai_doctor_no
        {
            get;
            set;
        }
        public string kanja_nyugaikbn
        {
            get;
            set;
        }
        public string byoutou_name
        {
            get;
            set;
        }
        public string byoutou_id
        {
            get;
            set;
        }
        public string rinsyou
        {
            get;
            set;
        }
        public string kensa_siji
        {
            get;
            set;
        }
        public string ordercomment_id
        {
            get;
            set;
        }
        public string sikyu_flg
        {
            get;
            set;
        }
        public string bui_name
        {
            get;
            set;
        }
        public string bui_id
        {
            get;
            set;
        }
        public string kensa_date
        {
            get;
            set;
        }
        public string examstartdate
        {
            get;
            set;
        }
        public string examenddate
        {
            get;
            set;
        }
        public string modality
        {
            get;
            set;
        }
        public string houkou_name
        {
            get;
            set;
        }
        public string houkou_id
        {
            get;
            set;
        }
        public string studyinstanceuid
        {
            get;
            set;
        }
        public string bikou
        {
            get;
            set;
        }
    }
}
