using MvvmCross.Commands;
using MvvmCross.Plugin.Messenger;
using MvvmCross.ViewModels;
using RedisClient.Core;
using System.Threading.Tasks;

namespace RedisClient.MVVMCross.ViewModel
{
    public sealed class ConnectionViewModel : MvxViewModel
    {
        #region Fields
        private string? _ipAddress;
        private int _port;
        private IMvxMessenger? _messenger;
        private IRedisServerConnector? _redisServerConnector;
        #endregion

        #region Ctor
        public ConnectionViewModel(IMvxMessenger messenger, IRedisServerConnector redisServerConnector)
        {
            IpAddress = "172.31.211.138";
            Port = 6379;
            _messenger = messenger;
            _redisServerConnector = redisServerConnector;

            ConnectCommand = new MvxCommand(async () => await Connect());
            DisconnectCommand = new MvxCommand(async () => await Disconnect());
        }
        #endregion

        #region Properties
        public string? IpAddress
        {
            get => _ipAddress;
            set => SetProperty(ref _ipAddress, value);
        }

        public int Port
        {
            get => _port;
            set => SetProperty(ref _port, value);
        }

        public IMvxCommand ConnectCommand { get; }
        public IMvxCommand DisconnectCommand { get; }
        #endregion

        #region Event Handlers
        private async Task Connect()
        {
            try
            {
                await _redisServerConnector.ConnectAsync(IpAddress, Port);
                _messenger?.Publish(new StatusChanged(this, "Connected"));
            }
            catch (System.Exception)
            {
                _messenger?.Publish(new StatusChanged(this, "Can not connect. Please check connection details"));
            }
            _messenger?.Publish(new ConnectControlClicked(this));
        }

        private async Task Disconnect()
        {
            try
            {
                await _redisServerConnector.DisconnectAsync();
                _messenger?.Publish(new StatusChanged(this, "Disconnected"));
            }
            catch (System.Exception)
            {
                _messenger?.Publish(new StatusChanged(this, "Can not Disconnect. Please check connection details"));
            }

            _messenger?.Publish(new ConnectControlClicked(this));
        }
        #endregion
    }
}
