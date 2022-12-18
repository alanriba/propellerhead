using System;
using propellerhead.Dtos;
using propellerhead.utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace propellerhead.Contract
{
	public interface ICustomerContactDetail
	{
        IEnumerable<CustomerDetailsContactDto> GetCustomerContactDetail(int id);
        bool AddCCustomerContactDetail(CustomerDetailsContactDto contact);
        int UpdateCustomerContactDetail(CustomerDetailsContactDto contact);
        CustomerDetailsContactDto ChangeStatusCustomerContactDetail(int id);
    }
}

