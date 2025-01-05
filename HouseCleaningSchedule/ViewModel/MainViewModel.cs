using HouseCleaningSchedule.Command;
using HouseCleaningSchedule.Data;
using HouseCleaningSchedule.Model;
using System;

namespace HouseCleaningSchedule.ViewModel
{
	public class MainViewModel : ViewModelBase
	{
		IHouseRepository HouseRepository { get; }

		ViewModelBase? selectedViewModel;
		public ViewModelBase? SelectedViewModel
		{
			get => selectedViewModel;
			set
			{
				selectedViewModel = value;
				OnPropertyChanged();
			}
		}

		HouseViewModel HouseViewModel { get; }
		RoomViewModel RoomViewModel { get; set; }

		public MainViewModel(IHouseRepository houseRepository, HouseViewModel houseVM)
		{
			HouseRepository = houseRepository;
			HouseViewModel = houseVM;
			SelectedViewModel = HouseViewModel;
			SelectedViewModel.LoadAsync();

			ShowRoomCommand = new DelegateCommand(ShowRoom);
			ShowHomeCommand = new DelegateCommand(ShowHome);

			OpenRoomEditorCommand = new DelegateCommand(OpenRoomEditor);

			AddNewTaskCommand = new DelegateCommand(AddNewTask);
			EditTaskCommand = new DelegateCommand(EditTask);
		}

		public DelegateCommand ShowRoomCommand { get; private set; }
		private void ShowRoom(object? parameter)
		{
			if (parameter is Room selectedRoom)
			{
				RoomViewModel ??= new RoomViewModel(selectedRoom);
				RoomViewModel.Room = selectedRoom;
				SelectedViewModel = RoomViewModel;
			}
		}

		public DelegateCommand ShowHomeCommand { get; private set; }
		private void ShowHome(object? parameter)
		{
			SelectedViewModel = HouseViewModel;
		}

		public DelegateCommand OpenRoomEditorCommand { get; private set; }
		void OpenRoomEditor(object? parameter)
		{
			Room? room = parameter as Room;
			RoomEditorViewModel roomEditorViewModel = new RoomEditorViewModel(room);
			SelectedViewModel = roomEditorViewModel;

			roomEditorViewModel.RoomOperationFinished += OnRoomEditFinished;
		}

		void OnRoomEditFinished(object? sender, Room? room)
		{
			if (room != null) HouseViewModel.Rooms.Add(room);

			SelectedViewModel = HouseViewModel;
		}

		public DelegateCommand AddNewTaskCommand { get; private set; }
		void AddNewTask(object? parameter)
		{
			AddTaskViewModel addTaskViewModel = new AddTaskViewModel();
			SelectedViewModel = addTaskViewModel;

			addTaskViewModel.TaskOperationFinished += OnTaskCreateFinished;
		}

		private void OnTaskCreateFinished(object? sender, AddTaskViewModel.TaskEventArgs e)
		{
			if (e.CleaningTask != null)
			{
				RoomViewModel.CleaningTasks.Add(e.CleaningTask);
				RoomViewModel.UpdatePercentageCommand.Execute(null);
			}

			SelectedViewModel = RoomViewModel;
		}

		public DelegateCommand EditTaskCommand { get; private set; }
		void EditTask(object? parameter)
		{
			if (parameter != null)
			{
				EditTaskViewModel editTaskViewModel = new EditTaskViewModel(parameter);
				SelectedViewModel = editTaskViewModel;

				editTaskViewModel.TaskOperationFinished += OnTaskEditFinished;
			}
		}

		void OnTaskEditFinished(object? sender, EventArgs e)
		{
			SelectedViewModel = RoomViewModel;
		}
	}
}
