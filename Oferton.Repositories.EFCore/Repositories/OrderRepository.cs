using Oferton.Entities.Interfaces;
using Oferton.Entities.POCOEntities;
using Oferton.Repositories.EFCore.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oferton.Repositories.EFCore.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        readonly OfertonContext Context;
        public OrderRepository(OfertonContext context) => Context = context;


        public void Create(Order order)
        {
            Context.Add(order);
            throw new NotImplementedException();
        }
    }
}
