using StackExchange.Redis;

namespace RedisClient.Core
{
	public sealed class CacheReader : ICacheReader
	{
		#region Fields
		private IDatabase? _database;
		#endregion

		#region Properties
		public async Task<string> GetAsync(string key) => await _database?.StringGetAsync(key);
		#endregion

		#region Methods
		public void Init(IRedisServerConnector redisServerConnector) => _database = redisServerConnector?.Connection?.GetDatabase();
		#endregion
	}
}
