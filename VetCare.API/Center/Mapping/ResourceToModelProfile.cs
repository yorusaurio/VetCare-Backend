using AutoMapper;
using VetCare.API.Center.Domain.Models;
using VetCare.API.Center.Resources;

namespace VetCare.API.Center.Mapping;

public class ResourceToModelProfile : AutoMapper.Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveVetResource, Vet>();
        CreateMap<SaveVeterinaryResource, Veterinary>();
    }
}