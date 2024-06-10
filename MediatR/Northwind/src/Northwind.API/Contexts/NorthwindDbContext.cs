using Microsoft.EntityFrameworkCore;
using Northwind.API.Entities;

namespace Northwind.API.Contexts;

public class NorthwindDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public NorthwindDbContext(DbContextOptions<NorthwindDbContext> options) : base(options)
    { }
}
