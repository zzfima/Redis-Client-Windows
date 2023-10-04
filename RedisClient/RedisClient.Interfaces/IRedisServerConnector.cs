namespace RedisClient.Interfaces
{
	public interface IRedisServerConnector
	{
		global::StackExchange.Redis.ConnectionMultiplexer? Connection { get; }

		public void Connect(string configuration);
	}
}
