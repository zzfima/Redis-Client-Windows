﻿using MvvmCross.Base;
using MvvmCross.IoC;
using MvvmCross.Plugin.Messenger;
using RedisClient.Core;
using RedisClient.Core.Interfaces;
using RedisClient.MVVMCross.ViewModel;
using System.Windows;

namespace RedisClient.UI
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		public static IMvxIoCProvider? IoCProvider => MvxSingleton<IMvxIoCProvider>.Instance;

		public App()
		{
			ConfigureServices();
		}

		private void ConfigureServices()
		{
			var instance = MvxIoCProvider.Initialize();

			//Core
			instance.ConstructAndRegisterSingleton<IMvxMessenger, MvxMessengerHub>();
			instance.ConstructAndRegisterSingleton<ICacheServerConnector, RedisConnector>();
			instance.ConstructAndRegisterSingleton<ICacheServerMetricsReader, RedisMetricsReader>();
			instance.ConstructAndRegisterSingleton<ICacheWriter, RedisDataWriter>();
			instance.ConstructAndRegisterSingleton<ICacheReader, RedisDataReader>();
			instance.ConstructAndRegisterSingleton<IIDReader, RedisIDReader>();

			//ViewModels
			instance.ConstructAndRegisterSingleton(typeof(ConnectionViewModel));
			instance.ConstructAndRegisterSingleton(typeof(ServerStatusViewModel));
			instance.ConstructAndRegisterSingleton(typeof(CacheContentViewModel));
			instance.ConstructAndRegisterSingleton(typeof(StatusPanelViewModel));
			instance.ConstructAndRegisterSingleton(typeof(CompositeViewModel));
		}
	}
}
