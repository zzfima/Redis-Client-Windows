using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Plugin.Messenger;
using MvvmCross.ViewModels;
using RedisClient.Core;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RedisClient.MVVMCross.ViewModel
{
	public sealed class ConnectionViewModel : MvxViewModel
	{
		#region Fields
		private string? _ipAddress;
		private IMvxMessenger? _messenger;
		private IRedisServerConnector? _redisServerConnector;
		#endregion

		#region Ctor
		public ConnectionViewModel(IMvxMessenger messenger)
		{
			IpAddress = "172.18.179.119";
			_messenger = messenger;
			_redisServerConnector = Mvx.IoCProvider?.Resolve<IRedisServerConnector>();

			ConnectCommand = new MvxCommand(async () => await Connect());
			DisconnectCommand = new MvxCommand(async () => await Disconnect());
		}
		#endregion

		#region Properties
		public string? IpAddress
		{
			get => _ipAddress;
			set => SetProperty(ref _ipAddress, value);
		}

		public IMvxCommand ConnectCommand { get; }
		public IMvxCommand DisconnectCommand { get; }

		#endregion

		#region Event Handlers
		private async Task Connect()
		{
			await _redisServerConnector?.ConnectAsync(IpAddress);
			_messenger?.Publish<ConnectionChanged>(new ConnectionChanged(this));
		}

		private async Task Disconnect()
		{
			await _redisServerConnector?.DisconnectAsync();
			_messenger?.Publish<ConnectionChanged>(new ConnectionChanged(this));
		}

		#endregion
	}
}
