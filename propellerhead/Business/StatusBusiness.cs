using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using propellerhead.Contract;
using propellerhead.dac.Contracts;
using propellerhead.dac.Filters;
using propellerhead.dac.Models;
using propellerhead.Dtos;
using propellerhead.utils;
using propellerhead.utils.BusinessValidation.Models;

namespace propellerhead.Business
{
	public class StatusBusiness : IStatusBusiness
    {
        private readonly IStatus<StatusEntity> status;
        public StatusBusiness(IStatus<StatusEntity> status)
		{
            this.status = status;
        }

        public IEnumerable<StatusDto> GetStatus()
        {
            IBusinessResult<IEnumerable<StatusDto>> result = new BusinessResult<IEnumerable<StatusDto>>();
            IEnumerable<StatusDto> dtos = null;

            IEnumerable<StatusEntity> status = this.status.SearchList();

            dtos = status.Select(e => MapperCustomerEntityToDto(e));
            return (IEnumerable<StatusDto>)result.SetValue(dtos);
        }

        private StatusDto MapperCustomerEntityToDto(StatusEntity entity)
        {
            return new StatusDto()
            {
                StatusDescription = entity.StatusName
            };
        }
    }
}

