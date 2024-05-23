using AutoMapper;
using VetCare.API.Store.Domain.Models;
using VetCare.API.Store.Resources;

namespace VetCare.API.Store.Mapping;

public class ModelToResourceProduct : AutoMapper.Profile
{
    public ModelToResourceProduct()
    {
        CreateMap<Product, ProductResource>();
    }
}