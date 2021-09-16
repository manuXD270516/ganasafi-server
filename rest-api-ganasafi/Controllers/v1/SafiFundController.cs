using Application.features.safiDataTransfer.parameters;
using Application.features.safiFund.parameters;
using Application.features.safiFund.queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static rest_api_ganasafi.Helpers.HelpersRequests;

namespace rest_api_ganasafi.Controllers.v1
{
    [ApiVersion(CURRENT_VERSION_API)]
    [ApiController]
    public class SafiFundController : BaseApiController
    {

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllSafiFundFilterParameter parameters)
        {
            return Ok(await Mediator.Send(new GetAllSafiFundQuery
            {
                pageNumber = parameters.pageNumber,
                pageSize = parameters.pageSize,
                personTypeCode = parameters.personTypeCode,
                orderByDirection = parameters.orderByDirection
            }));
        }

        [HttpGet(ROUTE_PARAM_ID)]
        public async Task<IActionResult> GetById([FromRoute] int id, [FromQuery] GetSafiFundBydIdFilterParameter parameters)
        {
            return Ok(await Mediator.Send(new GetSafiFundByIdQuery
            {
                id = id,
                personTypeCode = parameters.personTypeCode
            }));
        }
    }
}
