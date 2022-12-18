using System;
using propellerhead.utils;
using System.Collections.Generic;
using System.Threading.Tasks;
using propellerhead.Dtos;

namespace propellerhead.Contract
{
    public interface ICustomerBusiness
    {
        IEnumerable<CustomerDto> GetCustomerByFilters(FilterSearchCustomers criteriaFilterSearch);
        bool AddCustomer(CustomerDto customer);
        CustomerDto UpdateCustomer(CustomerDto customer);
        CustomerDto ChangeStatusCustomer(int id);
    }
}

