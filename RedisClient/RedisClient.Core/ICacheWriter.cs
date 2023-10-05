using StackExchange.Redis;

namespace RedisClient.Core
{
	public interface ICacheWriter
	{
		Task RemoveAsync(RedisKey key);
		void Init(IRedisServerConnector redisServerConnector);
		Task SetAsync(RedisKey key, RedisValue value);
	}
}
