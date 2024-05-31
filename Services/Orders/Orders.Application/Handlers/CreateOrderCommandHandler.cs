using MediatR;
using Orders.Application.Commands;
using Orders.Application.Dtos;
using Orders.Application.Interfaces;
using Orders.Application.Mappers;
using Orders.Application.Reponses;
using Orders.Core.Entities;

namespace Orders.Application.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreatedOrderResponse>
    {
        private readonly IUnitOfWork _uow;
        private readonly IOrderInvoicePublisher _orderInvoicePublisher;
        private readonly IOrderMailPublisher _orderMailPublisher;

        public CreateOrderCommandHandler(IUnitOfWork uow, IOrderInvoicePublisher orderInvoicePublisher, IOrderMailPublisher orderMailPublisher)
        {
            _uow = uow;
            _orderInvoicePublisher = orderInvoicePublisher;
            _orderMailPublisher = orderMailPublisher;
        }
        
        public async Task<CreatedOrderResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            Order order = OrderMapper.Mapper.Map<Order>(request);

            Order result = await _uow.Orders.CreateOrderAsync(order);

            await _uow.CompleteAsync();

            var orderResponse = OrderMapper.Mapper.Map<CreatedOrderResponse>(result);

            orderResponse.Order.Name = request.Name;
            orderResponse.Order.EMail = request.EMail;

            await _orderInvoicePublisher.PublishOrderInvoice(orderResponse.Order);
            
            await _orderMailPublisher.PublishOrderRecivedMail(orderResponse.Order);
         
            return orderResponse;
        }
    }
}
