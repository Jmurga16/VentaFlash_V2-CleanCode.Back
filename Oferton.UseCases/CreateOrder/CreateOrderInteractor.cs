using MediatR;
using Oferton.Entities.Exceptions;
using Oferton.Entities.Interfaces;
using Oferton.Entities.POCOEntities;
using Oferton.UseCases.CreateCustomer;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Oferton.UseCases.CreateOrder
{
    public class CreateOrderInteractor : IRequestHandler<CreateOrderInputPort, int>
    {
        readonly IProductRepository ProductRepository;
        readonly IOrderRepository OrderRepository;
        readonly ICustomerRepository CustomerRepository;

        readonly IUnitOfWork UnitOfWork;

        public CreateOrderInteractor(
            IProductRepository productRepository,
            ICustomerRepository customerRepository,
            IOrderRepository orderRepository,
            IUnitOfWork unitOfWork) =>
            (CustomerRepository, ProductRepository, OrderRepository, UnitOfWork) =
            (customerRepository, productRepository, orderRepository, unitOfWork);

        public async Task<int> Handle(CreateOrderInputPort request, CancellationToken cancellationToken)
        {
            var bEstado = true;

            //Guardar Cliente
            Customer Customer = new Customer
            {
                sNombre = request.sNombre,
                sCorreo = request.sCorreo,
                sDireccion = request.sDireccion
            };

            var idCliente = CustomerRepository.Create(Customer);


            //Guardar Orden
            Order Order = new Order
            {
                nIdCliente = idCliente,
                nIdProducto = request.nIdProducto,
                bEstado = bEstado
            };


            OrderRepository.Create(Order);

            //Actualizar Stock de Producto
            var nStock = ProductRepository.Update();


            try
            {

                await UnitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new GeneralException("Error al crear la orden.", ex.Message);
            }

            return nStock;

            //return 1;


        }

    }
}
