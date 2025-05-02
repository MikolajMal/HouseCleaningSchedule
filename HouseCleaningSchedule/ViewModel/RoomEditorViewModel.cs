using HouseCleaningSchedule.Command;
using HouseCleaningSchedule.Data;
using HouseCleaningSchedule.Model;
using System;
using System.Collections.Generic;

namespace HouseCleaningSchedule.ViewModel
{
	class RoomEditorViewModel : ValidationViewModelBase
	{
		IHouseRepository houseRepository;

		public EventHandler? RoomOperationFinished;

		private string viewTitle = string.Empty;
		public string ViewTitle
		{
			get => viewTitle;
			set
			{
				viewTitle = value;
				OnPropertyChanged();
			}
		}

		private string roomName = string.Empty;
		public string RoomName
		{
			get => roomName;
			set
			{
				roomName = value;
				OnPropertyChanged();

				if (string.IsNullOrEmpty(roomName))
					AddError("Room name is required");
				else ClearErrors();

				ConfirmCommand?.RaiseCanExecuteChanged();
			}
		}

		Room? currentRoom = null;

		public RoomEditorViewModel(Room? room, IHouseRepository repository)
		{
			houseRepository = repository;

			if (room != null)
			{
				currentRoom = room;
				ViewTitle = "Edit room";
				RoomName = room.Name;
			}
			else
			{
				ViewTitle = "Create new room";
			}

			ConfirmCommand = new DelegateCommand(Confirm, CanConfirm);
			CancelCommand = new DelegateCommand(Cancel);
		}

		private bool CanConfirm(object? arg)
		{
			return !HasErrors && !string.IsNullOrEmpty(RoomName);
		}

		public DelegateCommand ConfirmCommand { get; private set; }
		async void Confirm(object? parameter)
		{
			Room? room = currentRoom;
			List<Room> rooms = new();
			if (currentRoom != null)
			{
				currentRoom.Name = RoomName;
				await houseRepository.SaveChangesAsync();
			}
			else
			{
				room = new Room()
				{
					Name = RoomName,
					CleaningTasks = new(),
					PercentageDone = "0%"
				};

				await houseRepository.AddRoomAsync(room);
			}

			RoomOperationFinished?.Invoke(this, EventArgs.Empty);

			currentRoom = null;
		}

		public DelegateCommand CancelCommand { get; private set; }
		void Cancel(object? parameter)
		{
			RoomOperationFinished?.Invoke(this, EventArgs.Empty);
		}
	}
}
