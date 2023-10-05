using StackExchange.Redis;

namespace RedisClient.Core
{
	public sealed class CacheReader : ICacheReader
	{
		#region Fields
		private IDatabase? _database;
		private IRedisServerConnector _redisServerConnector;
		#endregion

		#region Properties
		public async Task<RedisValue> GetAsync(RedisKey key) => await _database.StringGetAsync(key);

		public async Task<IEnumerable<RedisKey>> GetAllKeysAsync() => await Task.Run(
			() => _redisServerConnector.Connection.GetServer($"{_redisServerConnector.IPAddress}:{_redisServerConnector.Port}").Keys());

		#endregion

		#region Methods
		public void Init(IRedisServerConnector redisServerConnector)
		{
			_redisServerConnector = redisServerConnector;
			_database = _redisServerConnector?.Connection?.GetDatabase();
		}
		#endregion
	}
}
