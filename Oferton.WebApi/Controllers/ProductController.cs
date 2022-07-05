using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
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
        private readonly IMemoryCache _memoryCache;

        public ProductController(IMediator mediator,IMemoryCache memoryCache)
        {
            Mediator = mediator;
            _memoryCache = memoryCache;

        }

        [HttpGet]
        public async Task<IEnumerable<Product>> ListProduct()
        {

            return await _memoryCache.GetOrCreateAsync("product", cacheEntry =>
            {
                return Mediator.Send(new ListProductQuery { nIdProducto = 1 });
            });

            //return await Mediator.Send(new ListProductQuery { nIdProducto = 1 });
        }
    }
}
