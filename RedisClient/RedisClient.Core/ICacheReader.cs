namespace RedisClient.Core
{
	public interface ICacheReader
	{
		void Init(IRedisServerConnector redisServerConnector);
		Task<string> GetAsync(string key);
	}
}
