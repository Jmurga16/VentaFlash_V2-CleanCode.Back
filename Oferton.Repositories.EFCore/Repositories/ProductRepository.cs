using Oferton.Entities.Interfaces;
using Oferton.Entities.POCOEntities;
using Oferton.Entities.Specifications;
using Oferton.Repositories.EFCore.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oferton.Repositories.EFCore.Repositories
{
    public class ProductRepository:IProductRepository
    {
        readonly OfertonContext Context;
        public ProductRepository(OfertonContext context) => Context = context;

        public int Update( )
        {
            var product1 = Context.Products.First(a => a.nIdProducto == 1);
            product1.nStock = product1.nStock - 1;
                                    
            Context.SaveChanges();

            return product1.nStock;

        }

        public IEnumerable<Product> GetProducts(Specification<Product> specification)
        {
            var ExpressionDelegate = specification.Expression.Compile();

            return Context.Products.Where(ExpressionDelegate);
        }
    }
}
