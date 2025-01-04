using HouseCleaningSchedule.Command;
using HouseCleaningSchedule.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseCleaningSchedule.ViewModel
{
	class AddTaskViewModel : ValidationViewModelBase
	{
		public EventHandler<TaskEventArgs> TaskOperationFinished;
		public class TaskEventArgs : EventArgs
		{
			public CleaningTask? CleaningTask { get; }

			public TaskEventArgs(CleaningTask? cleaningTask)
			{
				CleaningTask = cleaningTask;
			}
		}

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

		private int repeatability;
		public int Repeatability
		{
			get => repeatability;
			set
			{
				repeatability = value;
				OnPropertyChanged();
				if (repeatability < 1)
				{
					AddError("Repeatability must by at least 1.");
					Days = "";
				}
				else
				{
					ClearErrors();
					if (repeatability == 1) Days = "day.";
					else Days = "days.";
				}
				CreateTaskCommand?.RaiseCanExecuteChanged();
			}
		}

		private string days = "days.";
		public string Days
		{
			get => days;
			set
			{
				days = value;
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
			cleaningTask.Repeatability = Repeatability;

			TaskOperationFinished?.Invoke(this, new TaskEventArgs(cleaningTask));
		}

		bool CanTaskBeCreated(object? parameter)
		{
			return !HasErrors && !string.IsNullOrEmpty(Name) && Repeatability > 0;
		}

		public DelegateCommand CancelCommand { get; private set; }
		void Cancel(object? parameter)
		{
			TaskOperationFinished?.Invoke(this, new TaskEventArgs(null));
		}
	}
}
