using StackExchange.Redis;

namespace RedisClient.Core
{
	public sealed class CacheReader : ICacheReader
	{
		#region Fields
		private IRedisServerConnector _redisServerConnector;
		#endregion

		public CacheReader(IRedisServerConnector redisServerConnector)
		{
			_redisServerConnector = redisServerConnector;
		}

		#region Properties
		public async Task<RedisValue> GetAsync(RedisKey key) => await _redisServerConnector?.Connection?.GetDatabase().StringGetAsync(key);

		public async Task<IEnumerable<RedisKey>> GetAllKeysAsync() => await Task.Run(
			() => _redisServerConnector.Connection.GetServer($"{_redisServerConnector.IPAddress}:{_redisServerConnector.Port}").Keys());

		#endregion
	}
}
