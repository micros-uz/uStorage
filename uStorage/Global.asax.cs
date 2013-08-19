using ElFinder.Sample.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using uStorage.Core;
using uStorage.Web.Controllers;
using uStorage.Web.Logic;
using uStorage.Web.Web.Controllers.Api;
using WrapIoC;

namespace uStorage
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            CoreBootstrapper.Initialize();

            //ControllerBuilder.Current.SetControllerFactory(new ControllerFactory());

            IoC.Current.Register<IController, FilesController>("Files");
            IoC.Current.Register<IController, IndexController>("Index");
            IoC.Current.Register<IController, SqlManagerController>("SqlManager");
            IoC.Current.Register<IController, HomeController>("Home");
        }
    }
}