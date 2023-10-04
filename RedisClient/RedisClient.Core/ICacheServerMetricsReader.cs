namespace RedisClient.Core
{
	public interface ICacheServerMetricsReader
	{
		bool? IsConnected { get; }
		Version? ServerVersion { get; }
		void Init(IRedisServerConnector redisServerConnector);
	}
}
