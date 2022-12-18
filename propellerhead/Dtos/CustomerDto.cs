using System;
using System.Collections.Generic;

namespace propellerhead.Dtos
{
    public class CustomerDto
    {
        public long CustomerNumber { get; set; }
        public string CustomerFirstName { get; set; }
        public string? CustomerLastName { get; set; }
        public string CustomerStatus { get; set; }
        public DateTime CustomerDateCreation { get; set; }
        public IEnumerable<CustomerDetailsContactDto> CustomerDetailsContact { get; set; }
    }
}

