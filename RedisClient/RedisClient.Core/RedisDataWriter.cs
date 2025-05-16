using RedisClient.Core.Interfaces;
using StackExchange.Redis;

namespace RedisClient.Core
{
	public sealed class RedisDataWriter : ICacheWriter
	{
		private readonly ICacheServerConnector _redisServerConnector;

		public RedisDataWriter(ICacheServerConnector redisServerConnector)
		{
			_redisServerConnector = redisServerConnector;
		}

		#region Methods
		public async Task RemoveAsync(RedisKey key) => await _redisServerConnector.Connection.GetDatabase().KeyDeleteAsync(key);

		public async Task SetAsync(RedisKey key, RedisValue value) => await _redisServerConnector.Connection.GetDatabase().StringSetAsync(key, value);
		#endregion
	}
}
