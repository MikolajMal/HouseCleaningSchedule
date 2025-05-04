using HouseCleaningSchedule.Command;
using HouseCleaningSchedule.Data;
using HouseCleaningSchedule.Model;
using System.Collections.ObjectModel;

namespace HouseCleaningSchedule.ViewModel
{
	public class RoomViewModel : ViewModelBase
	{
		IHouseRepository houseRepository;

		Room room = new();
		public Room Room
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

		public ObservableCollection<CleaningTask> CleaningTasks { get; set; } = new();

		public string PercentageDone
		{
			get => Room.PercentageDone;
			set
			{
				Room.PercentageDone = value + "%";
			}
		}


		public RoomViewModel(Room room, IHouseRepository repository)
		{
			houseRepository = repository;

			Room = room;

			DeleteTaskCommand = new DelegateCommand(DeleteTask, o => SelectedTask != null);
			UpdatePercentageCommand = new DelegateCommand(UpdatePercentage);
		}

		public DelegateCommand DeleteTaskCommand { get; private set; }
		async void DeleteTask(object? parameter)
		{
			if (SelectedTask == null) return;
			await houseRepository.RemoveCleaningTaskAsync(SelectedTask);

			CleaningTasks.Remove(SelectedTask);

			SelectedTask = null;


			UpdatePercentageCommand.Execute(null);
		}

		public DelegateCommand UpdatePercentageCommand { get; private set; }
		void UpdatePercentage(object? parameter)
		{
			float completedTaskCount = 0;
			foreach (CleaningTask cleaningTask in CleaningTasks)
			{
				if(cleaningTask.IsCompleted) completedTaskCount++;
			}

			if (CleaningTasks.Count == 0) PercentageDone = "0";
			else PercentageDone = ((int)(completedTaskCount / CleaningTasks.Count * 100f)).ToString();

			houseRepository.SaveChangesAsync();
		}
	}
}
