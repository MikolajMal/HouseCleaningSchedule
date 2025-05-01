using HouseCleaningSchedule.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseCleaningSchedule.Data
{
	public class HouseRepository : IHouseRepository
	{
		HouseDbContext houseDbContext;

		public HouseRepository(HouseDbContext context)
		{
			houseDbContext = context;
		}

		public async Task<IEnumerable<Room>> GetAllRoomsAndTasks() => await houseDbContext.Rooms.Include(r => r.CleaningTasks).ToListAsync();

		public async Task SaveChangesAsync()
		{
			await houseDbContext.SaveChangesAsync();
		}

		public async Task AddRoomAsync(Room room)
		{
			await houseDbContext.Rooms.AddAsync(room);
			await houseDbContext.SaveChangesAsync();
		}

		public async Task RemoveRoomAsync(Room room)
		{
			houseDbContext.Rooms.Remove(room);
			await houseDbContext.SaveChangesAsync();
		}

		public async Task AddCleaningTaskAsync(int roomID, CleaningTask cleaningTask)
		{
			Room? room = houseDbContext.Rooms.Find(roomID);
			if (room != null)
			{
				room.CleaningTasks.Add(cleaningTask);
				await houseDbContext.SaveChangesAsync();
			}
		}

		public async Task RemoveCleaningTaskAsync(CleaningTask cleaningTask)
		{
			houseDbContext.Remove(cleaningTask);
			await houseDbContext.SaveChangesAsync();
		}
	}
}
