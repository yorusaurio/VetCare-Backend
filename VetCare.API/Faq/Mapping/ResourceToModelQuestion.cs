using AutoMapper;
using VetCare.API.Faq.Domain.Models;
using VetCare.API.Faq.Resources;

namespace VetCare.API.Faq.Mapping;

public class ResourceToModelQuestion :AutoMapper.Profile
{
    public ResourceToModelQuestion()
    {
        CreateMap<SaveQuestionResource, Question>();
    }
}