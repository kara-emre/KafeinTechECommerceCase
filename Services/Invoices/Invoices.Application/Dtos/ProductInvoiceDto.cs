namespace Invoices.Application.Dtos
{
    public class ProductInvoiceDto
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
