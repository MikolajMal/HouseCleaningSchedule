using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HouseCleaningSchedule.Command
{
	public class DelegateCommand : ICommand
	{
		Action<object?> execute;
		Func<object?, bool>? canExecute;

		public DelegateCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
		{
			this.execute = execute;
			this.canExecute = canExecute;
		}

		public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

		public event EventHandler? CanExecuteChanged;

		public bool CanExecute(object? parameter) => canExecute is null || canExecute(parameter);

		public void Execute(object? parameter) => execute(parameter);
	}
}
