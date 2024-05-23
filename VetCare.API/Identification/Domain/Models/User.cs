using System.Text.Json.Serialization;

namespace VetCare.API.Identification.Domain.Models;

public class User {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    
    [JsonIgnore]
    public string PasswordHash { get; set; }
}