using ElFinder.Sample.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using uStorage.Core;
using uStorage.Logic;
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

            ControllerBuilder.Current.SetControllerFactory(new ControllerFactory());

            // mvc controllers
            IoC.Current.Register<IController, FilesController>("files");
            IoC.Current.Register<IController, IndexController>("index");
            IoC.Current.Register<IController, SqlManagerController>("sqlmanager");
            IoC.Current.Register<IController, HomeController>("home");
            // api controllers
            IoC.Current.Register<AccountController, AccountController>();
            IoC.Current.Register<StorageController, StorageController>();
            
            GlobalConfiguration.Configuration.Services.Replace(

                typeof(IHttpControllerActivator), new HttpControllerActivator(IoC.Current));

        }
    }
}