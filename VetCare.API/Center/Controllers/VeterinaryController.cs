using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VetCare.API.Center.Domain.Models;
using VetCare.API.Center.Domain.Services;
using VetCare.API.Center.Resources;
using VetCare.API.Shared.Extensions;

using VetCare.API.Identification.Authorization.Attributes;

namespace VetCare.API.Center.Controllers;

[Authorize]
[ApiController]
[Route("/api/v1/[controller]")]
public class VeterinaryController : ControllerBase
{
    private readonly IVeterinaryService _veterinaryService;
    private readonly IMapper _mapper;

    public VeterinaryController(IVeterinaryService veterinaryService, IMapper mapper)
    {
        _veterinaryService = veterinaryService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<VeterinaryResource>> GetAllAsync()
    {
        var veterinary = await _veterinaryService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Veterinary>, IEnumerable<VeterinaryResource>>(veterinary);

        return resources;

    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveVeterinaryResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var veterinary = _mapper.Map<SaveVeterinaryResource, Veterinary>(resource);

        var result = await _veterinaryService.SaveAsync(veterinary);

        if (!result.Success)
            return BadRequest(result.Message);

        var veterinaryResource = _mapper.Map<Veterinary, VeterinaryResource>(result.Resource);

        return Ok(veterinaryResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveVeterinaryResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var veterinary = _mapper.Map<SaveVeterinaryResource, Veterinary>(resource);

        var result = await _veterinaryService.UpdateAsync(id, veterinary);

        if (!result.Success)
            return BadRequest(result.Message);

        var veterinaryResource = _mapper.Map<Veterinary, VeterinaryResource>(result.Resource);

        return Ok(veterinaryResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _veterinaryService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var veterinaryResource = _mapper.Map<Veterinary, VeterinaryResource>(result.Resource);

        return Ok(veterinaryResource);
    }

}