using HouseCleaningSchedule.Command;
using HouseCleaningSchedule.Data;
using HouseCleaningSchedule.Model;
using System;
using System.Collections.Generic;
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

			DeleteRoomCommand = new DelegateCommand(DeleteRoom);
		}

		public DelegateCommand DeleteRoomCommand { get; private set; }
		async void DeleteRoom(object? parameter)
		{
			Room? room = parameter as Room;

			if (room != null)
			{
				try
				{
					await HouseRepository.RemoveRoomAsync(room);
					Rooms.Remove(room);
				}
				catch (Exception ex)
				{
					Console.WriteLine($"Error while removing room: {ex.Message}");
				}
			}
		}

		public override async Task LoadAsync()
		{
			if (Rooms.Count > 0) return;

			try
			{
				IEnumerable<Room> rooms = await HouseRepository.GetAllRoomsAndTasks();

				if (rooms == null) return;

				Rooms = new ObservableCollection<Room>(rooms);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error while retrieving rooms: {ex.Message}");
			}
		}
	}
}
