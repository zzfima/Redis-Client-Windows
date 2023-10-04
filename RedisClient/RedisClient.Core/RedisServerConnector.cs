using StackExchange.Redis;

namespace RedisClient.Core
{
	public sealed class RedisServerConnector : IRedisServerConnector
	{
		public async Task ConnectAsync(string configuration)
		{
			Connection = await ConnectionMultiplexer.ConnectAsync(configuration);
		}

		public async Task DisconnectAsync() => await Connection.DisposeAsync();

		public ConnectionMultiplexer? Connection { get; private set; }
	}
}