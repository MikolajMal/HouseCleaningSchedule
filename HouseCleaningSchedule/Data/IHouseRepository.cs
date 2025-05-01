using HouseCleaningSchedule.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HouseCleaningSchedule.Data
{
    public interface IHouseRepository
    {
        Task<IEnumerable<Room>> GetAllRoomsAndTasks();
		Task SaveChangesAsync();

        Task AddRoomAsync(Room room);
        Task RemoveRoomAsync(Room room);

		Task AddCleaningTaskAsync(int roomID, CleaningTask cleaningTask);
		Task RemoveCleaningTaskAsync(CleaningTask cleaningTask);
	}
}
