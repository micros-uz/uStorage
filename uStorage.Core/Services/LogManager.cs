using System;
using System.Data.SqlClient;
using System.Web;
using uStorage.Core.DAL;

namespace uStorage.Core.Services
{
    internal static class LogManager
    {
        private static string ToSql(this string st)
        {
            if (st != null)
                return string.Format("'{0}'", st);
            else
                return "null";
        }
        internal static void Log(string action, string obj, string data)
        {
            try
            {
                DbManager.ExecuteNonQuery(string.Format("insert into [dbo].[Log_{{580947B8-E295-4D6C-9E80-FB889A8EB640}}] (Action, Object, Data, [DateTime], IPAddr, HostName, UserAgent) values ({0}, {1}, {2}, '{3}', '{4}', '{5}', '{6}')",
                    action.ToSql(), obj.ToSql(), data.ToSql(),
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), 
                    HttpContext.Current.Request.UserHostAddress,
                    HttpContext.Current.Request.UserHostName,
                    HttpContext.Current.Request.UserAgent));
            }
            catch(SqlException)
            {

            }
        }
    }
}
