using StackExchange.Redis;

namespace RedisClient.Core
{
	public sealed class CacheWriter : ICacheWriter
	{
		private IDatabase? _database;

		public async Task RemoveAsync(string key) => await (_database?.KeyDeleteAsync(key) ?? Task.CompletedTask);
		public void Init(IRedisServerConnector redisServerConnector)
		{
			_database = redisServerConnector?.Connection?.GetDatabase();
		}

		public async Task SetAsync(string key, string value) => await (_database?.StringSetAsync(key, value) ?? Task.CompletedTask);
	}
}
