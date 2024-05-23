using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VetCare.API.Appointment.Domain.Models;
using VetCare.API.Appointment.Domain.Services;
using VetCare.API.Appointment.Resources;
using VetCare.API.Identification.Authorization.Attributes;


namespace VetCare.API.Appointment.Controllers;


[Authorize]
[ApiController]
[Route("/api/v1/pets/{petId}/prescriptions")]
public class PetPrescriptionsController : ControllerBase
{
    private readonly IPrescriptionService _prescriptionService;
    private readonly IMapper _mapper;

    public PetPrescriptionsController(IPrescriptionService prescriptionService, IMapper mapper)
    {
        _prescriptionService = prescriptionService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<PrescriptionResource>> GetAllByPetIdAsync(int petId)
    {
        var prescriptions = await _prescriptionService.ListByPetIdAsync(petId);

        var resources = _mapper.Map<IEnumerable<Prescription>, IEnumerable<PrescriptionResource>>(prescriptions);

        return resources;
    }
}