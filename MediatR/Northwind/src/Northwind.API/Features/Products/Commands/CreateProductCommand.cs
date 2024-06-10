using MediatR;
using Northwind.API.Contexts;
using Northwind.API.Features.Products.Mappers;
using Northwind.API.Features.Products.Models;

namespace Northwind.API.Features.Products.Commands;

public class CreateProductCommand : IRequest<CreateProductResponse>
{
    public string ProductName { get; set; } = string.Empty;

    public string QuantityPerUnit { get; set; } = string.Empty;

    public decimal UnitPrice { get; set; }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductResponse>
    {
        private readonly NorthwindDbContext _context;

        public CreateProductCommandHandler(NorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<CreateProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = ProductMapper.MapToProductFromCreateProductCommand(request);
            await _context.AddAsync(product, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return ProductMapper.MapToCreateProductResponseFromProduct(product);
        }
    }
}
