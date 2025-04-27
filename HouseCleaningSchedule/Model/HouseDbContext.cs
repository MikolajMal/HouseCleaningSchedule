using Microsoft.EntityFrameworkCore;

namespace HouseCleaningSchedule.Model
{
	public class HouseDbContext : DbContext
	{
		public DbSet<Room> Rooms { get; set; }
		public DbSet<CleaningTask> CleaningTasks { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite("Data Source=HouseCleaningScheduleDatabase.db");
		}
	}
}
