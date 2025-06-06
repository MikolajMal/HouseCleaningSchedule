﻿using HouseCleaningSchedule.Command;
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
				RoomViewModel ??= new RoomViewModel(selectedRoom, HouseRepository);
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
			RoomEditorViewModel roomEditorViewModel = new RoomEditorViewModel(room, HouseRepository);
			SelectedViewModel = roomEditorViewModel;

			roomEditorViewModel.RoomOperationFinished += OnRoomEditFinished;
		}

		async void OnRoomEditFinished(object? sender, EventArgs e)
		{
			var rooms = await HouseRepository.GetAllRoomsAndTasks();
			HouseViewModel.Rooms = new(rooms);
			SelectedViewModel = HouseViewModel;
		}

		public DelegateCommand AddNewTaskCommand { get; private set; }
		void AddNewTask(object? parameter)
		{
			AddTaskViewModel addTaskViewModel = new AddTaskViewModel(RoomViewModel.Room.Id, HouseRepository);
			SelectedViewModel = addTaskViewModel;

			addTaskViewModel.TaskOperationFinished += OnTaskEditFinished;
		}

		public DelegateCommand EditTaskCommand { get; private set; }
		void EditTask(object? parameter)
		{
			if (parameter != null && parameter is CleaningTask)
			{
				EditTaskViewModel editTaskViewModel = new EditTaskViewModel((CleaningTask)parameter, HouseRepository);
				SelectedViewModel = editTaskViewModel;

				editTaskViewModel.TaskOperationFinished += OnTaskEditFinished;
			}
		}

		async void OnTaskEditFinished(object? sender, EventArgs e)
		{
			var rooms = await HouseRepository.GetAllTasks(RoomViewModel.Room.Id);
			RoomViewModel.CleaningTasks = new(rooms);
			SelectedViewModel = RoomViewModel;
		}
	}
}
