using MediatR;
using Microsoft.AspNetCore.Mvc;
using Oferton.Entities.POCOEntities;
using Oferton.UseCases.ListProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oferton.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly IMediator Mediator;

        public ProductController(IMediator mediator) => Mediator = mediator;


        [HttpGet]
        public async Task<IEnumerable<Product>> ListProduct()
        {
            return await Mediator.Send(new ListProductQuery { nIdProducto = 1 });
        }
    }
}
