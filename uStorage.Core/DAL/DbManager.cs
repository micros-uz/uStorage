using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace uStorage.Core.DAL
{
    internal static class DbManager
    {
        internal static int ExecuteNonQuery(string query)
        {
            var res = -1;
            var connStr = ConfigurationManager.ConnectionStrings["HostingMSSQLSRVConnection"];

            if (connStr != null)
            {
                var conn = new SqlConnection(connStr.ConnectionString);

                try
                {
                    conn.Open();
                    var cmd = new SqlCommand(query, conn);

                    res = cmd.ExecuteNonQuery();
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }

            return res;
        }

        internal static DataTable ExecuteTable(string query)
        {
            DataTable res = null;
            var connStr = ConfigurationManager.ConnectionStrings["HostingMSSQLSRVConnection"];

            if (connStr != null)
            {
                var conn = new SqlConnection(connStr.ConnectionString);

                try
                {
                    conn.Open();
                    var cmd = new SqlCommand(query, conn);

                    var reader = cmd.ExecuteReader();
                    res = new DataTable();
                    res.Load(reader);
                    reader.Close();
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }

            return res;
        }
    }
}
