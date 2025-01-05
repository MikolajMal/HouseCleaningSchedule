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
							EstimatedCompletionTime = 0f,
							PercentageDone = "0%",
							CleaningTasks = new List<CleaningTask>
							{
								new CleaningTask
								{
									Id= 1,
									Name = "Do the laundry",
									EstimatedCompletionTime = 0.5f,
									IsCompleted = false,
									Description = "Sort clothes and and empty laundry container",
									Repeatability = 4
								},
								new CleaningTask
								{
									Id= 2,
									Name = "Vacuum",
									EstimatedCompletionTime = 0.8f,
									IsCompleted = false,
									Description = "Regular vacuuming",
									Repeatability = 5
								},
								new CleaningTask
								{
									Id= 3,
									Name = "Wash the mirros",
									EstimatedCompletionTime = 0.4f,
									IsCompleted = false,
									Description = "Every mirror in bathroom",
									Repeatability = 7
								},
								new CleaningTask
								{
									Id= 4,
									Name = "Wash the toilet",
									EstimatedCompletionTime = 0.5f,
									IsCompleted = false,
									Description = "Inside and outside",
									Repeatability = 7
								}
							}
						},
				new Room
						{
							Id = 2,
							Name = "Kitchen",
							EstimatedCompletionTime = 0f,
							PercentageDone = "0%",
							CleaningTasks = new List<CleaningTask>
							{
								new CleaningTask
								{
									Id= 1,
									Name = "Take out the trash",
									EstimatedCompletionTime = 0.2f,
									IsCompleted = false,
									Description = "Empty every container",
									Repeatability = 4
								},
								new CleaningTask
								{
									Id= 2,
									Name = "Vacuum",
									EstimatedCompletionTime = 0.8f,
									IsCompleted = false,
									Description = "Regular vacuuming",
									Repeatability = 5
								},
								new CleaningTask
								{
									Id= 3,
									Name = "Wash the stove",
									EstimatedCompletionTime = 0.4f,
									IsCompleted = false,
									Description = "With appropriate cleaning agents",
									Repeatability = 7
								},
								new CleaningTask
								{
									Id= 4,
									Name = "Wash the floor",
									EstimatedCompletionTime = 0.6f,
									IsCompleted = false,
									Description = "With a brush and a mop",
									Repeatability = 7
								}
							}
						},
				new Room
						{
							Id = 3,
							Name = "Living room",
							EstimatedCompletionTime = 0f,
							PercentageDone = "0%",
							CleaningTasks = new List<CleaningTask>
							{
								new CleaningTask
								{
									Id= 1,
									Name = "Dust off the couch",
									EstimatedCompletionTime = 0.6f,
									IsCompleted = false,
									Description = "Refresh and dust",
									Repeatability = 7
								},
								new CleaningTask
								{
									Id= 2,
									Name = "Vacuum",
									EstimatedCompletionTime = 0.8f,
									IsCompleted = false,
									Description = "Regular vacuuming",
									Repeatability = 5
								},
								new CleaningTask
								{
									Id= 3,
									Name = "Clean the carpets",
									EstimatedCompletionTime = 0.4f,
									IsCompleted = false,
									Description = "Every mirror in bathroom",
									Repeatability = 7
								},
								new CleaningTask
								{
									Id= 4,
									Name = "Dust off",
									EstimatedCompletionTime = 1f,
									IsCompleted = false,
									Description = "Furnitures and electronics",
									Repeatability = 7
								}
							}
						}
			};
		}
	}
}
