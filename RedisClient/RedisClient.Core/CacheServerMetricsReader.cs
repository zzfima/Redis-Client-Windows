using StackExchange.Redis;

namespace RedisClient.Core
{
	public sealed class CacheServerMetricsReader : ICacheServerMetricsReader
	{
		#region Fields
		private ConnectionMultiplexer? _connection;
		#endregion

		public void Init(IRedisServerConnector redisServerConnector) => _connection = redisServerConnector.Connection;
		public bool? IsConnected => _connection?.IsConnected;
	}
}
