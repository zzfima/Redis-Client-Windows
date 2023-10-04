namespace RedisClient.Core
{
	public interface ICacheReader
	{
		void Init(IRedisServerConnector redisServerConnector);
		string? Get(string key);
	}
}
