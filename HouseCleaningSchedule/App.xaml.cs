using HouseCleaningSchedule.Data;
using HouseCleaningSchedule.Model;
using HouseCleaningSchedule.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace HouseCleaningSchedule
{
	public partial class App : Application
	{
		readonly ServiceProvider serviceProvider;

		public App()
		{
			ServiceCollection services = new ServiceCollection();
			ConfigureServices(services);

			serviceProvider = services.BuildServiceProvider();
		}

		private void ConfigureServices(ServiceCollection services)
		{
			services.AddDbContext<HouseDbContext>();

			services.AddTransient<MainWindow>();

			services.AddTransient<MainViewModel>();
			services.AddTransient<HouseViewModel>();

			services.AddSingleton<IHouseRepository, HouseRepository>();
		}

		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			var mainWindow = serviceProvider.GetService<MainWindow>();
			mainWindow?.Show();
		}
	}
}
