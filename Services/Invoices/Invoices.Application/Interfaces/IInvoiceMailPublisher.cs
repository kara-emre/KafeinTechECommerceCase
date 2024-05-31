using Invoices.Application.Dtos;

namespace Invoices.Application.Interfaces
{
    public interface IInvoiceMailPublisher
    {
        Task PublishInvoiceMail(OrderInvoiceDto orderDto);
    }
}
