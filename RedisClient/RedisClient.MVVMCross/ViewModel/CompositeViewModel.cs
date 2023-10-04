using MvvmCross;
using MvvmCross.ViewModels;

namespace RedisClient.MVVMCross.ViewModel
{
	public sealed class CompositeViewModel : MvxViewModel
	{
		private ConnectionViewModel _connectionViewModel;

		public CompositeViewModel()
		{
			InstantiateViewModel();
		}

		private void InstantiateViewModel()
		{
			_connectionViewModel = Mvx.IoCProvider.Resolve<ConnectionViewModel>();
		}

		#region Dependency Properties

		public ConnectionViewModel ConnectionViewModel
		{
			get => _connectionViewModel;
			set => SetProperty(ref _connectionViewModel, value);
		}
		#endregion
	}
}
