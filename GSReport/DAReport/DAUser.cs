using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Data;
using ReportModel.Common;
using ReportModel;
using System.Data.SqlClient;
using DAReport.DBUtility;
namespace DAReport
{
    public class DAUser
    {

        public int CreateUser(NewUserModel model)
        {
            int userid = 0;

            try
            {
                string strSQL = @" insert into useraccount(username,password,stationid)
                                values(@username,@password,@stationid) 
                                SELECT SCOPE_IDENTITY()  ";


                SqlParameter[] parms = new SqlParameter[]{
                new SqlParameter("@username",SqlDbType.NVarChar,50),
                new SqlParameter("@password",SqlDbType.NVarChar,1024),
                new SqlParameter("@stationid",SqlDbType.Int),
            };

                parms[0].Value = model.UserName;
                parms[1].Value = model.Password;
                parms[2].Value = model.StationID;

                using (var rdr = SqlHelper.ExecuteReader(SqlHelper.SQLConnectString, CommandType.Text, strSQL, parms))
                {
                    if (rdr.Read())
                    {
                        userid = Convert.ToInt32(rdr[0]);
                    }
                }
            }
            catch(Exception ex)
            {
                throw;
            }
            return userid;
        }

        public UserModel GetUser(int userid)
        {

            UserModel user = null;

            try
            {
                string strSQL = @" select useraccount.*,station.stationname
                                from useraccount 
                                left join station on station.id=useraccount.stationid 
                                where useraccount.id=@userid";

                SqlParameter[] parms = new SqlParameter[]{
                    new SqlParameter("@userid",SqlDbType.Int),
                };

                parms[0].Value = userid;


                using (var rdr = SqlHelper.ExecuteReader(SqlHelper.SQLConnectString, CommandType.Text, strSQL, parms))
                {
                    if (rdr.Read())
                    {
                        user=new UserModel()
                        {
                            StationID = Convert.ToInt32(rdr["StationID"]),
                            StationName = rdr.IsDBNull("StationName") ? "收费科" : Convert.ToString(rdr["StationName"]),
                            UserID = Convert.ToInt32(rdr["ID"]),
                            UserName = Convert.ToString(rdr["UserName"]),
                            Role=Convert.ToInt32(rdr["Role"]),
                            Password=Convert.ToString(rdr["password"])
                        };
                    }
                }
            }
            catch
            {
                throw;
            }
            return user;

        }


        public IList<UserModel> GetUsers()
        {

            IList<UserModel> users = new List<UserModel>();

            try
            {
                string strSQL = @" select useraccount.*,station.stationname
                                from useraccount 
                                left join station on station.id=useraccount.stationid 
                                where useraccount.IsDeleted=0 and username<>'sa' ";

                using (var rdr = SqlHelper.ExecuteReader(SqlHelper.SQLConnectString, CommandType.Text, strSQL))
                {
                    while (rdr.Read())
                    {
                        users.Add(new UserModel()
                        {
                            StationID = Convert.ToInt32(rdr["StationID"]),
                            StationName = rdr.IsDBNull("StationName") ? "收费科" : Convert.ToString(rdr["StationName"]),
                            UserID = Convert.ToInt32(rdr["ID"]),
                            UserName = Convert.ToString(rdr["UserName"]),
                            Role=Convert.ToInt32(rdr["Role"]),
                            Password=Convert.ToString(rdr["password"])
                        });
                    }
                }
            }
            catch
            {
                throw;
            }
            return users;

        }

        public void DeleteUser(int userid)
        {
            try
            {
                string strSQL = @" update useraccount set isdeleted=1 where id=@userid  ";

                SqlParameter[] parms = new SqlParameter[]{
                    new SqlParameter("@userid",SqlDbType.Int),
                };

                parms[0].Value = userid;

                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectString, CommandType.Text, strSQL, parms);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void ResetPassword(int userid,string password)
        {
            try
            {
                string strSQL = @" update useraccount set password=@password where id=@userid  ";

                SqlParameter[] parms = new SqlParameter[]{
                    new SqlParameter("@userid",SqlDbType.Int),
                    new SqlParameter("@password",SqlDbType.NVarChar,1024),
                };

                parms[0].Value = userid;
                parms[1].Value = password;
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectString, CommandType.Text, strSQL, parms);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int ValidateUser(string username, string password)
        {
            int userid = 0;
            try
            {
                string strSQL = @" select id from useraccount where username=@username and password=@password and Isdeleted=0  ";

                SqlParameter[] parms = new SqlParameter[]{
                    new SqlParameter("@username",SqlDbType.NVarChar,50),
                    new SqlParameter("@password",SqlDbType.NVarChar,1024),
                };

                parms[0].Value = username;
                parms[1].Value = password;
                using (var rdr = SqlHelper.ExecuteReader(SqlHelper.SQLConnectString, CommandType.Text, strSQL, parms))
                {
                    if (rdr.Read())
                    {
                        userid = Convert.ToInt32(rdr[0]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return userid;
        }

        public bool ChangePassword(int userid, string password,string newpassword)
        {
            bool result = false;
            try
            {
                string strSQL = @" if exists(Select id from useraccount where id=@userid and password=@password ) 
                                    begin 
                                        update useraccount set password=@newpassword where id=@userid
                                        select 1
                                        return
                                    end
                                    select 0 ";

                SqlParameter[] parms = new SqlParameter[]{
                    new SqlParameter("@userid",SqlDbType.Int),
                    new SqlParameter("@password",SqlDbType.NVarChar,1024),
                    new SqlParameter("@newpassword",SqlDbType.NVarChar,1024),
                };

                parms[0].Value = userid;
                parms[1].Value = password;
                parms[2].Value = newpassword;

                using (var rdr = SqlHelper.ExecuteReader(SqlHelper.SQLConnectString, CommandType.Text, strSQL, parms))
                {
                    if (rdr.Read())
                    {
                        result = Convert.ToBoolean(Convert.ToInt32(rdr[0]));
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return result;

        }

        public void UpdateUser(UserModel user)
        {
            try
            {
                string strSQL = @" update useraccount set 
                                    password=@password,
                                    username=@username,
                                    stationid=@stationid
                                where id=@userid  ";

                SqlParameter[] parms = new SqlParameter[]{
                    new SqlParameter("@userid",SqlDbType.Int),
                    new SqlParameter("@password",SqlDbType.NVarChar,1024),
                    new SqlParameter("@username",SqlDbType.NVarChar,1024),
                    new SqlParameter("@stationid",SqlDbType.Int)
                };

                parms[0].Value = user.UserID;
                parms[1].Value = user.Password;
                parms[2].Value = user.UserName;
                parms[3].Value = user.StationID;

                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectString, CommandType.Text, strSQL, parms);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
