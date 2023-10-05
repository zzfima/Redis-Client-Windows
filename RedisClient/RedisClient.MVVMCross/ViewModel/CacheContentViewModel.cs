using MvvmCross.Commands;
using MvvmCross.ViewModels;
using RedisClient.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RedisClient.MVVMCross.ViewModel
{
	public sealed class CacheContentViewModel : MvxViewModel
	{
		#region Fields
		private ICacheReader _cacheReader;
		private MvxObservableCollection<KeyValuePair<string, string>> _cacheContent;
		#endregion

		#region Ctor
		public CacheContentViewModel(IRedisServerConnector redisServerConnector, ICacheReader cacheReader)
		{
			_cacheReader = cacheReader;
			CacheContent = new MvxObservableCollection<KeyValuePair<string, string>>();
			RefreshCommand = new MvxCommand(async () => await Refresh());
		}
		#endregion

		public IMvxCommand RefreshCommand { get; }

		private async Task Refresh()
		{
			var res1 = await _cacheReader.GetAllKeysAsync();
			IList<KeyValuePair<string, string>> cacheItems = new List<KeyValuePair<string, string>>();
			foreach (var item in res1)
			{
				var v = await _cacheReader.GetAsync(item);
				cacheItems.Add(new KeyValuePair<string, string>(item.ToString(), v.ToString()));
			}
			CacheContent = new MvxObservableCollection<KeyValuePair<string, string>>(cacheItems);
		}

		public MvxObservableCollection<KeyValuePair<string, string>> CacheContent
		{
			get => _cacheContent;
			set => SetProperty(ref _cacheContent, value);
		}
	}
}
