using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReportModel.Common;

namespace ReportModel
{
    public class WorkLog
    {
        public int Id { get; set; }

        public string Action { get; set; }

        public EntityInfo EntityInfo { get; set; }

        public string RelatedData { get; set; }

        public string LogInfo { get; set; }

        public string OriginalData { get; set; }

        public string ModifiedData { get; set; }
    }
}
