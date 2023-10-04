using StackExchange.Redis;

namespace RedisClient.Core
{
	public sealed class CacheReader : ICacheReader
	{
		private IDatabase? _database;

		public string? Get(string key) => _database?.StringGet(key);

		public void Init(IRedisServerConnector redisServerConnector)
		{
			_database = redisServerConnector?.Connection?.GetDatabase();
		}
	}
}
