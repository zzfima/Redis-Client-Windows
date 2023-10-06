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
		private CacheContentViewModel? _cacheContentViewModel;
		private StatusPanelViewModel? _statusPanelViewModel;
		#endregion

		#region Ctor
		public CompositeViewModel(
			ConnectionViewModel connectionViewModel,
			ServerStatusViewModel serverStatusViewMode,
			CacheContentViewModel cacheContentViewModel,
			StatusPanelViewModel statusPanelViewModel)
		{
			ConnectionViewModel = connectionViewModel;
			ServerStatusViewModel = serverStatusViewMode;
			CacheContentViewModel = cacheContentViewModel;
			StatusPanelViewModel = statusPanelViewModel;
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

		public CacheContentViewModel? CacheContentViewModel
		{
			get => _cacheContentViewModel;
			set => SetProperty(ref _cacheContentViewModel, value);
		}

		public StatusPanelViewModel? StatusPanelViewModel
		{
			get => _statusPanelViewModel;
			set => SetProperty(ref _statusPanelViewModel, value);
		}
		#endregion
	}
}
