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

        public void Update(Product product)
        {
            Context.Add(product);
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProducts(Specification<Product> specification)
        {
            var ExpressionDelegate = specification.Expression.Compile();

            return Context.Products.Where(ExpressionDelegate);
        }
    }
}
