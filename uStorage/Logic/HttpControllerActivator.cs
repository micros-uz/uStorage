using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using uStorage.Web.Web.Controllers.Api;
using WrapIoC;

namespace uStorage.Logic
{
    internal class HttpControllerActivator : IHttpControllerActivator
    {
        private IIoC _ioc;
        internal HttpControllerActivator(IIoC ioc)
        {
            _ioc = ioc;
        }

        private class Release : IDisposable
        {
            private readonly Action _release;

            public Release(Action release)
            {
                _release = release;
            }

            public void Dispose()
            {

                _release();
            }
        }

        #region IHttpControllerActivator

        IHttpController IHttpControllerActivator.Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            var res =  (IHttpController)_ioc.Get(controllerType);

            request.RegisterForDispose(new Release(() => _ioc.Release(res)));

            return res;
        }

        #endregion
    }
}