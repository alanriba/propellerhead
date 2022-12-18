using System;
using System.Collections.Generic;
using propellerhead.dac;
using propellerhead.dac.Filters;

namespace propellerhead.Dtos
{
    public class FilterSearchCustomers
    {
        public long CustomerNumber { get; set; }
        public string? CustomerFirstName { get; set; }
        public string? CustomerLastName { get; set; }
        public HashSet<int> CustomerStatusId { get; set; }
        public DateTime? CustomerDateCreation { get; set; }

        public SearchCustomerFilter ConvertSearchCustomerFilters()
        {
            SearchCustomerFilter filter = new SearchCustomerFilter();

            filter.CustomerNumber = CustomerNumber;
            filter.CustomerFirstName = CustomerFirstName;
            filter.CustomerLastName = CustomerLastName;
            filter.CustomerStatus = CustomerStatusId;
            filter.CustomerDateCreation = CustomerDateCreation;
            return filter;
        }
    }
}