using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAReport;
using ReportModel;

namespace BLReport
{
    public class BLReports
    {
        private DAReports dareport = new DAReports();

        public void AddDailyAmountReport(DailyAmountReport model)
        {
            dareport.AddDailyAmountReport(model);
        }

        public void AddDailyCardReport(DailyCardReport model)
        {
            dareport.AddDailyCardReport(model);
        }

        public void AddTrafficReport(TrafficeFlowReport model)
        {
            dareport.AddTrafficReport(model);
        }

        public void AddTruck5Report(Truck5ReportModel model)
        {
            dareport.AddTruck5Report(model);
        }

        public void AddTruck6Report(Truck6ReportModel model)
        {
            dareport.AddTruck6Report(model);
        }

        public void SpiltBill(SplitBillReport model)
        {
            dareport.SpiltBill(model);
        }

        public void AddShortOver(ShortOverReport model)
        {
            dareport.AddShortOver(model);
        }

        #region 收费科报表

        public IList<DailyAmountReport> ListDailyReports()
        {
            return dareport.ListDayDailyReports();
        }

        public IList<MonthCardReport> ListMonthCardReports()
        {
            IList<MonthCardReport> reports = new List<MonthCardReport>();

            BLStation blstation = new BLStation();
            var stations = blstation.GetStations();

            var cardreport = dareport.ListMonthCardReports(DateTime.Now.Year, DateTime.Now.Month);

            foreach (var item in stations)
            {
                var report = cardreport.FirstOrDefault(t => t.StationID == item.StationID);
                if (report == null)
                {
                    reports.Add(new MonthCardReport()
                    {
                        StationID = item.StationID,
                        StationName = item.StationName,
                        BrokenCards = 0,
                        ReceivedCards = 0,
                        SentCards = 0,
                        WrongCards = 0
                    });
                }
                else
                {
                    report.StationName = item.StationName;
                    reports.Add(report);
                }
            }

            return reports;
        }

        public IList<MonthEasyAccessReport> ListMonthEasyAccessReports()
        {
            var eareports = dareport.ListMonthEasyAccessReports(DateTime.Now.Year, DateTime.Now.Month);
            var amountreports = dareport.ListMonthDailyAmountReport(DateTime.Now.Year, DateTime.Now.Month);

            IList<MonthEasyAccessReport> reports = new List<MonthEasyAccessReport>();

            BLStation blstation = new BLStation();
            var stations = blstation.GetStations();

            foreach (var item in stations)
            {
                var eareport = eareports.FirstOrDefault(t => t.StationID == item.StationID);
                var amountreport = amountreports.FirstOrDefault(t => t.StationID == item.StationID);

                reports.Add(new MonthEasyAccessReport()
                {
                    StationID = item.StationID,
                    StationName = item.StationName,
                    Amount = amountreport == null ? 0 : amountreport.Amount,
                    EasyAccessAmount = amountreport == null ? 0 : amountreport.EasyAccessAmount,
                    DownAmount = eareport == null ? 0 : eareport.DownAmount,
                    EasyAccess = eareport == null ? 0 : eareport.EasyAccess
                });

            }

            return reports;


        }

        public IList<MonthAmountReport> ListMonthAmountReport()
        {
            var now = DateTime.Now;

            var amountreports = dareport.ListMonthDailyAmountReport(now.Year, now.Month);
            var splitamount = dareport.ListMonthSplitBillReports(now.Year, now.Month);

            IList<MonthAmountReport> reports = new List<MonthAmountReport>();

            BLStation blstation = new BLStation();
            var stations = blstation.GetStations();


            foreach (var item in stations)
            {
                var splitreport = splitamount.FirstOrDefault(t => t.StationID == item.StationID);
                var amountreport = amountreports.FirstOrDefault(t => t.StationID == item.StationID);

                reports.Add(new MonthAmountReport()
                {
                    StationID = item.StationID,
                    StationName = item.StationName,
                    Amount = amountreport == null ? 0 : amountreport.Amount,
                    SplitAmount = splitreport == null ? 0 : splitreport.Amount
                });

            }

            return reports;

        }

        public IList<TrafficeFlowReport> ListDailyTrafficReports()
        {
            return dareport.ListDailyTrafficReports();
        }

        public IList<Truck5ReportModel> ListMonthTruck5Reports()
        {
            IList<Truck5ReportModel> reports = new List<Truck5ReportModel>();

            BLStation blstation = new BLStation();
            var stations = blstation.GetStations();

            var cardreport = dareport.ListMonthTruck5Reports(DateTime.Now.Year, DateTime.Now.Month);

            foreach (var item in stations)
            {
                var report = cardreport.FirstOrDefault(t => t.StationID == item.StationID);
                if (report == null)
                {
                    reports.Add(new Truck5ReportModel()
                    {
                        StationID = item.StationID,
                        StationName = item.StationName,
                        DownAmount = 0,
                        MoreThan0 = 0,
                        MoreThan100 = 0,
                        MoreThan30 = 0,
                        TruckAmount = 0
                    });
                }
                else
                {
                    reports.Add(report);
                }
            }

            return reports;
        }

        public IList<Truck6ReportModel> ListMonthTruck6Reports()
        {
            IList<Truck6ReportModel> reports = new List<Truck6ReportModel>();

            BLStation blstation = new BLStation();
            var stations = blstation.GetStations();

            var cardreport = dareport.ListMonthTruck6Reports(DateTime.Now.Year, DateTime.Now.Month);

            foreach (var item in stations)
            {
                var report = cardreport.FirstOrDefault(t => t.StationID == item.StationID);
                if (report == null)
                {
                    reports.Add(new Truck6ReportModel()
                    {
                        StationID = item.StationID,
                        StationName = item.StationName,
                        DownAmount = 0,
                        MoreThan0 = 0,
                        MoreThan100 = 0,
                        MoreThan30 = 0,
                        TruckAmount = 0
                    });
                }
                else
                {
                    reports.Add(report);
                }
            }

            return reports;
        }

        #endregion

        #region 收费站报表

        public IList<DailyAmountReport> ListStationDailyAmountReport(int stationid,DateTime date)
        {
            return dareport.ListStationDailyAmountReport(stationid,date);
        }

        public StationMonthAmountReport GetDailyAmountMonthReport(int stationid, DateTime date)
        {
            return dareport.GetDailyAmountMonthReport(stationid, date);

        }

        public IList<DailyCardReport> ListStationDailyCardReports(int stationid, DateTime date)
        {
            return dareport.ListStationDailyCardReports(stationid, date);
        }

        public MonthCardReport GetDailyCardMonthReport(int stationid, DateTime date)
        {
            return dareport.GetDailyCardMonthReport(stationid, date);
        }

        public IList<TrafficeFlowReport> ListStationDailyTrafficReports(int stationid)
        {
            return dareport.ListStationDailyTrafficReports(stationid );
        }


        #endregion

    }
}
