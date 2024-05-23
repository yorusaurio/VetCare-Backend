using AutoMapper;
using VetCare.API.Identification.Domain.Models;
using VetCare.API.Identification.Domain.Services.Communication;
using VetCare.API.Identification.Resources;

namespace VetCare.API.Identification.Mapping;

public class ModelToResourceProfile : AutoMapper.Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<User, AuthenticateResponse>();
        CreateMap<User, UserResource>();
    }
}