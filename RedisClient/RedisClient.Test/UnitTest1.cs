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
			await redisServerConnector.ConnectAsync("127.0.0.1", 6379);

			ICacheServerMetricsReader cacheServerMetricsReader = new CacheServerMetricsReader(redisServerConnector);

			Assert.IsTrue(cacheServerMetricsReader.IsConnected);
			await redisServerConnector.DisconnectAsync();
			Assert.IsFalse(cacheServerMetricsReader.IsConnected);
		}

		[TestMethod]
		public async Task TestRedisWriteRead()
		{
			IRedisServerConnector redisServerConnector = new RedisServerConnector();
			await redisServerConnector.ConnectAsync("127.0.0.1", 6379);

			ICacheWriter cacheWriter = new CacheWriter(redisServerConnector);
			ICacheReader cacheReader = new CacheReader(redisServerConnector);

			await cacheWriter.SetAsync("hello11", "world11");
			var res1 = await cacheReader.GetAsync("hello11");

			Assert.AreEqual("world11", res1.ToString());

			await cacheWriter.RemoveAsync("hello11");

			var res2 = await cacheReader.GetAsync("hello11");
			Assert.IsFalse(res2.HasValue);

			await redisServerConnector.DisconnectAsync();
		}

		[TestMethod]
		public async Task TestRedisGetAllKeys()
		{
			IRedisServerConnector redisServerConnector = new RedisServerConnector();
			await redisServerConnector.ConnectAsync("127.0.0.1", 6379);

			ICacheWriter cacheWriter = new CacheWriter(redisServerConnector);
			ICacheReader cacheReader = new CacheReader(redisServerConnector);

			await cacheWriter.SetAsync("hello11", "world11");
			await cacheWriter.SetAsync("hello12", "world12");
			await cacheWriter.SetAsync("hello13", "world13");

			var res1 = await cacheReader.GetAllKeysAsync();

			Assert.IsTrue(res1.Contains("hello11"));
			Assert.IsTrue(res1.Contains("hello12"));
			Assert.IsTrue(res1.Contains("hello13"));
			Assert.IsFalse(res1.Contains("hello14"));

			await cacheWriter.RemoveAsync("hello11");
			await cacheWriter.RemoveAsync("hello12");
			await cacheWriter.RemoveAsync("hello13");
			await cacheWriter.RemoveAsync("hello14");

			await redisServerConnector.DisconnectAsync();
		}
	}
}