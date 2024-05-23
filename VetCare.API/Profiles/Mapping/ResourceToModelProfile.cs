using AutoMapper;
using VetCare.API.Profiles.Domain.Models;
using VetCare.API.Profiles.Resources;

namespace VetCare.API.Profiles.Mapping;

public class ResourceToModelProfile :Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SavePetOwnerResource, PetOwner>();
    }
}