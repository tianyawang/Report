using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportModel
{
    public class TrafficeFlowReport
    {
        public TrafficeFlowReport()
        {
            ReportDate = DateTime.Now.ToString("yyyy-MM-dd");
        }

        public string ReportDate { get; set; }

        public int DownAmount { get; set; }

        public int TruckAmount { get; set; }

        public int MoreThan30 { get; set; }

        public decimal MoreThan30Percent
        {
            get
            {
                if (DownAmount == 0) return 0;

                return Math.Round(MoreThan30 / (decimal)TruckAmount, 4);
            }
        
        }

        public int MoreThan100 { get; set; }

        public decimal MoreThan100Percent
        {
            get
            {
                if (DownAmount == 0) return 0;

                return Math.Round(MoreThan100 / (decimal)TruckAmount, 4);
            }

        }


        public int EngineeringVehicles { get; set; }

        public int EasyAccess { get; set; }

        public decimal EasyAccessPercent
        {
            get
            {
                if (DownAmount == 0) return 0;

                return Math.Round(EasyAccess / (decimal)TruckAmount, 4);
            }

        }


        public int CrUser { get; set; }

        public int StationID { get; set; }

        public string StationName { get; set; }

    }

    public class MonthEasyAccessReport
    {
        public string StationName { get; set; }

        public int StationID { get; set; }

        /// <summary>
        /// 下行车流量
        /// </summary>
        public int DownAmount { get; set; }

        /// <summary>
        /// 绿通车流量
        /// </summary>
        public int EasyAccess { get; set; }

        public decimal EasyPercent
        {
            get
            {
                if (DownAmount == 0)
                    return 0;

                return Math.Round(EasyAccess / (decimal)DownAmount, 4);
            }
        }

        /// <summary>
        /// 收费额
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 绿通收费额
        /// </summary>
        public decimal EasyAccessAmount { get; set; }

        public decimal EasyAmountPercent
        {
            get
            {
                if (Amount == 0)
                    return 0;

                return Math.Round(EasyAccessAmount / (decimal)Amount, 2);
            }
        }

    }
}
