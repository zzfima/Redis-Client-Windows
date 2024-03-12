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
        private string? _keyToAdd;
        private MvxObservableCollection<KeyValuePair<RedisKey, RedisValue>> _cacheContent;
        private KeyValuePair<RedisKey, RedisValue> _selectedCacheContent;
        private string? _valueToAdd;
        private IMvxMessenger? _messenger;
        #endregion

        #region Ctor
        public CacheContentViewModel(IMvxMessenger? messenger, ICacheReader cacheReader, ICacheWriter cacheWriter)
        {
            _messenger = messenger;
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
    }
}
