using AutoMapper;
using VetCare.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using VetCare.API.Appointment.Domain.Models;
using VetCare.API.Appointment.Domain.Services;
using VetCare.API.Appointment.Resources;
using VetCare.API.Identification.Authorization.Attributes;


namespace VetCare.API.Appointment.Controllers;

[Authorize]
[ApiController]
[Route("/api/v1/[controller]")]
public class PrescriptionsController : ControllerBase
{
    private readonly IPrescriptionService _prescriptionService;
    private readonly IMapper _mapper;

    public PrescriptionsController(IPrescriptionService prescriptionService, IMapper mapper)
    {
        _prescriptionService = prescriptionService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<PrescriptionResource>> GetAllAsync()
    {
        var prescriptions = await _prescriptionService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Prescription>, IEnumerable<PrescriptionResource>>(prescriptions);

        return resources;

    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SavePrescriptionResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var prescription = _mapper.Map<SavePrescriptionResource, Prescription>(resource);

        var result = await _prescriptionService.SaveAsync(prescription);

        if (!result.Success)
            return BadRequest(result.Message);

        var prescriptionResource = _mapper.Map<Prescription, PrescriptionResource>(result.Resource);

        return Ok(prescriptionResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SavePrescriptionResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var prescription = _mapper.Map<SavePrescriptionResource, Prescription>(resource);

        var result = await _prescriptionService.UpdateAsync(id, prescription);

        if (!result.Success)
            return BadRequest(result.Message);

        var prescriptionResource = _mapper.Map<Prescription, PrescriptionResource>(result.Resource);

        return Ok(prescriptionResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _prescriptionService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var prescriptionResource = _mapper.Map<Prescription, PrescriptionResource>(result.Resource);

        return Ok(prescriptionResource);
    }

}