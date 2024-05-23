using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VetCare.API.Center.Domain.Models;
using VetCare.API.Center.Domain.Services;
using VetCare.API.Center.Resources;

using VetCare.API.Identification.Authorization.Attributes;

namespace VetCare.API.Center.Controllers;

[Authorize]
[ApiController]
[Route("/api/v1/vets/{vetId}/veterinary")]
public class VetVeterinaryController : ControllerBase
{
    private readonly IVeterinaryService _veterinaryService;
    private readonly IMapper _mapper;

    public VetVeterinaryController(IVeterinaryService veterinaryService, IMapper mapper)
    {
        _veterinaryService = veterinaryService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<VeterinaryResource>> GetAllByVetIdAsync(int vetId)
    {
        var veterinary = await _veterinaryService.ListByVetIdAsync(vetId);

        var resources = _mapper.Map<IEnumerable<Veterinary>, IEnumerable<VeterinaryResource>>(veterinary);

        return resources;
    }
}