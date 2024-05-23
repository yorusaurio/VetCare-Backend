using AutoMapper;
using VetCare.API.Center.Domain.Models;
using VetCare.API.Center.Resources;

namespace VetCare.API.Center.Mapping;

public class ModelToResourceProfile : AutoMapper.Profile
{
    public ModelToResourceProfile()
    {   
        
        CreateMap<Vet, VetResource>();
        CreateMap<Veterinary, VeterinaryResource>();
        
    }
}