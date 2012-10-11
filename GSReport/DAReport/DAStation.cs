using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReportModel;
using DAReport.DBUtility;
using System.Data;
using System.Data.SqlClient;

namespace DAReport
{
    public class DAStation
    {

        #region Station

        public IList<StationModel> GetStations()
        {
            IList<StationModel> stations = new List<StationModel>();

            try
            {
                string strSQL = @" select * from station where isdeleted=0 ";

                using (var rdr = SqlHelper.ExecuteReader(SqlHelper.SQLConnectString, CommandType.Text, strSQL))
                {
                    while (rdr.Read())
                    {
                        stations.Add(new StationModel()
                        {
                            StationID = Convert.ToInt32(rdr["id"]),
                            StationName = Convert.ToString(rdr["stationname"])
                        });
                    }
                }
            }
            catch
            {
                throw;
            }
            return stations;
        }

        public StationModel GetStation(int stationid)
        {
            StationModel station = null;

            try
            {
                string strSQL = @" select * from station where id=@stationid ";

                SqlParameter[] parms = new SqlParameter[]{
                    new SqlParameter("@stationid",SqlDbType.Int),
                };

                parms[0].Value = stationid;

                using (var rdr = SqlHelper.ExecuteReader(SqlHelper.SQLConnectString, CommandType.Text, strSQL, parms))
                {
                    if (rdr.Read())
                    {
                        station = new StationModel()
                        {
                            StationID = Convert.ToInt32(rdr["id"]),
                            StationName = Convert.ToString(rdr["stationname"])
                        };
                    }
                }
            }
            catch
            {
                throw;
            }
            return station;
        }

        public void DeleteStation(int stationid)
        {
            try
            {
                string strSQL = @" update station set isdeleted=1 where id=@stationid  ";

                SqlParameter[] parms = new SqlParameter[]{
                    new SqlParameter("@stationid",SqlDbType.Int),
                };

                parms[0].Value = stationid;

                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectString, CommandType.Text, strSQL, parms);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public int AddStation(string stationame)
        {
            int id = 0;

            try
            {
                string strSQL = @" insert into station(stationname)
                                values(@stationname) 
                                SELECT SCOPE_IDENTITY()  ";


                SqlParameter[] parms = new SqlParameter[]{
                new SqlParameter("@stationname",SqlDbType.NVarChar,50),
            };

                parms[0].Value = stationame;

                using (var rdr = SqlHelper.ExecuteReader(SqlHelper.SQLConnectString, CommandType.Text, strSQL, parms))
                {
                    if (rdr.Read())
                    {
                        id = Convert.ToInt32(rdr[0]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return id;

        }

        public void UpdateStation(int stationid, string stationname)
        {
            try
            {
                string strSQL = @" update station set
                                    stationname=@stationname
                                where id=@stationid  ";


                SqlParameter[] parms = new SqlParameter[]{
                new SqlParameter("@stationname",SqlDbType.NVarChar,50),
                new SqlParameter("@stationid",SqlDbType.Int)
            };

                parms[0].Value = stationname;
                parms[1].Value = stationid;

                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectString, CommandType.Text, strSQL, parms);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        #endregion

        #region class

        public IList<CollectionClassModel> GetCollectionClasses(int stationid)
        {
            IList<CollectionClassModel> stations = new List<CollectionClassModel>();
            StringBuilder strSQL = new StringBuilder();
            try
            {
                strSQL.Append(@" select collectionclass.*,stationname from collectionclass
                            inner join station on station.id=collectionclass.stationid    
                        where collectionclass.isdeleted=0 ");

                if (stationid > 0)
                {
                    strSQL.AppendFormat(" and stationid={0}", stationid);
                }

                using (var rdr = SqlHelper.ExecuteReader(SqlHelper.SQLConnectString, CommandType.Text, strSQL.ToString()))
                {
                    while (rdr.Read())
                    {
                        stations.Add(new CollectionClassModel()
                        {
                            StationID = Convert.ToInt32(rdr["stationid"]),
                            StationName = Convert.ToString(rdr["stationname"]),
                            ClassID = Convert.ToInt32(rdr["ID"]),
                            ClassName = Convert.ToString(rdr["ClassName"])
                        });
                    }
                }
            }
            catch
            {
                throw;
            }
            return stations;
        }

        public CollectionClassModel GetCollectionClass(int classid)
        {
            CollectionClassModel station = null;
            StringBuilder strSQL = new StringBuilder();
            try
            {
                strSQL.Append(@" select collectionclass.*,stationname from collectionclass
                            inner join station on station.id=collectionclass.stationid    
                        where collectionclass.id=@classid");

                SqlParameter[] parms = new SqlParameter[]{
                    new SqlParameter("@classid",SqlDbType.Int),
                };

                parms[0].Value = classid;

                using (var rdr = SqlHelper.ExecuteReader(SqlHelper.SQLConnectString, CommandType.Text, strSQL.ToString(), parms))
                {
                    if (rdr.Read())
                    {
                        station = new CollectionClassModel()
                        {
                            StationID = Convert.ToInt32(rdr["stationid"]),
                            StationName = Convert.ToString(rdr["stationname"]),
                            ClassID = Convert.ToInt32(rdr["ID"]),
                            ClassName = Convert.ToString(rdr["ClassName"])
                        };
                    }
                }
            }
            catch
            {
                throw;
            }
            return station;
        }

        public void DeleteCollectionClass(int classid)
        {
            try
            {
                string strSQL = @" update collectionclass set isdeleted=1 where id=@classid  ";

                SqlParameter[] parms = new SqlParameter[]{
                    new SqlParameter("@classid",SqlDbType.Int),
                };

                parms[0].Value = classid;

                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectString, CommandType.Text, strSQL, parms);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public int AddCollectionClass(int stationid,string classname)
        {
            int id = 0;

            try
            {
                string strSQL = @" insert into collectionclass(stationid,classname)
                                values(@stationid,@classname) 
                                SELECT SCOPE_IDENTITY()  ";


                SqlParameter[] parms = new SqlParameter[]{
                new SqlParameter("@stationid",SqlDbType.Int),
                new SqlParameter("@classname",SqlDbType.NVarChar,50),
            };

                parms[0].Value = stationid;
                parms[1].Value = classname;
                using (var rdr = SqlHelper.ExecuteReader(SqlHelper.SQLConnectString, CommandType.Text, strSQL, parms))
                {
                    if (rdr.Read())
                    {
                        id = Convert.ToInt32(rdr[0]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return id;

        }


        #endregion
    }
}
