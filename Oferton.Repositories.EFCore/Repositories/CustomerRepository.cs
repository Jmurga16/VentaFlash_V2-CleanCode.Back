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

    public class CustomerRepository: ICustomerRepository
    {
        readonly OfertonContext Context;
        public CustomerRepository(OfertonContext context) => Context = context;

        public void Create(Customer customer)
        {
            Context.Add(customer);
        }
    }
}
