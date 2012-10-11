using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportModel
{
    public class ShortOverReport
    {
        public ShortOverReport()
        {
            ReportDate = DateTime.Now.ToString("yyyy-MM-dd");
        }

        public string ReportDate { get; set; }

        public int ShortOverTimes { get; set; }

        public int ChargeTimes { get; set; }

        public decimal ShortOverAmount { get; set; }

        public int StationID { get; set; }

        public int CrUser { get; set; }

    }
}
