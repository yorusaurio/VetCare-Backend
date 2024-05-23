using VetCare.API.Shared.Domain.Services.Communication;
using VetCare.API.Store.Domain.Models;

namespace VetCare.API.Store.Domain.Services.Communication;

public class ProductResponse : BaseResponse<Product>
{
    public ProductResponse(string message) : base(message)
    {
        
    }

    public ProductResponse(Product resource) : base(resource)
    {
        
    }
}