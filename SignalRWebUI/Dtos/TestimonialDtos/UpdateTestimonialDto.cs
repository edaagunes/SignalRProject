﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRWebUI.Dtos.TestimonialDtos
{
	public class UpdateTestimonialDto
	{
		public int TestimonialId { get; set; }
		public string Name { get; set; }
		public string Comment { get; set; }
		public string ImageUrl { get; set; }
		public string Title { get; set; }
		public bool Status { get; set; }
	}
}
