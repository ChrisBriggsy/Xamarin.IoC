using IoCDemo.Core;

namespace NinjectDemo.iOS
{
	public class AppleSettings : ISettings
	{
		public string UserName {
			get {
				return "SteveJobs@apple.com";
			}
		}
		public string Password {
			get {
				return "whyPayLess?";
			}
		}
	}
}