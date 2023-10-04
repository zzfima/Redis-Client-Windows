namespace RedisClient.Core
{
	public interface ICacheWriter
	{
		Task RemoveAsync(string key);
		void Init(IRedisServerConnector redisServerConnector);
		Task SetAsync(string key, string value);
	}
}
