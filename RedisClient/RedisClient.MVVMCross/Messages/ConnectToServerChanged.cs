namespace RedisClient.MVVMCross.Messages
{
	public class ConnectToServerChanged : MvvmCross.Plugin.Messenger.MvxMessage
	{
		public bool? IsConnected { get; }
		public ConnectToServerChanged(object sender, bool? isConnected) : base(sender)
		{
			IsConnected = isConnected;
		}
	}
}