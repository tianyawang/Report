using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ReportModel
{
    public class DailyAmountReport
    {
        public DailyAmountReport()
        {
            ReportDate = DateTime.Now.ToString("yyyy-MM-dd");
        }
        public int Schedue { get; set; }

        //班次名称
        public string SchedueName {
            get
            {
                string name = "";
                switch (Schedue)
                {
                    case 1:
                        name = "白班";
                        break;
                    case 2:
                        name = "中班";
                        break;
                    case 3:
                        name = "夜班";
                        break;
                }
                return name;
            }
        }

        public string ReportDate { get; set; }

        public decimal Amount { get; set; }

        public decimal EasyAccessAmount { get; set; }

        public int CrUser { get; set; }

        public int StationID { get; set; }

        public string StationName { get; set; }

        public decimal EasyPercent {
            get
            {
                if (Amount==0)
                    return 0;

                return Math.Round(EasyAccessAmount / Amount, 2);
            }
        }

    }

    public class StationMonthAmountReport
    {
        public decimal CurrentAmount { get; set; }

        public decimal TotalAmount { get; set; }
    }


}
