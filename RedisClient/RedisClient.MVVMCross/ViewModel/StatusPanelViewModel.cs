using MvvmCross.Plugin.Messenger;
using MvvmCross.ViewModels;
using RedisClient.MVVMCross.Messages;

namespace RedisClient.MVVMCross.ViewModel
{
	public sealed class StatusPanelViewModel : MvxViewModel
	{
		private MvxSubscriptionToken? _token;
		private string? _status;

		public StatusPanelViewModel(IMvxMessenger messenger)
		{
			_token = messenger?.Subscribe<StatusChanged>((res) =>
			{
				Status = res.NewStatus;
			});
		}

		public string? Status
		{
			get => _status;
			set => SetProperty(ref _status, value);
		}
	}
}
