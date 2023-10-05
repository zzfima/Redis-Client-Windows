using StackExchange.Redis;

namespace RedisClient.Core
{
	public interface IRedisServerConnector
	{
		ConnectionMultiplexer? Connection { get; }
		Task ConnectAsync(string ipAddress, int port);
		Task DisconnectAsync();
		string? IPAddress { get; }
		int? Port { get; }
	}
}
