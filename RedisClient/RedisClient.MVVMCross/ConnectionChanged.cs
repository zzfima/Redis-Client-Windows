namespace RedisClient.MVVMCross
{
	public class ConnectionChanged : MvvmCross.Plugin.Messenger.MvxMessage
	{
		public ConnectionChanged(object sender) : base(sender)
		{
		}
	}
}