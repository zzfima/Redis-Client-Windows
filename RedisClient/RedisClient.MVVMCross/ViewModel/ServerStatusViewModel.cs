using MvvmCross;
using MvvmCross.Plugin.Messenger;
using MvvmCross.ViewModels;
using RedisClient.Core;
using System;

namespace RedisClient.MVVMCross.ViewModel
{
	public sealed class ServerStatusViewModel : MvxViewModel
	{
		private string? _isConnected;
		private IRedisServerConnector? _redisServerConnector;
		private ICacheServerMetricsReader? _cacheServerMetricsReader;
		private IMvxMessenger? _messenger;
		private MvxSubscriptionToken? _tokenWindowHelp;
		private Version? _serverVersion;

		public ServerStatusViewModel(IMvxMessenger? messenger)
		{
			IsConnected = "";

			_redisServerConnector = Mvx.IoCProvider?.Resolve<IRedisServerConnector>();
			_cacheServerMetricsReader = Mvx.IoCProvider?.Resolve<ICacheServerMetricsReader>();
			if (_redisServerConnector != null)
				_cacheServerMetricsReader?.Init(_redisServerConnector);

			_messenger = messenger;
			_tokenWindowHelp = _messenger?.Subscribe<ConnectionChanged>(
				(res) =>
				{
					IsConnected = _cacheServerMetricsReader?.IsConnected == true ? "Server Connected" : "Server Disconnected";
					ServerVersion = _cacheServerMetricsReader?.IsConnected == true ? _cacheServerMetricsReader?.ServerVersion : null;
				});
		}

		public string? IsConnected
		{
			get => _isConnected;
			set => SetProperty(ref _isConnected, value);
		}

		public Version? ServerVersion
		{
			get => _serverVersion;
			set => SetProperty(ref _serverVersion, value);
		}
	}
}
