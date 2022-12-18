using System;
using System.Collections.Generic;

namespace propellerhead.dac.Filters
{
	public class SearchCustomerFilter
    {
        public long? CustomerNumber { get; set; }
        public string? CustomerFirstName { get; set; }
        public string? CustomerLastName { get; set; }
        public HashSet<int>? CustomerStatus { get; set; }
        public DateTime? CustomerDateCreation { get; set; }
    }
}