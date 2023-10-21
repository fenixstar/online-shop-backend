namespace online_shop_backend.Models.Entities;

public class InvoiceDetail
{
    public long Id { get; set; }

    public long InvoiceId { get; set; }

    public long ProductId { get; set; }

    public int ItemQuantity { get; set; }

    public decimal ItemPrice { get; set; }

    public Invoice Invoice { get; set; }
    public Product Product { get; set; }
}