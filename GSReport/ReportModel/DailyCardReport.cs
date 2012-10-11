using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportModel
{
    public class DailyCardReport
    {
        public DailyCardReport()
        {
            ReportDate = DateTime.Now.ToString("yyyy-MM-dd");
        }

        public string ReportDate { get; set; }

        public int SentCards { get; set; }

        public int WrongCards { get; set; }

        public int ReceivedCards { get; set; }

        public int BrokenCards { get; set; }

        public int CrUser { get; set; }

        public int StationID { get; set; }

        public int CollectionClassID { get; set; }

        public string CollectionClassName { get; set; }
    }

    public class MonthCardReport
    {
        public string StationName { get; set; }

        public int SentCards { get; set; }

        public int WrongCards { get; set; }

        public int ReceivedCards { get; set; }

        public int BrokenCards { get; set; }

        public int StationID { get; set; }
    }
}
