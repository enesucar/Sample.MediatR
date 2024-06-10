using MediatR;
using Microsoft.EntityFrameworkCore;
using Northwind.API.Contexts;
using Northwind.API.Features.Products.Mappers;
using Northwind.API.Features.Products.Models;

namespace Northwind.API.Features.Products.Queries;

public class GetProductsQuery : IRequest<List<ProductResponse>>
{
    public class GetProductsQueryQueryHandler : IRequestHandler<GetProductsQuery, List<ProductResponse>>
    {
        private readonly NorthwindDbContext _context;

        public GetProductsQueryQueryHandler(NorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductResponse>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _context.Products.ToListAsync();
            return ProductMapper.MapToProductResponseFromProduct(products);
        }
    }
}
