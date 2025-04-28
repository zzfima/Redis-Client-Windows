using StackExchange.Redis;

namespace RedisClient.Core
{
	public interface IIDReader
	{
		Task<long> GetNextIdAsync(string key);
	}
}
