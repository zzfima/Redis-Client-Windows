using RedisClient.Core.Interfaces;
using StackExchange.Redis;

namespace RedisClient.Core
{
	public sealed class RedisConnector : ICacheServerConnector
	{
		#region Properties
		public ConnectionMultiplexer? Connection { get; private set; }
		public string? IPAddress { get; private set; }
		public int? Port { get; private set; }
		#endregion

		#region Methods
		public async Task DisconnectAsync() => await Connection.DisposeAsync();

		public async Task ConnectAsync(string ipAddress, int port)
		{
			IPAddress = ipAddress;
			Port = port;
			Connection = await ConnectionMultiplexer.ConnectAsync($"{IPAddress}:{Port}");
		}
		#endregion
	}
}