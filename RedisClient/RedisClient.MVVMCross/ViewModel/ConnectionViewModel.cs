using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace RedisClient.MVVMCross.ViewModel
{
	public sealed class ConnectionViewModel : MvxViewModel
	{
		#region Fields
		private string? _ipAddress;
		private int _port;
		private bool _isConnectionOk;
		#endregion

		#region Ctor
		public ConnectionViewModel()
		{
			IpAddress = "127.0.0.1";
			Port = 7778;
			IsConnectionOk = false;

			TestConnectionCommand = new MvxCommand(TestConnection);
			ConnectCommand = new CustomRelayCommand((o) => IsConnectionOk == true, Connect);
		}
		#endregion

		#region Properties
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

		public bool IsConnectionOk
		{
			get => _isConnectionOk;
			set => SetProperty(ref _isConnectionOk, value);
		}

		public IMvxCommand TestConnectionCommand { get; }
		public ICommand ConnectCommand { get; }
		#endregion


		#region Event Handlers
		private void Connect(object o)
		{
			IsConnectionOk = false;
		}

		private void TestConnection()
		{
			IsConnectionOk = true;
		}
		#endregion
	}
}
