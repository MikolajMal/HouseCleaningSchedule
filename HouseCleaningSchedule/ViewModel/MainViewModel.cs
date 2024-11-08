using HouseCleaningSchedule.Command;
using HouseCleaningSchedule.Data;
using HouseCleaningSchedule.Model;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

		public HouseViewModel houseViewModel { get; }
		RoomViewModel roomViewModel { get; set; }

		public MainViewModel(IHouseRepository houseRepository, HouseViewModel houseVM)
		{
			HouseRepository = houseRepository;
			houseViewModel = houseVM;
			SelectedViewModel = houseViewModel;
			SelectedViewModel.LoadAsync();

			ShowRoomCommand = new DelegateCommand(ShowRoom);
		}

		public DelegateCommand ShowRoomCommand { get; private set; }
		private void ShowRoom(object? parameter)
		{
			if (parameter is Room selectedRoom)
			{
				roomViewModel = new RoomViewModel(selectedRoom);
				SelectedViewModel = roomViewModel;
			}
		}
	}
}
