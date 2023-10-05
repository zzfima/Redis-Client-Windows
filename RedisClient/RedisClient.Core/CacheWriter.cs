using StackExchange.Redis;

namespace RedisClient.Core
{
	public sealed class CacheWriter : ICacheWriter
	{
		#region Fields
		private IDatabase? _database;
		#endregion

		#region Methods
		public async Task RemoveAsync(RedisKey key) => await (_database?.KeyDeleteAsync(key) ?? Task.CompletedTask);

		public void Init(IRedisServerConnector redisServerConnector)
		{
			_database = redisServerConnector?.Connection?.GetDatabase();
		}

		public async Task SetAsync(RedisKey key, RedisValue value) => await (_database?.StringSetAsync(key, value) ?? Task.CompletedTask);
		#endregion
	}
}
