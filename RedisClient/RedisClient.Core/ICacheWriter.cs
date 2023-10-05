using StackExchange.Redis;

namespace RedisClient.Core
{
	public interface ICacheWriter
	{
		Task RemoveAsync(RedisKey key);
		Task SetAsync(RedisKey key, RedisValue value);
	}
}
