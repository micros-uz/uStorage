using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using uStorage.ViewModels;

namespace uStorage.Controllers
{
    public class SqlManagerController : Controller
    {
        public ActionResult Index()
        {
            var connStr = ConfigurationManager.ConnectionStrings["HostingMSSQLSRVConnection"];
            var model = new SqlManagerInfoModel();

            if (connStr != null)
            {
                model.ConnString = connStr.ConnectionString;
                var conn = new SqlConnection(connStr.ConnectionString);

                try
                {
                    conn.Open();
                    model.ConnectionTestResult = true;
                }
                catch (Exception ex)
                {
                    model.ErrorInfo = ex.Message;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }

            return View(model);
        }
    }
}
