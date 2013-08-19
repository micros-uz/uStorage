using Ninject;
using WrapIoC;

namespace uStorage.Core.IoC
{
    internal class NinjectIoC : IIoC
    {
        IKernel _Kernel;

        public NinjectIoC()
        {
            _Kernel = new StandardKernel();
        }

        #region IIoC

        void IIoC.Register<TIntf, TImpl>()
        {
            _Kernel.Bind<TIntf>().To<TImpl>();
        }

        void IIoC.Register<TIntf, TImpl>(string name)
        {
            _Kernel.Bind<TIntf>().To<TImpl>().Named(name);
        }

        T IIoC.Get<T>()
        {
            try
            {
                return _Kernel.Get<T>();
            }
            catch (ActivationException ex)
            {
                throw new IoCException(ex.Message);
            }
        }

        T IIoC.Get<T>(string name)
        {
            try
            {
                return _Kernel.Get<T>(name);
            }
            catch (ActivationException ex)
            {
                throw new IoCException(ex.Message);
            }
        }

        #endregion
    }

}
