using StackExchange.Redis;

namespace RedisClient.Core
{
	public interface ICacheServerMetricsReader
	{
		bool? IsConnected { get; }
		Version? ServerVersion { get; }
		public ServerType? ServerType { get; }
		public int? DatabaseCount { get; }
		void Init(IRedisServerConnector redisServerConnector);
	}
}
