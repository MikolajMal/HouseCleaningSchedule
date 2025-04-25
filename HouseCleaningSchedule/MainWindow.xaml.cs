using HouseCleaningSchedule.Data;
using HouseCleaningSchedule.ViewModel;
using System.Windows;

namespace HouseCleaningSchedule
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		MainViewModel MainViewModel { get; }
		public MainWindow(MainViewModel mainViewModel)
		{
			InitializeComponent();

			MainViewModel = mainViewModel;
			Loaded += MainWindow_Loaded;
			DataContext = MainViewModel;
		}

		async void MainWindow_Loaded(object sender, RoutedEventArgs e)
		{
			await MainViewModel.LoadAsync();
		}
	}
}
