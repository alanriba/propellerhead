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
    public class CustomerDetailsContactService : ICustomerContactDetails<CustomerContactDetailEntity>
    {
        private readonly PropellerheadContext context;

        public CustomerDetailsContactService(PropellerheadContext context)
        {
            this.context = context;
        }

        public async Task<int> CreateAsync(CustomerContactDetailEntity obj)
        {
            context.CustomerDetailsContactEntities.Add(obj);
            await context.SaveChangesAsync();
            return obj.ContactId;
        }

        public async Task<bool> UpdateAsync(CustomerContactDetailEntity obj)
        {
            context.CustomerDetailsContactEntities.Update(obj);
            return await context.SaveChangesAsync() >= 1;
        }

        public async Task<CustomerContactDetailEntity> ReadAsync(int id)
        {
            return await context.CustomerDetailsContactEntities.Where(m => m.ContactId == id).FirstOrDefaultAsync();
        }
    }
}

