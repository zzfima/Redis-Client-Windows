using RedisClient.Core;

namespace RedisClient.Test
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public async Task TestRedisConnection()
		{
			IRedisServerConnector redisServerConnector = new RedisServerConnector();
			Assert.IsNotNull(redisServerConnector);
			await redisServerConnector.ConnectAsync("172.18.179.119", 6379);

			ICacheServerMetricsReader cacheServerMetricsReader = new CacheServerMetricsReader();
			cacheServerMetricsReader.Init(redisServerConnector);

			Assert.IsTrue(cacheServerMetricsReader.IsConnected);
			await redisServerConnector.DisconnectAsync();
			Assert.IsFalse(cacheServerMetricsReader.IsConnected);
		}

		[TestMethod]
		public async Task TestRedisWriteRead()
		{
			IRedisServerConnector redisServerConnector = new RedisServerConnector();
			await redisServerConnector.ConnectAsync("172.18.179.119", 6379);

			ICacheWriter cacheWriter = new CacheWriter();
			ICacheReader cacheReader = new CacheReader();

			cacheWriter.Init(redisServerConnector);
			cacheReader.Init(redisServerConnector);

			await cacheWriter.SetAsync("hello11", "world11");
			var res1 = await cacheReader.GetAsync("hello11");

			Assert.AreEqual("world11", res1);

			await cacheWriter.RemoveAsync("hello11");

			var res2 = await cacheReader.GetAsync("hello11");
			Assert.IsNull(res2);

			await redisServerConnector.DisconnectAsync();
		}
	}
}