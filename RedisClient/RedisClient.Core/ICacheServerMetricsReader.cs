namespace RedisClient.Core
{
	public interface ICacheServerMetricsReader
	{
		bool? IsConnected { get; }
		void Init(IRedisServerConnector redisServerConnector);
	}
}
