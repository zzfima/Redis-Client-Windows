using RedisClient.Core.Interfaces;
using StackExchange.Redis;

namespace RedisClient.Core
{
	public sealed class RedisDataReader : ICacheReader
	{
		#region Fields
		private ICacheServerConnector _redisServerConnector;
		#endregion

		public RedisDataReader(ICacheServerConnector redisServerConnector)
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
