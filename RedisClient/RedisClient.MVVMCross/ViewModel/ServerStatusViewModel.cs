using MvvmCross.Plugin.Messenger;
using MvvmCross.ViewModels;
using RedisClient.Core;
using StackExchange.Redis;
using System;

namespace RedisClient.MVVMCross.ViewModel
{
    public sealed class ServerStatusViewModel : MvxViewModel
	{
		private string? _isConnected;
		private IRedisServerConnector? _redisServerConnector;
		private ICacheServerMetricsReader? _cacheServerMetricsReader;
		private IMvxMessenger? _messenger;
		private MvxSubscriptionToken? _token;
		private Version? _serverVersion;
		private int? _databaseCount;
		private ServerType? _serverType;

		public ServerStatusViewModel(IMvxMessenger? messenger, IRedisServerConnector redisServerConnector, ICacheServerMetricsReader cacheServerMetricsReader)
		{
			IsConnected = "";

			_redisServerConnector = redisServerConnector;
			_cacheServerMetricsReader = cacheServerMetricsReader;

			_messenger = messenger;
			_token = _messenger?.Subscribe<ConnectControlClicked>(
				(res) =>
				{
					IsConnected = _cacheServerMetricsReader?.IsConnected == true ? "Server Connected" : "Server Disconnected";
					ServerVersion = _cacheServerMetricsReader?.IsConnected == true ? _cacheServerMetricsReader?.ServerVersion : null;
					ServerType = _cacheServerMetricsReader?.IsConnected == true ? _cacheServerMetricsReader?.ServerType : null;
					DatabaseCount = _cacheServerMetricsReader?.IsConnected == true ? _cacheServerMetricsReader?.DatabaseCount : null;

					_messenger?.Publish(new ConnectToServerChanged(this, _cacheServerMetricsReader?.IsConnected));
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

		public ServerType? ServerType
		{
			get => _serverType;
			set => SetProperty(ref _serverType, value);
		}

		public int? DatabaseCount
		{
			get => _databaseCount;
			set => SetProperty(ref _databaseCount, value);
		}
	}
}
