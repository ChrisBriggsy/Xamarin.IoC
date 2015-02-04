using System;
using Android.App;
using Android.Runtime;
using Cirrious.CrossCore;
using IoCDemo.Core;
using Cirrious.CrossCore.IoC;
using Akavache;

namespace MvvmCrossDemo.Droid
{
	[Application(Icon="@drawable/icon", Label="@string/app_name")]
	public class App : Application
	{
		public App(IntPtr h, JniHandleOwnership jho) : base(h, jho)
		{
		}

		public override void OnCreate()
		{
            BlobCache.ApplicationName = "MahTestApp";
            BlobCache.EnsureInitialized();
            MvxSimpleIoCContainer.Initialize ();
            Mvx.RegisterSingleton<IBlobCache>(() => BlobCache.LocalMachine);
			Mvx.RegisterType<IPlatform, DroidPlatform> ();
			Mvx.RegisterType<ISettings, DroidSettings> ();

			base.OnCreate();
		}
	}
}