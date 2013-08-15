﻿using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using uStorage.ViewModels;

namespace uStorage.Controllers
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
    }
}