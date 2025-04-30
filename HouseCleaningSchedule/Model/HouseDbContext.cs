using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.IO;

namespace HouseCleaningSchedule.Model
{
	public class HouseDbContext : DbContext
	{
		StreamWriter writer = new StreamWriter(Path.Combine(AppContext.BaseDirectory, "EFCoreLog.txt"), true);

		public DbSet<Room> Rooms { get; set; }
		public DbSet<CleaningTask> CleaningTasks { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var databasePath = Path.Combine(AppContext.BaseDirectory, "HouseCleaningScheduleDatabase.db");
			optionsBuilder
				.UseSqlite($"Data Source={databasePath}")
				.LogTo(writer.WriteLine, LogLevel.Error)
				.LogTo(log => Debug.WriteLine(log), new[] {DbLoggerCategory.Database.Command.Name}, LogLevel.Information);
		}

		public override void Dispose()
		{
			writer.Dispose();
			base.Dispose();
		}
	}
}
