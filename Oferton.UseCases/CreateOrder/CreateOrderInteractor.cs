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
            Customer customer = new Customer
            {
                sNombre = request.sNombre,
                sCorreo = request.sCorreo,
                sDireccion = request.sDireccion
            };

            CustomerRepository.Create(customer);

            //var nStock = ProductRepository.GetProducts()

            #region Insertar Cliente

            //Actualizar Stock
            /*
            Product product = new Product
            {
                nStock = (nStock - 1)
            };
            if (product.nStock<0){
                bEstado = false
            }
            */
            #endregion


            //Guardar Orden
            Order order = new Order
            {
                nIdCliente = customer.nIdCliente,
                nIdProducto = request.nIdProducto,
                bEstado = bEstado
            };

            OrderRepository.Create(order);

            try
            {
                await UnitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new GeneralException("Error al crear la orden.", ex.Message);
            }

            //return product.nStock;

            return 1;


        }

    }
}
