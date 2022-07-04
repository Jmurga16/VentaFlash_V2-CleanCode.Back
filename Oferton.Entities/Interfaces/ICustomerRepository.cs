using Oferton.Entities.POCOEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oferton.Entities.Interfaces
{
    public interface ICustomerRepository
    {
        int Create(Customer customer);

    }
}
