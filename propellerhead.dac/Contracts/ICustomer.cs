using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace propellerhead.dac.Contracts
{
	public interface ICustomer<CustomerEntity>
	{
        Task<int> CreateAsync(CustomerEntity obj);
        Task<bool> UpdateAsync(CustomerEntity obj);
        Task<CustomerEntity> ReadAsync(int id);
    }
}

