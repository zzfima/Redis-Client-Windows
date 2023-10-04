using StackExchange.Redis;

namespace RedisClient.Core
{
	public sealed class RedisServerConnector : IRedisServerConnector
	{
		public void Connect(string configuration)
		{
			Connection = ConnectionMultiplexer.Connect(configuration);
		}

		public void Disconnect() => Connection?.Dispose();

		public ConnectionMultiplexer? Connection { get; private set; }

		public bool? IsConnected => Connection?.IsConnected;
	}
}