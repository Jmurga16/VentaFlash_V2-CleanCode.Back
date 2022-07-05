using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Oferton.Entities.POCOEntities;
using Oferton.Repositories.EFCore.DataContext;


namespace Oferton.UseCases.ListProduct
{
    public class ListProductQuery : IRequest<IEnumerable<Product>>
    {
        public int nIdProducto { get; set; }

    }

    public class ListProductQueryHandler : IRequestHandler<ListProductQuery, IEnumerable<Product>>
    {
        private readonly OfertonContext _context;
        private readonly IMemoryCache _memoryCache;

        public ListProductQueryHandler(OfertonContext context, IMemoryCache memoryCache)
        {
            _context = context;
            _memoryCache = memoryCache;
        }
        public async Task<IEnumerable<Product>> Handle(ListProductQuery request, CancellationToken cancellationToken)
        {
            
            var response = await _context.Products
                             .Where(x => x.nIdProducto == request.nIdProducto)
                             .AsNoTracking()
                             .ToListAsync();                      

            return response.Adapt<IEnumerable<Product>>();
            
        }
    }
}
