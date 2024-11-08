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
		public string? Name { get; set; }
		public string? Description { get; set; }
		public float EstimatedCompletionTime { get; set; }
		public bool IsCompleted { get; set; }
		public string? Repeatability { get; set; }
	}
}
