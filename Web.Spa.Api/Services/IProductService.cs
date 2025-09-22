using Web.Spa.Api.Domain;

namespace Web.Spa.Api.Services;

public interface IProductService
{
    Task<List<Product>> ListAsync(CancellationToken ct);
    Task<Product?> GetAsync(int id, CancellationToken ct);
}
