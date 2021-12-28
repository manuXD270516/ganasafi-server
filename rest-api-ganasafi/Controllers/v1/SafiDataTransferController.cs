using Application.exceptions;
using Application.features.safiDataTransfer.commands;
using Application.features.safiDataTransfer.commands.createSafiDataTransfer;
using Application.features.safiDataTransfer.parameters;
using Application.features.safiDataTransfer.queries;
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
    public class SafiDataTransferController : BaseApiController
    {

        // POST api/SafiDataTransfer
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateSafiDataTransferCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllSafiDataTransferParameters parameters)
        {
            var result = await Mediator.Send(new GetAllSafiDataTransfersQuery
            {
                pageNumber = parameters.pageNumber,
                pageSize = parameters.pageSize,
                accountNumber = parameters.accountNumber,
                orderByDirection = parameters.orderByDirection
            });
            return Ok(result);
        }

        [HttpPut(ROUTE_PARAM_ID)]
        public async Task<IActionResult> Put([FromBody] UpdateSafiDataTransferCommand command, [FromRoute] int id)
        {
            if (command.id != id)
            {
                throw new ApiException("Id's not matching, try again.");
            }
            return Ok(await Mediator.Send(command));
        }


        [HttpDelete(ROUTE_PARAM_ID)]
        public async Task<IActionResult> Delete([FromRoute] DeleteSafiDataTransferCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        
    }
}
