using HouseCleaningSchedule.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HouseCleaningSchedule.Data
{
    public interface IHouseRepository
    {
        Task<IEnumerable<Room>> GetAllRooms();
    }
}
