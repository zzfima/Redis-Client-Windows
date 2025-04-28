using MvvmCross.Commands;
using MvvmCross.Plugin.Messenger;
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
		private readonly IIDReader _idReader;
		private string? _keyToAdd;
		private long _generatedId;
		private MvxObservableCollection<KeyValuePair<RedisKey, RedisValue>> _cacheContent;
		private KeyValuePair<RedisKey, RedisValue> _selectedCacheContent;
		private string? _valueToAdd;
		private IMvxMessenger? _messenger;
		#endregion

		#region Ctor
		public CacheContentViewModel(IMvxMessenger? messenger, ICacheReader cacheReader, ICacheWriter cacheWriter, IIDReader idReader)
		{
			_messenger = messenger;
			_cacheReader = cacheReader;
			_cacheWriter = cacheWriter;
			_idReader = idReader;
			CacheContent = new MvxObservableCollection<KeyValuePair<RedisKey, RedisValue>>();
			RefreshCommand = new MvxCommand(async () => await Refresh());
			DeleteCommand = new MvxCommand(async () => await Delete());
			AddCommand = new MvxCommand(async () => await Add());
			GetIDCommand = new MvxCommand(async () => await GetID());
		}
		#endregion

		public IMvxCommand RefreshCommand { get; }
		public IMvxCommand DeleteCommand { get; }
		public IMvxCommand AddCommand { get; }
		public IMvxCommand GetIDCommand { get; }

		private async Task Refresh()
		{
			try
			{
				var allKeys = await _cacheReader.GetAllKeysAsync();
				IList<KeyValuePair<RedisKey, RedisValue>> cacheItems = new List<KeyValuePair<RedisKey, RedisValue>>();
				foreach (var item in allKeys)
				{
					var v = await _cacheReader.GetAsync(item);
					cacheItems.Add(new KeyValuePair<RedisKey, RedisValue>(item, v));
				}
				CacheContent = new MvxObservableCollection<KeyValuePair<RedisKey, RedisValue>>(cacheItems);
			}
			catch (System.Exception)
			{
				_messenger?.Publish(new StatusChanged(this, "Can not refresh. Check connection"));
			}
		}

		private async Task GetID()
		{
			try
			{
				GeneratedID = await _idReader.GetNextIdAsync("user id");
			}
			catch (System.Exception)
			{
				_messenger?.Publish(new StatusChanged(this, "Can not get ID. Check connection"));
			}
		}

		private async Task Delete()
		{
			try
			{
				await _cacheWriter.RemoveAsync(SelectedCacheContent.Key);
				await Refresh();
				_messenger?.Publish(new StatusChanged(this, "Deleted key/value"));
			}
			catch (System.Exception)
			{
				_messenger?.Publish(new StatusChanged(this, "Can not Delete. Check connection"));
			}
		}

		private async Task Add()
		{
			try
			{
				await _cacheWriter.SetAsync(KeyToAdd, ValueToAdd);
				await Refresh();
				_messenger?.Publish(new StatusChanged(this, "Added new key/value"));
			}
			catch (System.Exception)
			{
				_messenger?.Publish(new StatusChanged(this, "Can not Add. Check connection"));
			}
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

		public long GeneratedID
        {
            get => _generatedId;
            set => SetProperty(ref _generatedId, value);
        }
	}
}
