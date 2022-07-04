using MediatR;
using Oferton.UseCasesDTOs.CreateOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oferton.UseCases.CreateOrder
{
    public class CreateOrderInputPort:CreateOrderParams, IRequest<int>
    {

    }
}
