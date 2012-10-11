using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportModel.Common
{
    [Serializable]
    public class EntityInfo
    {
        public string CrUser { set; get; }
        public DateTime CrTime { set; get; }
        public DateTime LastModified { set; get; }

        public string CrDayStr
        {
            get
            {
                return CrTime.ToDayStr();
            }
        }

        public string CrTimeStr
        {
            get
            {
                return CrTime.ToTimeStr();
            }
        }

        public string CrFullStr
        {
            get
            {
                return CrTime.ToFullStr();
            }
        }

        public string LastModifiedDay
        {
            get
            {
                return LastModified.ToDayStr();
            }
        }

        public string LastModifiedFullStr
        {
            get
            {
                return LastModified.ToFullStr();
            }
        }

        public static EntityInfo Get(string username)
        {
            var now = DateTime.Now;
            return new EntityInfo()
            {
                CrUser = username,
                CrTime = now,
                LastModified = now
            };
        }
    }
}
