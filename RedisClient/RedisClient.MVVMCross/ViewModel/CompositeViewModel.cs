using MvvmCross;
using MvvmCross.Plugin.Messenger;
using MvvmCross.ViewModels;

namespace RedisClient.MVVMCross.ViewModel
{
	public sealed class CompositeViewModel : MvxViewModel
	{
		#region Fields
		private ConnectionViewModel? _connectionViewModel;
		private ServerStatusViewModel? _serverStatusViewModel;
		#endregion

		#region Ctor
		public CompositeViewModel(ConnectionViewModel connectionViewModel, ServerStatusViewModel serverStatusViewMode)
		{
			_connectionViewModel = connectionViewModel;
			_serverStatusViewModel = serverStatusViewMode;
		}
		#endregion

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
