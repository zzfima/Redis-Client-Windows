using MvvmCross.ViewModels;

namespace RedisClient.MVVMCross.ViewModel
{
	public sealed class ConnectionViewModel : MvxViewModel
	{
		private string? _ipAddress;
		private int _port;

		public ConnectionViewModel()
		{
			IpAddress = "127.0.0.1";
			Port = 7778;
		}

		public string? IpAddress
		{
			get => _ipAddress;
			set => SetProperty(ref _ipAddress, value);
		}

		public int Port
		{
			get => _port;
			set => SetProperty(ref _port, value);
		}
	}
}
