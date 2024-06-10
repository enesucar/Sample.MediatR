using Northwind.API.Entities;
using Northwind.API.Features.Products.Commands;
using Northwind.API.Features.Products.Models;

namespace Northwind.API.Features.Products.Mappers;

public static class ProductMapper
{
    public static Product MapToProductFromCreateProductCommand(CreateProductCommand request)
    {
        return new Product()
        {
            ProductName = request.ProductName,
            QuantityPerUnit = request.QuantityPerUnit,
            UnitPrice = request.UnitPrice
        };
    }

    public static CreateProductResponse MapToCreateProductResponseFromProduct(Product product)
    {
        return new CreateProductResponse()
        {
            ProductID = product.ProductID,
            ProductName = product.ProductName,
            QuantityPerUnit = product.QuantityPerUnit,
            UnitPrice = product.UnitPrice
        };
    }

    public static ProductResponse MapToProductResponseFromProduct(Product product)
    {
        return new ProductResponse()
        {
            ProductID = product.ProductID,
            ProductName = product.ProductName,
            QuantityPerUnit = product.QuantityPerUnit,
            UnitPrice = product.UnitPrice
        };
    }

    public static List<ProductResponse> MapToProductResponseFromProduct(List<Product> products)
    {
        return products.Select(MapToProductResponseFromProduct).ToList();
    }
}
