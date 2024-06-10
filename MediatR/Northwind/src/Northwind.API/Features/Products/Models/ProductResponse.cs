namespace Northwind.API.Features.Products.Models;

public class ProductResponse
{
    public int ProductID { get; set; }

    public string ProductName { get; set; } = string.Empty;

    public string QuantityPerUnit { get; set; } = string.Empty;

    public decimal UnitPrice { get; set; }
}
