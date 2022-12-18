using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace propellerhead.dac.Contracts
{
    public interface ISearchableByAnd<TFilters, TEntity>
    {
        Task<IEnumerable<TEntity>> SearchListByAnd(TFilters filters);
        Task<TEntity> FirstByAnd(TFilters filters);
    }
}

