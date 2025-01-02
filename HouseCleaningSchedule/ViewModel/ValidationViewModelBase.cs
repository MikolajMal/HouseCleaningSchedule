using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace HouseCleaningSchedule.ViewModel
{
	public class ValidationViewModelBase : ViewModelBase, INotifyDataErrorInfo
	{
		Dictionary<string, List<string>> propertyErrors = new();
		public bool HasErrors => propertyErrors.Any();

		public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

		void OnErrorsChanged(DataErrorsChangedEventArgs args)
		{
			ErrorsChanged?.Invoke(this, args);
			Debug.WriteLine("HasErrors:");
			Debug.WriteLine(HasErrors);
		}

		public IEnumerable GetErrors(string? propertyName)
		{
			return propertyName is not null && propertyErrors.ContainsKey(propertyName) ? propertyErrors[propertyName] : Enumerable.Empty<string>();
		}

		protected void AddError(string error, [CallerMemberName] string? propertyName = null)
		{

			if (propertyName == null) return;

			if (!propertyErrors.ContainsKey(propertyName))
			{
				propertyErrors[propertyName] = new List<string>();
			}

			if (!propertyErrors[propertyName].Contains(error))
			{
				propertyErrors[propertyName].Add(error);
			}

			OnErrorsChanged(new DataErrorsChangedEventArgs(propertyName));
			OnPropertyChanged(nameof(HasErrors));
		}

		protected void ClearErrors([CallerMemberName] string? propertyName = null)
		{
			if (propertyName == null) return;

			if(propertyErrors.ContainsKey(propertyName))
			{
				propertyErrors.Remove(propertyName);
			}

			OnErrorsChanged(new DataErrorsChangedEventArgs(propertyName));
			OnPropertyChanged(nameof(HasErrors));
		}
	}
}
