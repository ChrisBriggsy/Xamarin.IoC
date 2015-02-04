using Akavache;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Reactive.Linq;
namespace IoCDemo.Core
{
	public class MainViewModel
	{
		private readonly IPlatform _platform;
		private readonly ISettings _settings;
        private readonly IBlobCache _cache;
        private string _meh;
		public MainViewModel (IPlatform platform, ISettings settings, IBlobCache cache)
		{
			_settings = settings;
			_platform = platform;
            _cache = cache;
		}

		public string PlatformName
		{
			get {
				return _platform.GetPlatformName ();
			}
		}

		public string ContainerName
		{
			get {
				return _platform.ContainerName;
			}
		}

		public string UserName
		{
			get {
				return _settings.UserName;
			}
		}

		public string Password
		{
			get {
				return _settings.Password;
			}
		}

        public string MyRandomCachedItem
        {
            get{
                return Task.Run(async () =>
                {
                    try{
                    return await _cache.GetObject<string>("myCachedItem");
                    }
                    catch(KeyNotFoundException)
                    {
                        var guid = Guid.NewGuid().ToString();
                        await _cache.InsertObject<string>("myCachedItem", guid);
                        return guid;
                    }
                }).Result;
            }
        }
	}
}