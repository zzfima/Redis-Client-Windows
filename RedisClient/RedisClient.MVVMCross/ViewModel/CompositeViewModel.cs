using MvvmCross;
using MvvmCross.Plugin.Messenger;
using MvvmCross.ViewModels;

namespace RedisClient.MVVMCross.ViewModel
{
	public sealed class CompositeViewModel : MvxViewModel
	{
		private ConnectionViewModel? _connectionViewModel;
		private ServerStatusViewModel? _serverStatusViewModel;

		public CompositeViewModel()
		{
			InstantiateViewModel();
		}

		private void InstantiateViewModel()
		{
			_connectionViewModel = Mvx.IoCProvider?.Resolve<ConnectionViewModel>();
			_serverStatusViewModel = Mvx.IoCProvider?.Resolve<ServerStatusViewModel>();
		}

		#region Dependency Properties

		public ConnectionViewModel? ConnectionViewModel
		{
			get => _connectionViewModel;
			set => SetProperty(ref _connectionViewModel, value);
		}

		public ServerStatusViewModel? ServerStatusViewModel
		{
			get => _serverStatusViewModel;
			set => SetProperty(ref _serverStatusViewModel, value);
		}
		#endregion
	}
}
