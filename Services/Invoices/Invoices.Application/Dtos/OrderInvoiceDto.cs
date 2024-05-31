namespace Invoices.Application.Dtos
{
    public class OrderInvoiceDto
    {
        public int OrderId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        public List<ProductInvoiceDto> Products { get; set; } = new();
    }
}
