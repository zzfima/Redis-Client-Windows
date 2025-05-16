using StackExchange.Redis;

namespace RedisClient.Core.Interfaces
{
	public interface IIDReader
	{
		Task<long> GetNextIdAsync(string key);
	}
}
