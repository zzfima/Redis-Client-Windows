using StackExchange.Redis;

namespace RedisClient.Core.Interfaces
{
	public interface ICacheReader
	{
		Task<RedisValue> GetAsync(RedisKey key);
		Task<IEnumerable<RedisKey>> GetAllKeysAsync();
	}
}
