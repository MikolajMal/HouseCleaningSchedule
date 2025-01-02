using HouseCleaningSchedule.Command;
using HouseCleaningSchedule.Model;
using HouseCleaningSchedule.View;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;

namespace HouseCleaningSchedule.ViewModel
{
	public class RoomViewModel : ViewModelBase
	{
		Room? room;
		public Room? Room
		{
			get => room;
			set
			{
				if(room != value && value != null)
				{
					room = value;
					CleaningTasks = new ObservableCollection<CleaningTask>(room.CleaningTasks);
				}
			}
		}

		CleaningTask? selectedTask = null;
		public CleaningTask? SelectedTask
		{
			get => selectedTask;
			set
			{
				if(selectedTask != value)
				{
					selectedTask = value;
					OnPropertyChanged();
					DeleteTaskCommand.RaiseCanExecuteChanged();
				}
			}
		}

		public ObservableCollection<CleaningTask> CleaningTasks { get; private set; } = new();

		public RoomViewModel(Room room)
		{
			Room = room;

			DeleteTaskCommand = new DelegateCommand(DeleteTask, o => SelectedTask != null);
		}

		public DelegateCommand DeleteTaskCommand { get; private set; }
		void DeleteTask(object? parameter)
		{
			if (SelectedTask == null) return;
			CleaningTasks.Remove(SelectedTask);
			SelectedTask = null;
		}

		//public override async Task LoadAsync()
		//{
		//	if (CleaningTasks.Count > 0) return;
		//}
	}
}
