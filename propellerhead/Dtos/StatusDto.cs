using System;
using System.Collections.Generic;

namespace propellerhead.Dtos
{
	public class StatusDto
	{
		public long StatusId { get; set; }
        public string StatusDescription { get; set; }
        public bool StatusActive { get; set; }
	}
}

