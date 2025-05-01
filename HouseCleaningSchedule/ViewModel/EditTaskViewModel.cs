using HouseCleaningSchedule.Command;
using HouseCleaningSchedule.Model;
using System;

namespace HouseCleaningSchedule.ViewModel
{
	public class EditTaskViewModel : ValidationViewModelBase
	{
		CleaningTask? cleaningTask;

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

				EditTaskCommand?.RaiseCanExecuteChanged();
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

		public EditTaskViewModel(object? taskToEdit)
		{
			cleaningTask = taskToEdit as CleaningTask;
			if (cleaningTask == null) return;

			Name = cleaningTask.Name;
			Description = cleaningTask.Description;

			EditTaskCommand = new DelegateCommand(EditTask, o => !HasErrors);
			CancelEditTaskCommand = new DelegateCommand(CancelEditTask);
		}

		public EventHandler? TaskOperationFinished;

		public DelegateCommand EditTaskCommand { get; private set; }
		void EditTask(object? parameter)
		{
			if(cleaningTask== null) return;

			cleaningTask.Name = Name;
			cleaningTask.Description = Description;

			TaskOperationFinished?.Invoke(this, EventArgs.Empty);
		}

		public DelegateCommand CancelEditTaskCommand { get; private set; }
		void CancelEditTask(object? parameter)
		{
			TaskOperationFinished?.Invoke(this, EventArgs.Empty);
		}
	}
}
