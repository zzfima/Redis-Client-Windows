using StackExchange.Redis;
using System.Threading.Tasks;

namespace RedisClient.Core
{
	public interface ICacheReader
	{
		void Init(IRedisServerConnector redisServerConnector);
		Task<RedisValue> GetAsync(RedisKey key);
		Task<IEnumerable<RedisKey>> GetAllKeysAsync();
	}
}
