using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorNetIFService.Data
{
    class ToOtherSystemInfoEntity
    {
        #region 項目名(ToOtherSystemInfo)
        public const string FIELD_REQUESTID = "requestid";
        public const string FIELD_RIS_ID= "ris_id";
        public const string FIELD_REQUESTTYPE = "requesttype";
        public const string FIELD_SYSTENO = "systemno";
        public const string FIELD_TRANSFERSTATUS = "transferstatus";
        public const string FIELD_TRANSFERRESULT = "transferresult";
        public const string FIELD_TRANSFERTEXT = "transfertext";
        #endregion
    }

    internal class ToOtherSystemInfo
    {
        public string requestid
        {
            get;
            set;
        }
        public string ris_id
        {
            get;
            set;
        }
    }
}
