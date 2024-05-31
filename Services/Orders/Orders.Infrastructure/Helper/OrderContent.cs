using Orders.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Infrastructure.Helper
{
    public static class OrderContent
    {
        public static string Create(OrderDto dto)
        {
            StringBuilder MailOrderContent = new StringBuilder();

            MailOrderContent.AppendLine($"------------------------------------------------------------------------------------");

            MailOrderContent.AppendLine($"KafeinTech Order Detail");

            MailOrderContent.AppendLine($"Dear, {dto.Name} Order Detail");

            MailOrderContent.AppendLine($"Order Number : {dto.OrderId}");

            MailOrderContent.AppendLine($"Address : {dto.Address}");

            foreach (var item in dto.Products)
            {
                MailOrderContent.AppendLine($"Product Name : {item.Name} Quantity : {item.Quantity} Price : {item.Price} TRY");
            }

            MailOrderContent.AppendLine($"Total : {dto.Products.Sum(x => x.Price * x.Quantity)} TRY");
            
            MailOrderContent.AppendLine($"------------------------------------------------------------------------------------");

            return MailOrderContent.ToString();
        }
    }
}
