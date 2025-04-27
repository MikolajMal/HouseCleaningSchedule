using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseCleaningSchedule.Model
{
	public class Room
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public List<CleaningTask> CleaningTasks { get; set; } = new List<CleaningTask>();
		public string PercentageDone { get; set; } = string.Empty;
	}
}
