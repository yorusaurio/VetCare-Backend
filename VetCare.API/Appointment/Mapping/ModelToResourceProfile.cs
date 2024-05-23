using AutoMapper;
using VetCare.API.Appointment.Domain.Models;
using VetCare.API.Appointment.Resources;

namespace VetCare.API.Appointment.Mapping;

public class ModelToResourceProfile : AutoMapper.Profile
{
    public ModelToResourceProfile()
    {   
        
        CreateMap<Pet, PetResource>();
        CreateMap<Prescription, PrescriptionResource>();
        
    }
}