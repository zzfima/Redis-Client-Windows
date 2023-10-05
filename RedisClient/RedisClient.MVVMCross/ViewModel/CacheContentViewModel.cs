using MvvmCross.Plugin.Messenger;
using MvvmCross.ViewModels;
using RedisClient.Core;
using System.Collections.Generic;

namespace RedisClient.MVVMCross.ViewModel
{
	public sealed class CacheContentViewModel : MvxViewModel
	{
		#region Fields
		private IMvxMessenger? _messenger;
		private IRedisServerConnector? _redisServerConnector;
		private MvxObservableCollection<KeyValuePair<string, string>> _cacheContent;
		#endregion

		#region Ctor
		public CacheContentViewModel(IMvxMessenger messenger, IRedisServerConnector redisServerConnector)
		{
			_messenger = messenger;
			_redisServerConnector = redisServerConnector;

			IList<KeyValuePair<string, string>> dsds = new List<KeyValuePair<string, string>>();
			dsds.Add(new KeyValuePair<string, string>("1", "1"));
			dsds.Add(new KeyValuePair<string, string>("11", "11"));

			CacheContent = new MvxObservableCollection<KeyValuePair<string, string>>(dsds);

		}
		#endregion

		public MvxObservableCollection<KeyValuePair<string, string>> CacheContent { get; private set; }
	}
}
