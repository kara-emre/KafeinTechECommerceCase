using Invoices.Application.Dtos;
using System.Text;

namespace Invoices.Infrastructure.Helper
{
    public static class InvoiceContent
    {
        public static string Builder(OrderInvoiceDto orderInvoiceDto)
        {
            StringBuilder MailOrderContent = new();
            
            MailOrderContent.AppendLine($"Kafeint Tech Invoice");

            MailOrderContent.AppendLine($"Dear : {orderInvoiceDto.Name} Invoice Detail");

            MailOrderContent.AppendLine($"Order Id : {orderInvoiceDto.OrderId}");

            MailOrderContent.AppendLine($"Address : {orderInvoiceDto.Address}");

            foreach (var item in orderInvoiceDto.Products)
            {
                MailOrderContent.AppendLine($"Product Name : {item.Name} Quantity : {item.Quantity} Price : {item.Price} TRY");
            }

            MailOrderContent.AppendLine($"Total : {orderInvoiceDto.Products.Sum(x => x.Price * x.Quantity)} TRY");

            return MailOrderContent.ToString();
        }
    }
}
