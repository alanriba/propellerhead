using System;
using propellerhead.utils;
using System.Collections.Generic;
using System.Threading.Tasks;
using propellerhead.Dtos;
using propellerhead.utils.BusinessValidation.Models;
using propellerhead.dac.Models;
using propellerhead.dac.Contracts;
using System.Linq;
using propellerhead.Contract;
using propellerhead.dac.Filters;

namespace propellerhead.Business
{
	public class CustomerBusiness : ICustomerBusiness
    {
        private readonly ISearchableByAnd<SearchCustomerFilter, CustomerEntity> searchMandatoFiltros;
        private readonly IStatus<StatusEntity> statusBusiness;
        private readonly ICustomerContactDetails<CustomerContactDetailEntity> searchContactDetails;

        public CustomerBusiness(ISearchableByAnd<SearchCustomerFilter, CustomerEntity> searchMandatoFiltros,
            IStatus<StatusEntity> statusBusiness)
		{
            this.searchMandatoFiltros = searchMandatoFiltros;
            this.statusBusiness = statusBusiness;
		}

        public CustomerDto MapperCustomerEntityToDto(CustomerEntity entity, IEnumerable<CustomerDetailsContactDto> detail, List<StatusDto> status)
        {

            return new CustomerDto()
            {
                CustomerNumber = entity.CustomerNumber,
                CustomerFirstName = entity.CustomerLastName,
                CustomerLastName = entity.CustomerLastName,
                CustomerDateCreation = entity.CustomerDateCreation,
                CustomerStatus = status.Find(s => s.StatusId == entity.StatusId)?.StatusDescription,
                CustomerDetailsContact = GenerateDtoFromEntityDetailContact((IEnumerable<CustomerContactDetailEntity>)detail)
                };
        }

        private IEnumerable<CustomerDetailsContactDto> GenerateDtoFromEntityDetailContact(IEnumerable<CustomerContactDetailEntity> customer)
        {
            return customer.Select(c => GenerarPolizaDtoPolizaDesdeEntidad(c));
        }

        private CustomerDetailsContactDto GenerarPolizaDtoPolizaDesdeEntidad(CustomerContactDetailEntity customerContactDetailEntity)
        {
            return new CustomerDetailsContactDto()
            {
                ContactNumber = customerContactDetailEntity.CustomerNumber,
                ContactEmail = customerContactDetailEntity.ContactEmail,
                ContactDirection = customerContactDetailEntity.ContactDirection,
                ContactPhone = customerContactDetailEntity.ContactPhone,
                ContactStatus = customerContactDetailEntity.ContactStatus
            };
        }

        public bool AddCustomer(CustomerDto customer)
        {
            throw new NotImplementedException();
        }

        public int UpdateCustomer(CustomerDto customer)
        {
            throw new NotImplementedException();
        }

        public CustomerDto ChangeStatusCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerDto> GetCustomerByFilters(FilterSearchCustomers criteriaFilterSearch)
        {
            IBusinessResult<IEnumerable<CustomerDto>> result = new BusinessResult<IEnumerable<CustomerDto>>();
            IEnumerable<CustomerDto> dtos = null;

            IEnumerable<CustomerEntity> customer = (IEnumerable<CustomerEntity>)searchMandatoFiltros.SearchListByAnd(criteriaFilterSearch.ConvertSearchCustomerFilters());

            List<StatusDto> status = (List<StatusDto>)statusBusiness.SearchList();
            IEnumerable<CustomerDetailsContactDto> detailsContactDtos = (IEnumerable<CustomerDetailsContactDto>)searchContactDetails.ReadAsync((int)criteriaFilterSearch.CustomerNumber);

            dtos = customer.Select(e => MapperCustomerEntityToDto(e, detailsContactDtos, status));
            return (IEnumerable<CustomerDto>)result.SetValue(dtos);
        }
    }
}

