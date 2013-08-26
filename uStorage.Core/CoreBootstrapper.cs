using uStorage.Core.IoC;
using uStorage.Core.Services;
using uStorage.Interfaces.Services;
using WrapIoC;

namespace uStorage.Core
{
    public static class CoreBootstrapper
    {
        public static void Initialize()
        {
            WrapIoC.IoC.Init(new NinjectIoC());
            WrapIoC.IoC.Current.Register<IStorageService, StorageService>();
        }
    }
}
