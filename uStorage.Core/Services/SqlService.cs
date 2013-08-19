using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using uStorage.Interfaces.Services;

namespace uStorage.Core.Services
{
    internal class SqlService : ISqlCRUDService
    {
        #region ISqlService
        Tuple<bool, string> ISqlCRUDService.TestConnection()
        {
            var connStr = ConfigurationManager.ConnectionStrings["HostingMSSQLSRVConnection"];
            var isConnected = false;
            var errInfo = string.Empty;

            if (connStr != null)
            {
                var conn = new SqlConnection(connStr.ConnectionString);

                try
                {
                    conn.Open();
                    isConnected = true;
                }
                catch (Exception ex)
                {
                    errInfo = ex.Message;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }

            return Tuple.Create(isConnected, errInfo);
            
        }

        #endregion
    }
}
