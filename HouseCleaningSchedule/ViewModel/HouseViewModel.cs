using HouseCleaningSchedule.Command;
using HouseCleaningSchedule.Data;
using HouseCleaningSchedule.Model;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace HouseCleaningSchedule.ViewModel
{
	public class HouseViewModel : ViewModelBase
	{
		IHouseRepository HouseRepository { get; }
		public ObservableCollection<Room> Rooms { get; set; } = new();

		public HouseViewModel(IHouseRepository houseRepository)
		{
			HouseRepository = houseRepository;
		}

		public override async Task LoadAsync()
		{
			if (Rooms.Count > 0) return;

			var rooms = await HouseRepository.GetAllRooms();

			if (rooms == null) return;

			foreach (Room room in rooms)
			{
				Rooms.Add(room);
			}
		}
	}
}
