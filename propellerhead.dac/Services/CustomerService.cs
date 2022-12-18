using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using propellerhead.dac.Contracts;
using propellerhead.dac.Filters;
using propellerhead.dac.Models;
using propellerhead.dac.Providers;

namespace propellerhead.dac.Services
{
    public class CustomerService : ICustomer<CustomerEntity>, ISearchableByAnd<SearchCustomerFilter, CustomerEntity>
    {
        private readonly PropellerheadContext context;

        public CustomerService(PropellerheadContext context)
        {
            this.context = context;
        }

        public async Task<int> CreateAsync(CustomerEntity obj)
        {
            context.CustomerEntities.Add(obj);
            await context.SaveChangesAsync();
            return obj.CustomerNumber;
        }

        public async Task<bool> UpdateAsync(CustomerEntity obj)
        {
            context.CustomerEntities.Update(obj);
            return await context.SaveChangesAsync() >= 1;
        }

        public async Task<CustomerEntity> ReadAsync(int id)
        {
            return await context.CustomerEntities.Where(m => m.CustomerNumber == id)
           .Include(m => m.StatusId)
           .Include(m => m.CustomerDetailsContactEntities)
           .FirstOrDefaultAsync();
        }

        public async Task<CustomerEntity> FirstByAnd(SearchCustomerFilter filters)
        {
            return await context.CustomerEntities.Where(m => m.CustomerNumber == filters.CustomerNumber)
           .Include(m => m.StatusId)
           .Include(m => m.CustomerDetailsContactEntities)
           .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<CustomerEntity>> SearchListByAnd(SearchCustomerFilter filters)
        {
            return await context.CustomerEntities.ToListAsync();
        }

        public async Task<IEnumerable<CustomerEntity>> SearchList()
        {
            return await context.CustomerEntities.ToListAsync();
        }

        private IQueryable<CustomerEntity> QueryGenerateList(SearchCustomerFilter filters)
        {
            IQueryable<CustomerEntity> customerQueryTable = context.CustomerEntities
                .Include(m => m.StatusId)
                .Include(m => m.CustomerDetailsContactEntities);

            if (!filters.CustomerNumber.HasValue)
            {
                customerQueryTable = customerQueryTable.Where(m => m.CustomerNumber.ToString().StartsWith(filters.CustomerNumber.ToString())).OrderByDescending(x => x.CustomerNumber);
            }

            if (filters.CustomerFirstName != null)
            {
                customerQueryTable = customerQueryTable.Where(m => m.CustomerFirstName.ToString().StartsWith(filters.CustomerFirstName.ToString()));
            }

            if (filters.CustomerLastName != null)
            {
                customerQueryTable = customerQueryTable.Where(m => m.CustomerLastName.ToString().StartsWith(filters.CustomerLastName.ToString()));
            }

            if (filters.CustomerFirstName != null)
            {
                customerQueryTable = customerQueryTable.Where(m => m.CustomerFirstName.ToString().StartsWith(filters.CustomerFirstName.ToString()));
            }

            if (filters.CustomerStatus != null)
            {
                customerQueryTable = customerQueryTable.Where(m => filters.CustomerStatus.Contains(m.StatusId));
            }

            if (filters.CustomerDateCreation != null)
            {
                customerQueryTable = customerQueryTable.Where(m => m.CustomerDateCreation >= filters.CustomerDateCreation.Value);
            }
            return customerQueryTable.OrderByDescending(m => m.CustomerNumber);
        }
    }
}

