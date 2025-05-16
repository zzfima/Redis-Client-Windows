namespace RedisClient.MVVMCross.Messages
{
	public class StatusChanged : MvvmCross.Plugin.Messenger.MvxMessage
	{
		public string? NewStatus { get; }
		public StatusChanged(object sender, string? newStatus) : base(sender)
		{
			NewStatus = newStatus;
		}
	}
}