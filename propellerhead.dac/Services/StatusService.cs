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
    public class StatusService : IStatus<StatusEntity>
    {
        private readonly PropellerheadContext context;

        public StatusService(PropellerheadContext context)
        {
            this.context = context;
        }

        public StatusEntity ReadAsync(int id)
        {
            return context.StatusEntities.Where(m => m.StatusId == id).FirstOrDefault();
        }

        public IEnumerable<StatusEntity> SearchList()
        {
            return context.StatusEntities.ToList();
        }
    }
}

