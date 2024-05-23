using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VetCare.API.Profiles.Domain.Models;
using VetCare.API.Profiles.Resources;
using VetCare.API.Shared.Extensions;
using VetCare.API.Identification.Authorization.Attributes;
using VetCare.API.Profiles.Domain.Services;

namespace VetCare.API.Profiles.Controllers;

[Authorize]
[ApiController]
[Route("/api/v1/[controller]")]
public class PetOwnerController : ControllerBase
{
    private readonly IPetOwnerService _petOwnerService;
    private readonly IMapper _mapper;

    public PetOwnerController(IPetOwnerService petOwnerService, IMapper mapper)
    {
        _petOwnerService = petOwnerService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<PetOwnerResource>> GetAllAsync()
    {
        var petOwner = await _petOwnerService.ListAsync();
        var resources = _mapper.Map<IEnumerable<PetOwner>, IEnumerable<PetOwnerResource>>(petOwner);

        return resources;

    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SavePetOwnerResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var petOwner = _mapper.Map<SavePetOwnerResource, PetOwner>(resource);

        var result = await _petOwnerService.SaveAsync(petOwner);

        if (!result.Success)
            return BadRequest(result.Message);

        var petOwnerResource = _mapper.Map<PetOwner, PetOwnerResource>(result.Resource);

        return Ok(petOwnerResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SavePetOwnerResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var petOwner = _mapper.Map<SavePetOwnerResource, PetOwner>(resource);

        var result = await _petOwnerService.SaveAsync(petOwner);

        if (!result.Success)
            return BadRequest(result.Message);

        var petOwnerResource = _mapper.Map<PetOwner, PetOwnerResource>(result.Resource);

        return Ok(petOwnerResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _petOwnerService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var petOwnerResource = _mapper.Map<PetOwner, PetOwnerResource>(result.Resource);

        return Ok(petOwnerResource);
    }
    
}