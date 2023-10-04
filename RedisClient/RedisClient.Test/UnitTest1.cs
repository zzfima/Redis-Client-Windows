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
			await redisServerConnector.ConnectAsync("172.18.179.119");
			Assert.IsTrue(redisServerConnector.IsConnected);
			await redisServerConnector.DisconnectAsync();
			Assert.IsFalse(redisServerConnector.IsConnected);
		}
	}
}