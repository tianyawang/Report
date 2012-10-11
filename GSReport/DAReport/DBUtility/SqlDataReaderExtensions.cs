using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace DAReport.DBUtility
{
    public static class SqlDataReaderExtensions
    {
        public static int GetInt32(this SqlDataReader reader, string name)
        {
            return reader.GetInt32(reader.GetOrdinal(name));
        }

        public static int GetInt16(this SqlDataReader reader, string name)
        {
            return reader.GetInt16(reader.GetOrdinal(name));
        }

        public static string GetString(this SqlDataReader reader, string name)
        {
            int fieldIndex = reader.GetOrdinal(name);
            return reader.IsDBNull(fieldIndex) ? "" : reader.GetString(fieldIndex);
        }

		public static decimal GetDecimal(this SqlDataReader reader, string name)
		{
			int fieldIndex = reader.GetOrdinal(name);
			return reader.IsDBNull(fieldIndex) ? 0 : reader.GetDecimal(fieldIndex);
		}

		public static Int64 GetInt64(this SqlDataReader reader, string name)
		{
			int fieldIndex = reader.GetOrdinal(name);
			return reader.IsDBNull(fieldIndex) ? 0 : reader.GetInt64(fieldIndex);
		}

        public static DateTime GetDateTime(this SqlDataReader reader, string name)
        {
            int fieldIndex = reader.GetOrdinal(name);
            return reader.IsDBNull(fieldIndex) ? DateTime.Now : reader.GetDateTime(fieldIndex);
        }

        public static bool GetBoolean(this SqlDataReader reader, string name)
        {
            return reader.GetBoolean(reader.GetOrdinal(name));
        }

        public static bool IsDBNull(this SqlDataReader reader, string name)
        {
            return reader.IsDBNull(reader.GetOrdinal(name));
        }
    }
}
