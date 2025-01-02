using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseCleaningSchedule.Model
{
	public class CleaningTask
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public float EstimatedCompletionTime { get; set; }
		public bool IsCompleted { get; set; }
		public int Repeatability { get; set; }
	}
}
