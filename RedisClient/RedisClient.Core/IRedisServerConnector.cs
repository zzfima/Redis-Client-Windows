using StackExchange.Redis;

namespace RedisClient.Core
{
	public interface IRedisServerConnector
	{
		ConnectionMultiplexer? Connection { get; }
		bool? IsConnected { get; }

		Task ConnectAsync(string configuration);
		Task DisconnectAsync();
	}
}
