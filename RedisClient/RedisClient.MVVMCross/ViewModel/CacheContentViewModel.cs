using MvvmCross.Commands;
using MvvmCross.ViewModels;
using RedisClient.Core;
using StackExchange.Redis;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RedisClient.MVVMCross.ViewModel
{
	public sealed class CacheContentViewModel : MvxViewModel
	{
		#region Fields
		private readonly ICacheReader _cacheReader;
		private readonly ICacheWriter _cacheWriter;
		private string? _keyToAdd;
		private MvxObservableCollection<KeyValuePair<RedisKey, RedisValue>> _cacheContent;
		private KeyValuePair<RedisKey, RedisValue> _selectedCacheContent;
		private string? _valueToAdd;
		#endregion

		#region Ctor
		public CacheContentViewModel(IRedisServerConnector redisServerConnector, ICacheReader cacheReader, ICacheWriter cacheWriter)
		{
			_cacheReader = cacheReader;
			_cacheWriter = cacheWriter;
			CacheContent = new MvxObservableCollection<KeyValuePair<RedisKey, RedisValue>>();
			RefreshCommand = new MvxCommand(async () => await Refresh());
			DeleteCommand = new MvxCommand(async () => await Delete());
			AddCommand = new MvxCommand(async () => await Add());
		}
		#endregion

		public IMvxCommand RefreshCommand { get; }
		public IMvxCommand DeleteCommand { get; }
		public IMvxCommand AddCommand { get; }

		private async Task Refresh()
		{
			var res1 = await _cacheReader.GetAllKeysAsync();
			IList<KeyValuePair<RedisKey, RedisValue>> cacheItems = new List<KeyValuePair<RedisKey, RedisValue>>();
			foreach (var item in res1)
			{
				var v = await _cacheReader.GetAsync(item);
				cacheItems.Add(new KeyValuePair<RedisKey, RedisValue>(item, v));
			}
			CacheContent = new MvxObservableCollection<KeyValuePair<RedisKey, RedisValue>>(cacheItems);
		}

		private async Task Delete()
		{
			await _cacheWriter.RemoveAsync(SelectedCacheContent.Key);
			await Refresh();
		}

		private async Task Add()
		{
			await _cacheWriter.SetAsync(KeyToAdd, ValueToAdd);
			await Refresh();
		}

		public KeyValuePair<RedisKey, RedisValue> SelectedCacheContent
		{
			get => _selectedCacheContent;
			set => SetProperty(ref _selectedCacheContent, value);
		}

		public MvxObservableCollection<KeyValuePair<RedisKey, RedisValue>> CacheContent
		{
			get => _cacheContent;
			set => SetProperty(ref _cacheContent, value);
		}
		public string? KeyToAdd
		{
			get => _keyToAdd;
			set => SetProperty(ref _keyToAdd, value);
		}

		public string? ValueToAdd
		{
			get => _valueToAdd;
			set => SetProperty(ref _valueToAdd, value);
		}
	}
}
