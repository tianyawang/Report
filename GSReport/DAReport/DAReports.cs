using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReportModel;
using System.Data.SqlClient;
using System.Data;
using DAReport.DBUtility;

namespace DAReport
{
    public class DAReports
    {
        public void AddDailyAmountReport(DailyAmountReport model)
        {
            try
            {
                string strSQL = @" 
                                if exists (select id from dailyamountreport 
                                            where stationid=@stationid 
                                            and reportdate=@reportdate and schedue=@schedue)
                                begin
                                    update dailyamountreport set
                                    amount=@amount,
                                    easyaccessamount=@easyaccessamount,
                                    cruser=@cruser,
                                    crtime=getdate()
                                    where stationid=@stationid
                                    and reportdate=@reportdate and schedue=@schedue
                                end
                                else
                                begin
                                    insert into dailyamountreport(schedue,reportdate,amount,easyaccessamount,cruser,stationid)
                                        values(@schedue,@reportdate,@amount,@easyaccessamount,@cruser,@stationid) 
                                end  ";


                SqlParameter[] parms = new SqlParameter[]{
                new SqlParameter("@schedue",SqlDbType.Int),
                new SqlParameter("@reportdate",SqlDbType.DateTime),
                new SqlParameter("@amount",SqlDbType.Decimal),
                new SqlParameter("@easyaccessamount",SqlDbType.Decimal),
                new SqlParameter("@cruser",SqlDbType.Int),
                new SqlParameter("@stationid",SqlDbType.Int),
            };

                parms[0].Value = model.Schedue;
                parms[1].Value = model.ReportDate;
                parms[2].Value = model.Amount;
                parms[3].Value = model.EasyAccessAmount;
                parms[4].Value = model.CrUser;
                parms[5].Value = model.StationID;
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectString, CommandType.Text, strSQL, parms);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void AddDailyCardReport(DailyCardReport model)
        {
            try
            {
                string strSQL = @" 
                                if exists (select id from dailycardreport 
                                            where stationid=@stationid 
                                            and reportdate=@reportdate and collectionclassid=@collectionclassid)
                                begin
                                    update dailycardreport set
                                    SentCards=@SentCards,
                                    WrongCards=@WrongCards,
                                    ReceivedCards=@ReceivedCards,
                                    BrokenCards=@BrokenCards,
                                    cruser=@cruser,
                                    crtime=getdate()
                                    where stationid=@stationid 
                                    and reportdate=@reportdate and collectionclassid=@collectionclassid
                                end
                                else
                                begin
                                    insert into dailycardreport(ReportDate,StationID,CollectionClassID,sentcards,wrongcards,receivedcards,brokencards,cruser)
                                        values(@ReportDate,@StationID,@CollectionClassID,@sentcards,@wrongcards,@receivedcards,@brokencards,@cruser) 
                                end  ";


                SqlParameter[] parms = new SqlParameter[]{
                new SqlParameter("@CollectionClassID",SqlDbType.Int),
                new SqlParameter("@reportdate",SqlDbType.DateTime),
                new SqlParameter("@sentcards",SqlDbType.Int),
                new SqlParameter("@wrongcards",SqlDbType.Int),
                new SqlParameter("@receivedcards",SqlDbType.Int),
                new SqlParameter("@brokencards",SqlDbType.Int),
                new SqlParameter("@cruser",SqlDbType.Int),
                new SqlParameter("@stationid",SqlDbType.Int),
            };

                parms[0].Value = model.CollectionClassID;
                parms[1].Value = model.ReportDate;
                parms[2].Value = model.SentCards;
                parms[3].Value = model.WrongCards;
                parms[4].Value = model.ReceivedCards;
                parms[5].Value = model.BrokenCards;
                parms[6].Value = model.CrUser;
                parms[7].Value = model.StationID;
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectString, CommandType.Text, strSQL, parms);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void AddTrafficReport(TrafficeFlowReport model)
        {
            try
            {
                string strSQL = @" 
                                if exists (select id from TrafficFlowReport 
                                            where stationid=@stationid 
                                            and reportdate=@reportdate)
                                begin
                                    update TrafficFlowReport set
                                    DownAmount=@DownAmount,
                                    TruckAmount=@TruckAmount,
                                    MoreThan30=@MoreThan30,
                                    MoreThan100=@MoreThan100,
                                    EngineeringVehicles=@EngineeringVehicles,
                                    EasyAccess=@EasyAccess,
                                    CrUser=@CrUser,
                                    crtime=getdate()
                                    where stationid=@stationid
                                    and reportdate=@reportdate
                                end
                                else
                                begin
                                    insert into TrafficFlowReport(ReportDate,StationID,DownAmount,TruckAmount,MoreThan30,MoreThan100,EngineeringVehicles,EasyAccess,CrUser)
                                        values(@ReportDate,@StationID,@DownAmount,@TruckAmount,@MoreThan30,@MoreThan100,@EngineeringVehicles,@EasyAccess,@CrUser) 
                                end  ";


                SqlParameter[] parms = new SqlParameter[]{
                new SqlParameter("@reportdate",SqlDbType.DateTime),
                new SqlParameter("@DownAmount",SqlDbType.Int),
                new SqlParameter("@TruckAmount",SqlDbType.Int),
                new SqlParameter("@MoreThan30",SqlDbType.Int),
                new SqlParameter("@MoreThan100",SqlDbType.Int),
                new SqlParameter("@EngineeringVehicles",SqlDbType.Int),
                new SqlParameter("@EasyAccess",SqlDbType.Int),
                new SqlParameter("@cruser",SqlDbType.Int),
                new SqlParameter("@stationid",SqlDbType.Int),
            };

                parms[0].Value = model.ReportDate;
                parms[1].Value = model.DownAmount;
                parms[2].Value = model.TruckAmount;
                parms[3].Value = model.MoreThan30;
                parms[4].Value = model.MoreThan100;
                parms[5].Value = model.EngineeringVehicles;
                parms[6].Value = model.EasyAccess;
                parms[7].Value = model.CrUser;
                parms[8].Value = model.StationID;
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectString, CommandType.Text, strSQL, parms);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void AddTruck5Report(Truck5ReportModel model)
        {
            try
            {
                string strSQL = @" 
                                if exists (select id from Truck5Report 
                                            where stationid=@stationid 
                                            and Year=@year and Month=@Month)
                                begin
                                    update Truck5Report set
                                    DownAmount=@DownAmount,
                                    TruckAmount=@TruckAmount,
                                    MoreThan30=@MoreThan30,
                                    MoreThan100=@MoreThan100,
                                    MoreThan0=@MoreThan0,
                                    CrUser=@CrUser,
                                    crtime=getdate()
                                    where stationid=@stationid
                                    and Year=@year and Month=@Month
                                end
                                else
                                begin
                                    insert into Truck5Report(year,Month,StationID,DownAmount,TruckAmount,MoreThan30,MoreThan100,MoreThan0,CrUser)
                                        values(@year,@Month,@stationid,@DownAmount,@TruckAmount,@MoreThan30,@MoreThan100,@MoreThan0,@CrUser) 
                                end  ";


                SqlParameter[] parms = new SqlParameter[]{
                new SqlParameter("@Year",SqlDbType.Int),
                new SqlParameter("@Month",SqlDbType.Int),
                new SqlParameter("@DownAmount",SqlDbType.Int),
                new SqlParameter("@TruckAmount",SqlDbType.Int),
                new SqlParameter("@MoreThan30",SqlDbType.Int),
                new SqlParameter("@MoreThan100",SqlDbType.Int),
                new SqlParameter("@MoreThan0",SqlDbType.Int),
                new SqlParameter("@cruser",SqlDbType.Int),
                new SqlParameter("@stationid",SqlDbType.Int),
            };

                parms[0].Value = model.Year;
                parms[1].Value = model.Month;
                parms[2].Value = model.DownAmount;
                parms[3].Value = model.TruckAmount;
                parms[4].Value = model.MoreThan30;
                parms[5].Value = model.MoreThan100;
                parms[6].Value = model.MoreThan0;
                parms[7].Value = model.CrUser;
                parms[8].Value = model.StationID;
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectString, CommandType.Text, strSQL, parms);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void AddTruck6Report(Truck6ReportModel model)
        {
            try
            {
                string strSQL = @" 
                                if exists (select id from Truck6Report 
                                            where stationid=@stationid 
                                            and Year=@year and Month=@Month)
                                begin
                                    update Truck5Report set
                                    DownAmount=@DownAmount,
                                    TruckAmount=@TruckAmount,
                                    MoreThan30=@MoreThan30,
                                    MoreThan100=@MoreThan100,
                                    MoreThan0=@MoreThan0,
                                    CrUser=@CrUser,
                                    crtime=getdate()
                                    where stationid=@stationid
                                    and Year=@year and Month=@Month
                                end
                                else
                                begin
                                    insert into Truck6Report(year,Month,StationID,DownAmount,TruckAmount,MoreThan30,MoreThan100,MoreThan0,CrUser)
                                        values(@year,@Month,@stationid,@DownAmount,@TruckAmount,@MoreThan30,@MoreThan100,@MoreThan0,@CrUser) 
                                end  ";


                SqlParameter[] parms = new SqlParameter[]{
                new SqlParameter("@Year",SqlDbType.Int),
                new SqlParameter("@Month",SqlDbType.Int),
                new SqlParameter("@DownAmount",SqlDbType.Int),
                new SqlParameter("@TruckAmount",SqlDbType.Int),
                new SqlParameter("@MoreThan30",SqlDbType.Int),
                new SqlParameter("@MoreThan100",SqlDbType.Int),
                new SqlParameter("@MoreThan0",SqlDbType.Int),
                new SqlParameter("@cruser",SqlDbType.Int),
                new SqlParameter("@stationid",SqlDbType.Int),
            };

                parms[0].Value = model.Year;
                parms[1].Value = model.Month;
                parms[2].Value = model.DownAmount;
                parms[3].Value = model.TruckAmount;
                parms[4].Value = model.MoreThan30;
                parms[5].Value = model.MoreThan100;
                parms[6].Value = model.MoreThan0;
                parms[7].Value = model.CrUser;
                parms[8].Value = model.StationID;
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectString, CommandType.Text, strSQL, parms);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void SpiltBill(SplitBillReport model)
        {
            try
            {
                string strSQL = @" 
                                if exists (select id from SplitBillReport 
                                            where stationid=@stationid 
                                            and Year=@year and Month=@Month)
                                begin
                                    update SplitBillReport set
                                    Amount=@Amount,
                                    CrUser=@CrUser,
                                    crtime=getdate()
                                    where stationid=@stationid
                                    and Year=@year and Month=@Month
                                end
                                else
                                begin
                                    insert into SplitBillReport(year,Month,StationID,Amount,CrUser)
                                        values(@year,@Month,@StationID,@Amount,@CrUser) 
                                end  ";


                SqlParameter[] parms = new SqlParameter[]{
                new SqlParameter("@Year",SqlDbType.Int),
                new SqlParameter("@Month",SqlDbType.Int),
                new SqlParameter("@Amount",SqlDbType.Int),
                new SqlParameter("@cruser",SqlDbType.Int),
                new SqlParameter("@stationid",SqlDbType.Int),
            };

                parms[0].Value = model.Year;
                parms[1].Value = model.Month;
                parms[2].Value = model.Amount;
                parms[3].Value = model.CrUser;
                parms[4].Value = model.StationID;
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectString, CommandType.Text, strSQL, parms);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void AddShortOver(ShortOverReport model)
        {
            try
            {
                string strSQL = @" 
                                if exists (select id from shortoverreport 
                                            where stationid=@stationid 
                                            and reportdate=@reportdate)
                                begin
                                    update shortoverreport set
                                    amount=@amount,
                                    shortovertimes=@shortovertimes,
                                    chargeTimes=@chargeTimes,
                                    cruser=@cruser,
                                    crtime=getdate()
                                    where stationid=@stationid
                                    and reportdate=@reportdate 
                                end
                                else
                                begin
                                    insert into shortoverreport(reportdate,amount,shortovertimes,chargeTimes,cruser,stationid)
                                        values(@reportdate,@amount,@shortovertimes,@chargeTimes,@cruser,@stationid) 
                                end  ";


                SqlParameter[] parms = new SqlParameter[]{
                new SqlParameter("@reportdate",SqlDbType.DateTime),
                new SqlParameter("@amount",SqlDbType.Decimal),
                new SqlParameter("@shortovertimes",SqlDbType.Decimal),
                new SqlParameter("@chargeTimes",SqlDbType.Decimal),
                new SqlParameter("@cruser",SqlDbType.Int),
                new SqlParameter("@stationid",SqlDbType.Int),
            };

                parms[0].Value = model.ReportDate;
                parms[1].Value = model.ShortOverAmount;
                parms[2].Value = model.ShortOverTimes;
                parms[3].Value = model.ChargeTimes;
                parms[4].Value = model.CrUser;
                parms[5].Value = model.StationID;
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectString, CommandType.Text, strSQL, parms);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #region 收费科报表

        public IList<SplitBillReport> ListMonthSplitBillReports(int year, int month)
        {
            IList<SplitBillReport> reports = new List<SplitBillReport>();
            try
            {
                string strSQL = @" 
                                select *
                                from SplitBillReport
                                where month=@month and year=@year
                                ";
                SqlParameter[] parms = new SqlParameter[]{
                    new SqlParameter("@year",SqlDbType.Int),
                    new SqlParameter("@month",SqlDbType.Int),
                };

                parms[0].Value = year;
                parms[1].Value = month;

                using (var rdr = SqlHelper.ExecuteReader(SqlHelper.SQLConnectString, CommandType.Text, strSQL, parms))
                {
                    while (rdr.Read())
                    {
                        reports.Add(new SplitBillReport()
                        {
                            Amount = Convert.ToDecimal(rdr["totalamount"]),
                            StationID = Convert.ToInt32(rdr["StationID"]),
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return reports;

        }

        public IList<DailyAmountReport> ListDayDailyReports()
        {
            IList<DailyAmountReport> reports = new List<DailyAmountReport>();
            try
            {
                string strSQL = @" 
                                select top 10 stationid,station.stationname,sum(amount) as totalamount,sum(easyaccessamount) totaleasyaccessamount,reportdate from dailyamountreport 
                                inner join station on station.id=dailyamountreport.stationid
                                group by stationid,reportdate,stationname
                                order by reportdate
                                ";


                using (var rdr = SqlHelper.ExecuteReader(SqlHelper.SQLConnectString, CommandType.Text, strSQL, null))
                {
                    while (rdr.Read())
                    {
                        reports.Add(new DailyAmountReport()
                        {
                            Amount = Convert.ToDecimal(rdr["totalamount"]),
                            StationName = Convert.ToString(rdr["StationName"]),
                            StationID = Convert.ToInt32(rdr["StationID"]),
                            ReportDate = Convert.ToDateTime(rdr["reportdate"]).ToString("yyyy-MM-dd"),
                            EasyAccessAmount = Convert.ToDecimal(rdr["totaleasyaccessamount"]),
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return reports;
        }

        public IList<DailyAmountReport> ListMonthDailyAmountReport(int year, int month)
        {
            IList<DailyAmountReport> reports = new List<DailyAmountReport>();
            try
            {
                string strSQL = @" 
                                select stationid,station.stationname,sum(amount) as totalamount,sum(easyaccessamount) totaleasyaccessamount
                                from DailyAmountReport
                                inner join station on station.id=dailyamountreport.stationid
                                where datepart(m,reportdate)=@month and datepart(yyyy,reportdate)=@year
                                group by stationid,stationname
                                ";
                SqlParameter[] parms = new SqlParameter[]{
                    new SqlParameter("@year",SqlDbType.Int),
                    new SqlParameter("@month",SqlDbType.Int),
                };

                parms[0].Value = year;
                parms[1].Value = month;

                using (var rdr = SqlHelper.ExecuteReader(SqlHelper.SQLConnectString, CommandType.Text, strSQL, parms))
                {
                    while (rdr.Read())
                    {
                        reports.Add(new DailyAmountReport()
                        {
                            Amount = Convert.ToDecimal(rdr["totalamount"]),
                            StationName = Convert.ToString(rdr["StationName"]),
                            StationID = Convert.ToInt32(rdr["StationID"]),
                            ReportDate = Convert.ToDateTime(rdr["reportdate"]).ToString("yyyy-MM-dd"),
                            EasyAccessAmount = Convert.ToDecimal(rdr["totaleasyaccessamount"]),
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return reports;

        }

        public IList<MonthCardReport> ListMonthCardReports(int year, int month)
        {
            IList<MonthCardReport> reports = new List<MonthCardReport>();
            try
            {
                string strSQL = @" 
                                select stationid,sum(SentCards) as totalsentcards,sum(wrongcards)as totalwrongcards,
                                    sum(receivedcards) as totalreceivedcards,sum(brokencards) as totalbrokencards
                                from dailycardreport
                                inner join station on station.id=dailycardreport.stationid
                                where datepart(m,reportdate)=@month and datepart(yyyy,reportdate)=@year
                                group by stationid
                                ";
                SqlParameter[] parms = new SqlParameter[]{
                new SqlParameter("@year",SqlDbType.Int),
                new SqlParameter("@month",SqlDbType.Int),
            };

                parms[0].Value = year;
                parms[1].Value = month;


                using (var rdr = SqlHelper.ExecuteReader(SqlHelper.SQLConnectString, CommandType.Text, strSQL, parms))
                {
                    while (rdr.Read())
                    {
                        reports.Add(new MonthCardReport()
                        {
                            StationID = Convert.ToInt32(rdr["StationID"]),
                            BrokenCards = Convert.ToInt32(rdr["totalbrokencards"]),
                            ReceivedCards = Convert.ToInt32(rdr["totalreceivedcards"]),
                            WrongCards = Convert.ToInt32(rdr["totalwrongcards"]),
                            SentCards = Convert.ToInt32(rdr["totalsentcards"])
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return reports;
        }

        public IList<MonthEasyAccessReport> ListMonthEasyAccessReports(int year, int month)
        {
            IList<MonthEasyAccessReport> reports = new List<MonthEasyAccessReport>();
            try
            {
                string strSQL = @" 
                                select stationid,stationname,sum(downamount) as totaldownamount,sum(easyaccess)as totaleasyaccess
                                from trafficflowreport
                                inner join station on station.id=trafficflowreport.stationid
                                where datepart(m,reportdate)=@month and datepart(yyyy,reportdate)=@year
                                group by stationid,stationname
                                ";
                SqlParameter[] parms = new SqlParameter[]{
                    new SqlParameter("@year",SqlDbType.Int),
                    new SqlParameter("@month",SqlDbType.Int),
                };

                parms[0].Value = year;
                parms[1].Value = month;


                using (var rdr = SqlHelper.ExecuteReader(SqlHelper.SQLConnectString, CommandType.Text, strSQL, parms))
                {
                    while (rdr.Read())
                    {
                        reports.Add(new MonthEasyAccessReport()
                        {
                            StationID = Convert.ToInt32(rdr["StationID"]),
                            StationName = Convert.ToString(rdr["StationName"]),
                            DownAmount = Convert.ToInt32(rdr["totaldownamount"]),
                            EasyAccess = Convert.ToInt32(rdr["totaleasyaccess"]),
                        });
                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }

            return reports;

        }

        public IList<TrafficeFlowReport> ListDailyTrafficReports()
        {
            IList<TrafficeFlowReport> reports = new List<TrafficeFlowReport>();
            try
            {
                string strSQL = @" 
                                select top 10 TrafficFlowReport.*,station.stationname
                                from TrafficFlowReport 
                                inner join station on station.id=TrafficFlowReport.stationid
                                order by reportdate
                                ";


                using (var rdr = SqlHelper.ExecuteReader(SqlHelper.SQLConnectString, CommandType.Text, strSQL, null))
                {
                    while (rdr.Read())
                    {
                        reports.Add(new TrafficeFlowReport()
                        {
                            ReportDate = Convert.ToDateTime(rdr["ReportDate"]).ToString("yyyy-MM-dd"),
                            DownAmount = Convert.ToInt32(rdr["DownAmount"]),
                            EasyAccess = Convert.ToInt32(rdr["EasyAccess"]),
                            EngineeringVehicles = Convert.ToInt32(rdr["EngineeringVehicles"]),
                            MoreThan100 = Convert.ToInt32(rdr["MoreThan100"]),
                            MoreThan30 = Convert.ToInt32(rdr["MoreThan30"]),
                            TruckAmount = Convert.ToInt32(rdr["TruckAmount"]),
                            StationName = Convert.ToString(rdr["StationName"])
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return reports;
        }

        public IList<Truck5ReportModel> ListMonthTruck5Reports(int year, int month)
        {
            IList<Truck5ReportModel> reports = new List<Truck5ReportModel>();
            try
            {
                string strSQL = @" 
                                select Truck5Report.*,stationname
                                from Truck5Report
                                inner join station on station.id=Truck5Report.stationid
                                where month=@month and year=@year
                                ";
                SqlParameter[] parms = new SqlParameter[]{
                    new SqlParameter("@year",SqlDbType.Int),
                    new SqlParameter("@month",SqlDbType.Int),
                };

                parms[0].Value = year;
                parms[1].Value = month;


                using (var rdr = SqlHelper.ExecuteReader(SqlHelper.SQLConnectString, CommandType.Text, strSQL, parms))
                {
                    while (rdr.Read())
                    {
                        reports.Add(new Truck5ReportModel()
                        {
                            StationID = Convert.ToInt32(rdr["StationID"]),
                            StationName = Convert.ToString(rdr["StationName"]),
                            DownAmount = Convert.ToInt32(rdr["totaldownamount"]),
                            MoreThan0 = Convert.ToInt32(rdr["MoreThan0"]),
                            MoreThan30 = Convert.ToInt32(rdr["MoreThan30"]),
                            MoreThan100 = Convert.ToInt32(rdr["MoreThan100"]),
                            TruckAmount = Convert.ToInt32(rdr["TruckAmount"]),
                        });
                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }

            return reports;
        }

        public IList<Truck6ReportModel> ListMonthTruck6Reports(int year, int month)
        {
            IList<Truck6ReportModel> reports = new List<Truck6ReportModel>();
            try
            {
                string strSQL = @" 
                                select Truck6Report.*,stationname
                                from Truck6Report
                                inner join station on station.id=Truck6Report.stationid
                                where month=@month and year=@year
                                ";
                SqlParameter[] parms = new SqlParameter[]{
                    new SqlParameter("@year",SqlDbType.Int),
                    new SqlParameter("@month",SqlDbType.Int),
                };

                parms[0].Value = year;
                parms[1].Value = month;


                using (var rdr = SqlHelper.ExecuteReader(SqlHelper.SQLConnectString, CommandType.Text, strSQL, parms))
                {
                    while (rdr.Read())
                    {
                        reports.Add(new Truck6ReportModel()
                        {
                            StationID = Convert.ToInt32(rdr["StationID"]),
                            StationName = Convert.ToString(rdr["StationName"]),
                            DownAmount = Convert.ToInt32(rdr["totaldownamount"]),
                            MoreThan0 = Convert.ToInt32(rdr["MoreThan0"]),
                            MoreThan30 = Convert.ToInt32(rdr["MoreThan30"]),
                            MoreThan100 = Convert.ToInt32(rdr["MoreThan100"]),
                            TruckAmount = Convert.ToInt32(rdr["TruckAmount"]),
                        });
                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }

            return reports;
        }

        #endregion

        #region 收费站报表

        public IList<DailyAmountReport> ListStationDailyAmountReport(int stationid, DateTime date)
        {
            IList<DailyAmountReport> reports = new List<DailyAmountReport>();
            try
            {
                string strSQL = @" 
                                select * from dailyamountreport 
                                where datepart(m,reportdate)=@month and datepart(yyyy,reportdate)=@year and datepart(dd,reportdate)=@day 
                                and stationid=@stationid
                                ";

                SqlParameter[] parms = new SqlParameter[]{
                    new SqlParameter("@year",SqlDbType.Int),
                    new SqlParameter("@month",SqlDbType.Int),
                    new SqlParameter("@day",SqlDbType.Int),
                    new SqlParameter("@stationid",SqlDbType.Int),
                };

                parms[0].Value = date.Year;
                parms[1].Value = date.Month;
                parms[2].Value = date.Day;
                parms[3].Value = stationid;

                using (var rdr = SqlHelper.ExecuteReader(SqlHelper.SQLConnectString, CommandType.Text, strSQL, parms))
                {
                    while (rdr.Read())
                    {
                        reports.Add(new DailyAmountReport()
                        {
                            Amount = Convert.ToDecimal(rdr["Amount"]),
                            Schedue = Convert.ToInt32(rdr["Schedue"])
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return reports;
        }

        public StationMonthAmountReport GetDailyAmountMonthReport(int stationid, DateTime date)
        {
            StationMonthAmountReport report = new StationMonthAmountReport();
            try
            {
                string strSQL = @" select 
                               ( select sum(amount) from dailyamountreport 
                                where datepart(m,reportdate)=@month and datepart(yyyy,reportdate)=@year
                                and stationid=@stationid ) as currentamount,
                                ( select sum(amount) from dailyamountreport 
                                where stationid=@stationid ) as total
                                ";

                SqlParameter[] parms = new SqlParameter[]{
                    new SqlParameter("@year",SqlDbType.Int),
                    new SqlParameter("@month",SqlDbType.Int),
                    new SqlParameter("@stationid",SqlDbType.Int),
                };

                parms[0].Value = date.Year;
                parms[1].Value = date.Month;
                parms[2].Value = stationid;

                using (var rdr = SqlHelper.ExecuteReader(SqlHelper.SQLConnectString, CommandType.Text, strSQL, parms))
                {
                    if (rdr.Read())
                    {
                        report.CurrentAmount = Convert.ToDecimal(rdr["currentamount"]);
                        report.TotalAmount = Convert.ToDecimal(rdr["total"]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return report;
        }

        public IList<DailyCardReport> ListStationDailyCardReports(int stationid, DateTime date)
        {
            IList<DailyCardReport> reports = new List<DailyCardReport>();
            try
            {
                string strSQL = @" 
                                select dailycardreport.*,collectionclass.classname
                                from dailycardreport
                                inner join collectionclass on collectionclass.id=dailycardreport.collectionclassid
                                where datepart(m,reportdate)=@month and datepart(yyyy,reportdate)=@year and datepart(dd,reportdate)=@day
                                and dailycardreport.stationid=@stationid
                                ";
                SqlParameter[] parms = new SqlParameter[]{
                new SqlParameter("@year",SqlDbType.Int),
                new SqlParameter("@month",SqlDbType.Int),
                new SqlParameter("@day",SqlDbType.Int),
                new SqlParameter("@stationid",SqlDbType.Int),
            };

                parms[0].Value = date.Year;
                parms[1].Value = date.Month;
                parms[2].Value = date.Day;
                parms[3].Value = stationid;

                using (var rdr = SqlHelper.ExecuteReader(SqlHelper.SQLConnectString, CommandType.Text, strSQL, parms))
                {
                    while (rdr.Read())
                    {
                        reports.Add(new DailyCardReport()
                        {
                            CollectionClassName = Convert.ToString(rdr["classname"]),
                            BrokenCards = Convert.ToInt32(rdr["BrokenCards"]),
                            ReceivedCards = Convert.ToInt32(rdr["ReceivedCards"]),
                            WrongCards = Convert.ToInt32(rdr["WrongCards"]),
                            SentCards = Convert.ToInt32(rdr["SentCards"])
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return reports;
        }

        public MonthCardReport GetDailyCardMonthReport(int stationid, DateTime date)
        {
            MonthCardReport report = new MonthCardReport();
            try
            {
                string strSQL = @" 
                                select sum(SentCards) as totalsentcards,sum(wrongcards)as totalwrongcards,
                                    sum(receivedcards) as totalreceivedcards,sum(brokencards) as totalbrokencards
                                from dailycardreport
                                where datepart(m,reportdate)=@month and datepart(yyyy,reportdate)=@year
                                and stationid=@stationid
                                ";
                SqlParameter[] parms = new SqlParameter[]{
                new SqlParameter("@year",SqlDbType.Int),
                new SqlParameter("@month",SqlDbType.Int),
                new SqlParameter("@stationid",SqlDbType.Int),
            };

                parms[0].Value = date.Year;
                parms[1].Value = date.Month;
                parms[2].Value = stationid;


                using (var rdr = SqlHelper.ExecuteReader(SqlHelper.SQLConnectString, CommandType.Text, strSQL, parms))
                {
                    if (rdr.Read())
                    {

                        report.BrokenCards = Convert.ToInt32(rdr["totalbrokencards"]);
                        report.ReceivedCards = Convert.ToInt32(rdr["totalreceivedcards"]);
                        report.WrongCards = Convert.ToInt32(rdr["totalwrongcards"]);
                        report.SentCards = Convert.ToInt32(rdr["totalsentcards"]);

                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return report;

        }

        public IList<TrafficeFlowReport> ListStationDailyTrafficReports(int stationid)
        {
            IList<TrafficeFlowReport> reports = new List<TrafficeFlowReport>();
            try
            {
                string strSQL = @" 
                                select top 10 TrafficFlowReport.*
                                from TrafficFlowReport 
                                where stationid=@stationid
                                order by reportdate
                                ";
                SqlParameter[] parms = new SqlParameter[]{
                    new SqlParameter("@stationid",SqlDbType.Int),
                };

                parms[0].Value = stationid;




                using (var rdr = SqlHelper.ExecuteReader(SqlHelper.SQLConnectString, CommandType.Text, strSQL, parms))
                {
                    while (rdr.Read())
                    {
                        reports.Add(new TrafficeFlowReport()
                        {
                            ReportDate = Convert.ToDateTime(rdr["ReportDate"]).ToString("yyyy-MM-dd"),
                            DownAmount = Convert.ToInt32(rdr["DownAmount"]),
                            EasyAccess = Convert.ToInt32(rdr["EasyAccess"]),
                            EngineeringVehicles = Convert.ToInt32(rdr["EngineeringVehicles"]),
                            MoreThan100 = Convert.ToInt32(rdr["MoreThan100"]),
                            MoreThan30 = Convert.ToInt32(rdr["MoreThan30"]),
                            TruckAmount = Convert.ToInt32(rdr["TruckAmount"]),
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return reports;
        }

        #endregion
    }
}
