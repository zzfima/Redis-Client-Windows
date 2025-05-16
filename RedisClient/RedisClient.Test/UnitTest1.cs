using RedisClient.Core;
using RedisClient.Core.Interfaces;

namespace RedisClient.Test
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public async Task TestRedisConnection()
		{
			ICacheServerConnector redisServerConnector = new RedisConnector();
			Assert.IsNotNull(redisServerConnector);
			await redisServerConnector.ConnectAsync("127.0.0.1", 6379);

			ICacheServerMetricsReader cacheServerMetricsReader = new RedisMetricsReader(redisServerConnector);

			Assert.IsTrue(cacheServerMetricsReader.IsConnected);
			await redisServerConnector.DisconnectAsync();
			Assert.IsFalse(cacheServerMetricsReader.IsConnected);
		}

		[TestMethod]
		public async Task TestRedisWriteRead()
		{
			ICacheServerConnector redisServerConnector = new RedisConnector();
			await redisServerConnector.ConnectAsync("127.0.0.1", 6379);

			ICacheWriter cacheWriter = new RedisDataWriter(redisServerConnector);
			ICacheReader cacheReader = new RedisDataReader(redisServerConnector);

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
			ICacheServerConnector redisServerConnector = new RedisConnector();
			await redisServerConnector.ConnectAsync("127.0.0.1", 6379);

			ICacheWriter cacheWriter = new RedisDataWriter(redisServerConnector);
			ICacheReader cacheReader = new RedisDataReader(redisServerConnector);

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