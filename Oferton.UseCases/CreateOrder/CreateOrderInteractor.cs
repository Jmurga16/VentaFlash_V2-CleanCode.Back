using MediatR;
using Microsoft.Extensions.Caching.Memory;
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
        private readonly IMemoryCache MemoryCache;


        readonly IUnitOfWork UnitOfWork;

        public CreateOrderInteractor(
            IProductRepository productRepository,
            ICustomerRepository customerRepository,
            IOrderRepository orderRepository,
            IUnitOfWork unitOfWork, IMemoryCache memoryCache) =>
            (CustomerRepository, ProductRepository, OrderRepository, UnitOfWork, MemoryCache) =
            (customerRepository, productRepository, orderRepository, unitOfWork, memoryCache);

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

            //Actualizar Stock de Producto
            var nStock = ProductRepository.Update();
            if (nStock < 0)
            {
                bEstado = false;
            }

            //Guardar Orden
            Order Order = new Order
            {
                nIdCliente = idCliente,
                nIdProducto = request.nIdProducto,
                bEstado = bEstado
            };

            OrderRepository.Create(Order);

            //Actualizar Caching
            Product productoCache = (Product)MemoryCache.Get("product");
            productoCache.nStock = nStock;

            MemoryCache.Set("product", productoCache);


            try
            {

                await UnitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new GeneralException("Error al crear la orden.", ex.Message);
            }

            return nStock;

        }

    }
}
