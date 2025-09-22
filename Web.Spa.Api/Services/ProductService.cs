using Microsoft.EntityFrameworkCore;
using Web.Spa.Api.Domain;
using Web.Spa.Api.Infrastructure;

namespace Web.Spa.Api.Services;

public class ProductService(AppDbContext db) : IProductService
{
    public Task<List<Product>> ListAsync(CancellationToken ct) =>
        db.Products.OrderBy(p => p.Id).ToListAsync(ct);

    public Task<Product?> GetAsync(int id, CancellationToken ct) =>
        db.Products.FirstOrDefaultAsync(p => p.Id == id, ct);
}
