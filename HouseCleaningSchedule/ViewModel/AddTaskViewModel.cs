using HouseCleaningSchedule.Command;
using HouseCleaningSchedule.Model;
using System;

namespace HouseCleaningSchedule.ViewModel
{
	class AddTaskViewModel : ValidationViewModelBase
	{
		public EventHandler<CleaningTask?>? TaskOperationFinished;

		#region Properties
		private string name = "";
		public string Name
		{
			get => name;
			set
			{
				name = value;
				OnPropertyChanged();
				if (string.IsNullOrEmpty(name))
					AddError("Name is required");
				else ClearErrors();

				CreateTaskCommand?.RaiseCanExecuteChanged();
			}
		}

		private string description = "";
		public string Description
		{
			get => description;
			set
			{
				description = value;
				OnPropertyChanged();
			}
		}
		#endregion

		public AddTaskViewModel()
		{
			CreateTaskCommand = new DelegateCommand(CreateTask, CanTaskBeCreated);
			CancelCommand = new DelegateCommand(Cancel);
		}

		public DelegateCommand CreateTaskCommand { get; private set; }
		void CreateTask(object? parameter)
		{
			CleaningTask cleaningTask = new CleaningTask();
			cleaningTask.Name = Name;
			cleaningTask.Description = Description;

			TaskOperationFinished?.Invoke(this, cleaningTask);
		}

		bool CanTaskBeCreated(object? parameter)
		{
			return !HasErrors && !string.IsNullOrEmpty(Name);
		}

		public DelegateCommand CancelCommand { get; private set; }
		void Cancel(object? parameter)
		{
			TaskOperationFinished?.Invoke(this, null);
		}
	}
}
