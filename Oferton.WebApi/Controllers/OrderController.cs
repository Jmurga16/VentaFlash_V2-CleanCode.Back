using MediatR;
using Microsoft.AspNetCore.Mvc;
using Oferton.UseCases.CreateOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oferton.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        readonly IMediator Mediator;

        public OrderController(IMediator mediator) => Mediator = mediator;
        
        [HttpPost]
        public async Task<ActionResult<int>> CreateOrder(CreateOrderInputPort orderparams)

        {
            return await Mediator.Send(orderparams);
        }
    }
}
