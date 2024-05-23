using AutoMapper;
using VetCare.API.Profiles.Resources;
using VetCare.API.Profiles.Domain.Models;

namespace VetCare.API.Profiles.Mapping;

public class ModelToResourceProfile : AutoMapper.Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<PetOwner, PetOwnerResource>();
    }
}