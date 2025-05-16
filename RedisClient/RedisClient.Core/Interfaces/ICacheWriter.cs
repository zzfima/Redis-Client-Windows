using StackExchange.Redis;

namespace RedisClient.Core.Interfaces
{
	public interface ICacheWriter
	{
		Task RemoveAsync(RedisKey key);
		Task SetAsync(RedisKey key, RedisValue value);
	}
}
