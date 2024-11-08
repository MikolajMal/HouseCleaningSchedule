using HouseCleaningSchedule.Data;
using HouseCleaningSchedule.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseCleaningSchedule.ViewModel
{
	public class RoomViewModel : ViewModelBase
	{
		Room? Room { get; }
		public ObservableCollection<CleaningTask> CleaningTasks { get; private set; }

		public RoomViewModel(Room room)
		{
			Room = room;

			CleaningTasks = new ObservableCollection<CleaningTask>(Room.CleaningTasks);
		}

		public override async Task LoadAsync()
		{
			if (CleaningTasks.Count > 0) return;

			//var cleaningTasks = await HouseRepository
			// TODO: pass argument with room id
		}
	}
}
