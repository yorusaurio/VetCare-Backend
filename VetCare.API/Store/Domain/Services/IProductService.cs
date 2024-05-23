using VetCare.API.Store.Domain.Models;
using VetCare.API.Store.Domain.Services.Communication;

namespace VetCare.API.Store.Domain.Services;

public interface IProductService
{
    Task<IEnumerable<Product>> ListAsync();
    Task<ProductResponse> SaveAsync(Product product);
    Task<ProductResponse> UpdateAsync(int productId, Product product);
    Task<ProductResponse> DeleteAsync(int productId);
}