using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using System.Web;
using System;
using WrapIoC;

namespace uStorage.Web.Logic
{
    internal class ControllerFactory : IControllerFactory
    {
        #region IControllerFactory

        IController IControllerFactory.CreateController(RequestContext requestContext, string controllerName)
        {
            IController res = null;

            try
            {
                res = IoC.Current.Get<IController>(controllerName);
            }
            catch (IoCException)
            {
                throw new HttpException(404, "The resource could not be found");
            }

            return res;
        }

        SessionStateBehavior IControllerFactory.GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Disabled;
        }

        void IControllerFactory.ReleaseController(IController controller)
        {
            IDisposable disposable = controller as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }

        #endregion
    }
}