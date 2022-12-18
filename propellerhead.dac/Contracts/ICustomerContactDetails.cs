using System;
using propellerhead.dac.Models;
using System.Threading.Tasks;

namespace propellerhead.dac.Contracts
{
	public interface ICustomerContactDetails<CustomerContactDetailEntity>
    {
        Task<int> CreateAsync(CustomerContactDetailEntity obj);
        Task<bool> UpdateAsync(CustomerContactDetailEntity obj);
        Task<CustomerContactDetailEntity> ReadAsync(int id);
    }
}

