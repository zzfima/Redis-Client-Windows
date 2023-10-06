using StackExchange.Redis;

namespace RedisClient.Core
{
	public sealed class CacheWriter : ICacheWriter
	{
		private readonly IRedisServerConnector _redisServerConnector;

		public CacheWriter(IRedisServerConnector redisServerConnector)
		{
			_redisServerConnector = redisServerConnector;
		}

		#region Methods
		public async Task RemoveAsync(RedisKey key) => await _redisServerConnector.Connection.GetDatabase().KeyDeleteAsync(key);

		public async Task SetAsync(RedisKey key, RedisValue value) => await _redisServerConnector.Connection.GetDatabase().StringSetAsync(key, value);
		#endregion
	}
}
