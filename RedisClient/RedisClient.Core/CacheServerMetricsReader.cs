using StackExchange.Redis;

namespace RedisClient.Core
{
	public sealed class CacheServerMetricsReader : ICacheServerMetricsReader
	{
		#region Fields
		private IRedisServerConnector? _redisServerConnector;
		#endregion

		public void Init(IRedisServerConnector redisServerConnector) => _redisServerConnector = redisServerConnector;
		public bool? IsConnected => _redisServerConnector?.Connection?.IsConnected;
		public Version? ServerVersion => _redisServerConnector?.Connection.GetServer($"{_redisServerConnector.IPAddress}:6379").Version;
	}
}
