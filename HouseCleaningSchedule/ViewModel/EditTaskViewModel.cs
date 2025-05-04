using HouseCleaningSchedule.Command;
using HouseCleaningSchedule.Data;
using HouseCleaningSchedule.Model;
using System;

namespace HouseCleaningSchedule.ViewModel
{
	public class EditTaskViewModel : ValidationViewModelBase
	{
		IHouseRepository houseRepository;

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

		public EditTaskViewModel(CleaningTask taskToEdit, IHouseRepository repository)
		{
			houseRepository = repository;

			cleaningTask = taskToEdit;
			if (cleaningTask == null) return;

			Name = cleaningTask.Name;
			Description = cleaningTask.Description;

			EditTaskCommand = new DelegateCommand(EditTask, o => !HasErrors);
			CancelEditTaskCommand = new DelegateCommand(CancelEditTask);
		}

		public EventHandler? TaskOperationFinished;

		public DelegateCommand EditTaskCommand { get; private set; }
		async void EditTask(object? parameter)
		{
			if(cleaningTask== null) return;

			cleaningTask.Name = Name;
			cleaningTask.Description = Description;

			await houseRepository.SaveChangesAsync();

			TaskOperationFinished?.Invoke(this, EventArgs.Empty);
		}

		public DelegateCommand CancelEditTaskCommand { get; private set; }
		void CancelEditTask(object? parameter)
		{
			TaskOperationFinished?.Invoke(this, EventArgs.Empty);
		}
	}
}
