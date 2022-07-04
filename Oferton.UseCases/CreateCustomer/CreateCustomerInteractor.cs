using MediatR;
using Oferton.Entities.Exceptions;
using Oferton.Entities.Interfaces;
using Oferton.Entities.POCOEntities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Oferton.UseCases.CreateCustomer
{
    public class CreateCustomerInteractor : IRequestHandler<CreateCustomerInput, int>
    {

        readonly ICustomerRepository CustomerRepository;

        readonly IUnitOfWork UnitOfWork;

        public CreateCustomerInteractor(
            ICustomerRepository customerRepository,

            IUnitOfWork unitOfWork) =>
            (CustomerRepository, UnitOfWork) =
            (customerRepository, unitOfWork);

        public async Task<int> Handle(CreateCustomerInput request, CancellationToken cancellationToken)
        {

            Customer Customer = new Customer
            {
                sNombre = request.sNombre,
                sCorreo = request.sCorreo,
                sDireccion = request.sDireccion
            };

            CustomerRepository.Create(Customer);

            try
            {

                await UnitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new GeneralException("Error al crear la orden.", ex.Message);
            }
                       
            return Customer.nIdCliente;

        }
    }
}
