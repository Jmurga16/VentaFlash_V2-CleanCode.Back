﻿using Oferton.Entities.POCOEntities;
using Oferton.Entities.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oferton.Entities.Interfaces
{
    public interface IProductRepository
    {
        int Update();

        IEnumerable<Product> GetProducts(Specification<Product> specification);

    }
}
