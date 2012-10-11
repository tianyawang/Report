using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportModel
{
    public class MonthAmountReport
    {
        public int StationID { get; set; }

        public string StationName { get; set; }

        public decimal Amount { get; set; }

        public decimal SplitAmount { get; set; }
    }
}
