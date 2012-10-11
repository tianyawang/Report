using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ReportModel;
namespace DAReport
{
    public class DAWorkLog
    {
        public static void AddWorkLog(WorkLog workLog)
        {
//            string strSQL = @" Insert into workLog(Action,CrUser,CrTime,RelatedData,Loginfo,OriginalData,ModifiedData) 
//                                    values(@Action,@CrUser,@CrTime,@RelatedData,@Loginfo,@OriginalData,@ModifiedData)";
//            SqlParameter[] parms = new SqlParameter[]
//            {
//                 new SqlParameter("@Action",SqlDbType.NVarChar ,45),
//                 new SqlParameter("@CrUser",SqlDbType.NVarChar ,45),
//                 new SqlParameter("@CrTime",SqlDbType.DateTime),
//                 new SqlParameter("@RelatedData",SqlDbType.VarChar ,45),
//                 new SqlParameter("@Loginfo",SqlDbType.Text),
//                 new SqlParameter("@OriginalData",SqlDbType.Text),
//                 new SqlParameter("@ModifiedData",SqlDbType.Text),
//            };
//            parms[0].Value = workLog.Action;
//            parms[1].Value = workLog.EntityInfo.CrUser;
//            parms[2].Value = workLog.EntityInfo.CrTime;
//            parms[3].Value = workLog.RelatedData;
//            parms[4].Value = workLog.LogInfo;
//            parms[5].Value = workLog.OriginalData;
//            parms[6].Value = workLog.ModifiedData;

//            MySqlHelper.ExecuteNonQuery(MySqlDBHelper.ConnectionString, strSQL, parms);
        }

    }
}
