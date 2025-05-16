using StackExchange.Redis;

namespace RedisClient.Core.Interfaces
{
	public interface ICacheServerConnector
	{
		ConnectionMultiplexer? Connection { get; }
		Task ConnectAsync(string ipAddress, int port);
		Task DisconnectAsync();
		string? IPAddress { get; }
		int? Port { get; }
	}
}
