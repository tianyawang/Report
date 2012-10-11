using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportModel
{
    public class Truck6ReportModel
    {
        public int Year { get; set; }

        public int Month { get; set; }

        public int DownAmount { get; set; }

        public int TruckAmount { get; set; }

        public int MoreThan0 { get; set; }

        public int MoreThan30 { get; set; }

        public int MoreThan100 { get; set; }

        public decimal MoreThan0Percent
        {
            get
            {
                if (DownAmount == 0) return 0;
                return Math.Round(MoreThan0 / (decimal)DownAmount, 4);
            }
        }

        public decimal MoreThan30Percent
        {
            get
            {
                if (DownAmount == 0) return 0;
                return Math.Round(MoreThan30 / (decimal)DownAmount, 4);
            }
        }

        public decimal MoreThan100Percent
        {
            get
            {
                if (DownAmount == 0) return 0;
                return Math.Round(MoreThan100 / (decimal)DownAmount, 4);
            }
        }

        public int CrUser { get; set; }

        public int StationID { get; set; }

        public string StationName { get; set; }
    }
}
