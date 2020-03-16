using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatRSample.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MediatRController : ControllerBase
    {
        IMediator _mediator;
        public MediatRController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Route("cal")]
        [HttpGet]
        public async Task<double> Calculator([FromQuery]Calculator calculator)
        {
            return await _mediator.Send(calculator);
        }

        [Route("ping")]
        [HttpGet]
        public async Task<string> Ping()
        {
            await _mediator.Publish(new Ping());
            return "success";
        }
    }

}