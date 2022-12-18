using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using propellerhead.Dtos;
using propellerhead.utils;

namespace propellerhead.Contract
{
	public interface IStatusBusiness
	{
       IEnumerable<StatusDto> GetStatus();
    }
}

