using StackExchange.Redis;

namespace RedisClient.Core
{
	public interface IRedisServerConnector
	{
		ConnectionMultiplexer? Connection { get; }
		bool? IsConnected { get; }

		void Connect(string configuration);
		void Disconnect();
	}
}
