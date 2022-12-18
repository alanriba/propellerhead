using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace propellerhead.dac.Contracts
{
	public interface IStatus<StatusEntity>
	{
        StatusEntity ReadAsync(int id);
        IEnumerable<StatusEntity> SearchList();
    }
}

