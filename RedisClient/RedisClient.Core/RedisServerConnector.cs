using StackExchange.Redis;
using System.Net;

namespace RedisClient.Core
{
	public sealed class RedisServerConnector : IRedisServerConnector
	{
		public async Task ConnectAsync(string ipAddress)
		{
			IPAddress = ipAddress;
			Connection = await ConnectionMultiplexer.ConnectAsync(IPAddress);
		}


		public async Task DisconnectAsync() => await Connection.DisposeAsync();

		public ConnectionMultiplexer? Connection { get; private set; }

		public string? IPAddress { get; private set; }
	}
}