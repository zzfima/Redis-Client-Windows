using MvvmCross.Base;
using MvvmCross.IoC;
using RedisClient.MVVMCross.ViewModel;
using System.Windows;

namespace RedisClient.UI
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		public static IMvxIoCProvider IoCProvider => MvxSingleton<IMvxIoCProvider>.Instance;

		public App()
		{
			ConfigureServices();
		}

		private void ConfigureServices()
		{
			var instance = MvxIoCProvider.Initialize();

			//ViewModels
			instance.ConstructAndRegisterSingleton(typeof(ConnectionViewModel));
			instance.ConstructAndRegisterSingleton(typeof(CompositeViewModel));
		}
	}
}
