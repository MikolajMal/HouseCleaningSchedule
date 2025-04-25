using HouseCleaningSchedule.Data;
using HouseCleaningSchedule.ViewModel;
using System.Windows;

namespace HouseCleaningSchedule
{
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			IHouseRepository houseRepository = new MockHouseRepository();

			var mainWindow = new MainWindow(new MainViewModel(houseRepository, new HouseViewModel(houseRepository)));
			mainWindow.Show();
		}
	}
}
