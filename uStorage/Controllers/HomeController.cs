using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using uStorage.Web.ViewModels;

namespace uStorage.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Processes()
        {
            var model = Process.GetProcesses().Select(x => new ProcessModel
                {
                    Name = x.ProcessName,
                    WorkingSet = x.WorkingSet64
                });
            
            return View(model.OrderBy(x => x.Name));
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            return null;
        }

        public ActionResult AddTable()
        {
            return View();
        }
    }
}
