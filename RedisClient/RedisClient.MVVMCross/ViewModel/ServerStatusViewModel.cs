using MvvmCross.ViewModels;

namespace RedisClient.MVVMCross.ViewModel
{
	public sealed class ServerStatusViewModel : MvxViewModel
	{
		private string _serverAlive;

		public ServerStatusViewModel()
		{
			ServerAlive = "server up";
		}

		public string ServerAlive
		{
			get => _serverAlive;
			set => SetProperty(ref _serverAlive, value);
		}
	}
}
