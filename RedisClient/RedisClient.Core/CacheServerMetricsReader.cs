﻿using StackExchange.Redis;

namespace RedisClient.Core
{
	public sealed class CacheServerMetricsReader : ICacheServerMetricsReader
	{
		#region Fields
		private IRedisServerConnector? _redisServerConnector;
		#endregion

		#region Properties
		public void Init(IRedisServerConnector redisServerConnector) => _redisServerConnector = redisServerConnector;
		public bool? IsConnected => _redisServerConnector?.Connection?.IsConnected;
		public Version? ServerVersion => _redisServerConnector?.Connection.GetServer($"{_redisServerConnector.IPAddress}:{_redisServerConnector.Port}").Version;
		public ServerType? ServerType => _redisServerConnector?.Connection.GetServer($"{_redisServerConnector.IPAddress}:{_redisServerConnector.Port}").ServerType;
		public int? DatabaseCount => _redisServerConnector?.Connection.GetServer($"{_redisServerConnector.IPAddress}:{_redisServerConnector.Port}").DatabaseCount;
		#endregion
	}
}
