using VetCare.API.Identification.Domain.Models;

namespace VetCare.API.Identification.Authorization.Handlers.Interfaces;

public interface IJwtHandler
{
    public string GenerateToken(User user);
    public int? ValidateToken(string token);
}