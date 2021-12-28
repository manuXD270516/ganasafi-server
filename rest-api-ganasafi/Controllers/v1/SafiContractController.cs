using Application.features.safiContract.parameters;
using Application.features.safiContract.queries;
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
    public class SafiContractController : BaseApiController
    {

        [HttpGet]
        public async Task<IActionResult> GetByFilter([FromQuery] GetSafiContractParameters filterParams)
        {
            return Ok(await Mediator.Send(new GetSafiContractByParamsQuery
            {
                idFundPersonType = filterParams.idFundPersonType
            }));
        }
        
        [HttpGet]
        public async Task<IActionResult> GetByFilter2([FromQuery] GetSafiContractParameters filterParams)
        {
            return Ok(await Mediator.Send(new ExampleQuery
            {
                x = 1
            }));
        }
    }
}
