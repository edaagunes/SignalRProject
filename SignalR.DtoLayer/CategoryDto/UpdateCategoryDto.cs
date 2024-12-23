using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.CategoryDto
{
	public class UpdateCategoryDto
	{
		public int CategoryId { get; set; }
		public string CategoryName { get; set; }
		public bool CategoryStatus { get; set; }
	}
}
