using RedisClient.Core;

namespace RedisClient.Test
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestRedisConnection()
		{
			IRedisServerConnector redisServerConnector = new RedisServerConnector();
			Assert.IsNotNull(redisServerConnector);
			redisServerConnector.Connect("172.18.179.119");
			Assert.IsTrue(redisServerConnector.IsConnected);
			redisServerConnector.Disconnect();
			Assert.IsFalse(redisServerConnector.IsConnected);
		}
	}
}