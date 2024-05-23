using AutoMapper;
using VetCare.API.Store.Domain.Models;
using VetCare.API.Store.Resources;

namespace VetCare.API.Store.Mapping;

public class ResourceToModelProduct : AutoMapper.Profile
{
    public ResourceToModelProduct()
    {
        CreateMap<SaveProductResource, Product>();
    }
}