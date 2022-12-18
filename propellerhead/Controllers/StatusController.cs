using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using propellerhead.Contract;
using propellerhead.Dtos;
using propellerhead.utils;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace propellerhead.Controllers
{

    [Route("api/status")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusBusiness statusBusiness;

        public StatusController(IStatusBusiness statusBusiness)
        {
            this.statusBusiness = statusBusiness;
        }

        /// <summary>
        /// Operation that returns a list of status data.
        /// </summary>
        /// <param name="criteria">Optional and cumulative search criteria</param>.
        /// <returns>Command information 200 OK, 404 Not Found data not found, 400 BadRequest or 500 internal error</returns>.
        /// <response code="200">Successful response for client command listing</response>.
        /// <response code="400">Errored service request.
        /// <response code="404">Mandate list not found.</response> /// <response code="404">Mandate list not found.
        /// <response code="500">Internal error.</response> /// <response code="500">Internal error.
        [ApiVersion("1.0")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<StatusDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IEnumerable<StatusDto> GetMandatos()
        {
            return statusBusiness.GetStatus();
            
        }

    }
}