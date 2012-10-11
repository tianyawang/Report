using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportModel
{
    public class SplitBillReport
    {
        public int StationID { get; set; }

        public int Year { get; set; }

        public int Month { get; set; }

        public decimal Amount { get; set; }

        public int CrUser { get; set; }

    }
}
