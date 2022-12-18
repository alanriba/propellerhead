using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using propellerhead.Contract;
using propellerhead.Dtos;
using propellerhead.utils;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace propellerhead.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
       private readonly ICustomerBusiness customerBusiness;

        public CustomerController(ICustomerBusiness customerBusiness)
        {
            this.customerBusiness = customerBusiness;
        }

        /// <summary>
        /// Operation that returns a list of customer data according to search criteria.
        /// </summary>
        /// <param name="criteria">Optional and cumulative search criteria</param>.
        /// <returns>Command information 200 OK, 404 Not Found data not found, 400 BadRequest or 500 internal error</returns>.
        /// <response code="200">Successful response for client command listing</response>.
        /// <response code="400">Errored service request.
        /// <response code="404">Mandate list not found.</response> /// <response code="404">Mandate list not found.
        /// <response code="500">Internal error.</response> /// <response code="500">Internal error.
        [ApiVersion("1.0")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CustomerDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)] 
        public IEnumerable<CustomerDto> GetMandatos([FromQuery, SwaggerParameter("Filtros", Required = true)] FilterSearchCustomers criteria)
        {
            return customerBusiness.GetCustomerByFilters(criteria);
        }

        /// <summary>
        /// Operation that returns a list of customer data according to search criteria.
        /// </summary>
        /// <param name="criteria">Optional and cumulative search criteria</param>.
        /// <returns>Command information 200 OK, 404 Not Found data not found, 400 BadRequest or 500 internal error</returns>.
        /// <response code="200">Successful response for client command listing</response>.
        /// <response code="400">Errored service request.
        /// <response code="404">Mandate list not found.</response> /// <response code="404">Mandate list not found.
        /// <response code="500">Internal error.</response> /// <response code="500">Internal error.
        [ApiVersion("1.0")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CustomerDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IEnumerable<CustomerDto> GetAllCustomer()
        {
            return customerBusiness.GetCustomer();
        }

        /// <summary>
        /// Operation that returns a list of customer data according to search criteria.
        /// </summary>
        /// <param name="criteria">Optional and cumulative search criteria</param>.
        /// <returns>Command information 200 OK, 404 Not Found data not found, 400 BadRequest or 500 internal error</returns>.
        /// <response code="200">Successful response for client command listing</response>.
        /// <response code="400">Errored service request.
        /// <response code="404">Mandate list not found.</response> /// <response code="404">Mandate list not found.
        /// <response code="500">Internal error.</response> /// <response code="500">Internal error.
        [ApiVersion("1.0")]
        [HttpPut]
        [ProducesResponseType(typeof(CustomerDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public CustomerDto UpdateCustomer(CustomerDto criteria)
        {
            return customerBusiness.UpdateCustomer(criteria);
        }


        /// <summary>
        /// Operation that returns a id customer added
        /// </summary>
        /// <param name="criteria">Customer added</param>.
        /// <returns>Command information 200 OK, 404 Not Found data not found, 400 BadRequest or 500 internal error</returns>.
        /// <response code="200">Successful response for client command listing</response>.
        /// <response code="400">Errored service request.
        /// <response code="404">Mandate list not found.</response> /// <response code="404">Mandate list not found.
        /// <response code="500">Internal error.</response> /// <response code="500">Internal error.
        [ApiVersion("1.0")]
        [HttpPost]
        [ProducesResponseType(typeof(CustomerDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public bool AddCustomer(CustomerDto criteria)
        {
            return customerBusiness.AddCustomer(criteria);
        }

        /// <summary>
        /// Operation that returns a id customer added
        /// </summary>
        /// <param name="criteria">Customer added</param>.
        /// <returns>Command information 200 OK, 404 Not Found data not found, 400 BadRequest or 500 internal error</returns>.
        /// <response code="200">Successful response for client command listing</response>.
        /// <response code="400">Errored service request.
        /// <response code="404">Mandate list not found.</response> /// <response code="404">Mandate list not found.
        /// <response code="500">Internal error.</response> /// <response code="500">Internal error.
        [ApiVersion("1.0")]
        [HttpPost]
        [ProducesResponseType(typeof(CustomerDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public CustomerDto ChangeStatusCustomer(int criteria)
        {
            return customerBusiness.ChangeStatusCustomer(criteria);
        }

    }
}

