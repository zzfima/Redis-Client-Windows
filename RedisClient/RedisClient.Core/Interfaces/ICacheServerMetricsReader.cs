using StackExchange.Redis;

namespace RedisClient.Core.Interfaces
{
	public interface ICacheServerMetricsReader
	{
		bool? IsConnected { get; }
		Version? ServerVersion { get; }
		public ServerType? ServerType { get; }
		public int? DatabaseCount { get; }
	}
}
