using AutoMapper;
using VetCare.API.Faq.Domain.Models;
using VetCare.API.Faq.Resources;

namespace VetCare.API.Faq.Mapping;
    
public class ModelToResourceQuestion :AutoMapper.Profile
{
    public ModelToResourceQuestion()
    {
        CreateMap<Question, QuestionResource>();
    }
}