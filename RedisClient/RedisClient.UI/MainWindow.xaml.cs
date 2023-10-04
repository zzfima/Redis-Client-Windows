using MvvmCross;
using RedisClient.MVVMCross.ViewModel;
using System.Windows;

namespace RedisClient.UI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			DataContext = Mvx.IoCProvider?.Resolve<CompositeViewModel>();
		}
	}
}
