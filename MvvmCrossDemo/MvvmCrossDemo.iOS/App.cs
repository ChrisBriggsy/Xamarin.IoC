using Cirrious.CrossCore;
using IoCDemo.Core;
using Cirrious.CrossCore.IoC;
using Akavache;

namespace MvvmCrossDemo.iOS
{
	public static class App
	{
		public static void Initialize ()
		{
            BlobCache.ApplicationName = "MahTestApp";
            BlobCache.EnsureInitialized();
			MvxSimpleIoCContainer.Initialize ();
            Mvx.RegisterSingleton<IBlobCache>(() => BlobCache.LocalMachine);
			Mvx.RegisterType<IPlatform, ApplePlatform> ();
			Mvx.RegisterType<ISettings, AppleSettings> ();

		}
	}
}