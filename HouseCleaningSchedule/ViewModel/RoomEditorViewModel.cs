using HouseCleaningSchedule.Command;
using HouseCleaningSchedule.Model;
using System;
using static HouseCleaningSchedule.ViewModel.AddTaskViewModel;

namespace HouseCleaningSchedule.ViewModel
{
	class RoomEditorViewModel : ValidationViewModelBase
	{
		public EventHandler<Room?>? RoomOperationFinished;

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

		public RoomEditorViewModel(Room? room)
		{
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
		void Confirm(object? parameter)
		{
			if (currentRoom != null)
			{
				currentRoom.Name = RoomName;
				RoomOperationFinished?.Invoke(this, null);
			}
			else
			{
				Room room = new Room()
				{
					Name = RoomName,
					CleaningTasks = new(),
					PercentageDone = "0%"
				};
				RoomOperationFinished?.Invoke(this, room);
			}

			currentRoom = null;
		}

		public DelegateCommand CancelCommand { get; private set; }
		void Cancel(object? parameter)
		{
			RoomOperationFinished?.Invoke(this, null);
		}
	}
}
