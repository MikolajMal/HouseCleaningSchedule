using HouseCleaningSchedule.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseCleaningSchedule.Data
{
	public class MockHouseRepository : IHouseRepository
	{
		public async Task<IEnumerable<Room>> GetAllRooms()
		{
			await Task.Delay(100);

			return new List<Room>
			{
				new Room
						{
							Id = 1,
							Name = "Bathroom",
							PercentageDone = "0%",
							CleaningTasks = new List<CleaningTask>
							{
								new CleaningTask
								{
									Id= 1,
									Name = "Do the laundry",
									IsCompleted = false,
									Description = "Sort clothes and and empty laundry container"
								},
								new CleaningTask
								{
									Id= 2,
									Name = "Vacuum",
									IsCompleted = false,
									Description = "Regular vacuuming"
								},
								new CleaningTask
								{
									Id= 3,
									Name = "Wash the mirros",
									IsCompleted = false,
									Description = "Every mirror in bathroom"
								},
								new CleaningTask
								{
									Id= 4,
									Name = "Wash the toilet",
									IsCompleted = false,
									Description = "Inside and outside"
								}
							}
						},
				new Room
						{
							Id = 2,
							Name = "Kitchen",
							PercentageDone = "0%",
							CleaningTasks = new List<CleaningTask>
							{
								new CleaningTask
								{
									Id= 1,
									Name = "Take out the trash",
									IsCompleted = false,
									Description = "Empty every container"
								},
								new CleaningTask
								{
									Id= 2,
									Name = "Vacuum",
									IsCompleted = false,
									Description = "Regular vacuuming"
								},
								new CleaningTask
								{
									Id= 3,
									Name = "Wash the stove",
									IsCompleted = false,
									Description = "With appropriate cleaning agents"
								},
								new CleaningTask
								{
									Id= 4,
									Name = "Wash the floor",
									IsCompleted = false,
									Description = "With a brush and a mop"
								}
							}
						},
				new Room
						{
							Id = 3,
							Name = "Living room",
							PercentageDone = "0%",
							CleaningTasks = new List<CleaningTask>
							{
								new CleaningTask
								{
									Id= 1,
									Name = "Dust off the couch",
									IsCompleted = false,
									Description = "Refresh and dust"
								},
								new CleaningTask
								{
									Id= 2,
									Name = "Vacuum",
									IsCompleted = false,
									Description = "Regular vacuuming"
								},
								new CleaningTask
								{
									Id= 3,
									Name = "Clean the carpets",
									IsCompleted = false,
									Description = "Every mirror in bathroom"
								},
								new CleaningTask
								{
									Id= 4,
									Name = "Dust off",
									IsCompleted = false,
									Description = "Furnitures and electronics"
								}
							}
						}
			};
		}
	}
}
