﻿using StackExchange.Redis;

namespace RedisClient.Core
{
	public sealed class CacheReader : ICacheReader
	{
		private IDatabase? _database;

		public async Task<string> GetAsync(string key) => await _database.StringGetAsync(key);

		public void Init(IRedisServerConnector redisServerConnector)
		{
			_database = redisServerConnector?.Connection?.GetDatabase();
		}
	}
}
