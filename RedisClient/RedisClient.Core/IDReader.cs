using StackExchange.Redis;

namespace RedisClient.Core
{
	public sealed class IDReader : IIDReader
	{
		private readonly ICacheServerConnector _redisServerConnector;
		#region Fields
		private IDatabase _redisServerDb;
		#endregion

		public IDReader(ICacheServerConnector redisServerConnector)
		{
			_redisServerConnector = redisServerConnector;
		}

		#region Properties
		public async Task<long> GetNextIdAsync(string key)
		{
			if (_redisServerDb == null)
				_redisServerDb = _redisServerConnector?.Connection?.GetDatabase();

			return await _redisServerDb.StringIncrementAsync(key);
		}
		#endregion
	}
}
