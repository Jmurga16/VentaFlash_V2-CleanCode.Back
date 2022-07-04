using MediatR;
using Oferton.UseCasesDTOs.CreateCustomer;


namespace Oferton.UseCases.CreateCustomer
{
    public class CreateCustomerInput : CreateCustomerParams, IRequest<int>
    {

    }
}
