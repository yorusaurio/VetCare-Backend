using VetCare.API.Profiles.Domain.Repositories;
using VetCare.API.Shared.Persistence.Contexts;

namespace VetCare.API.Shared.Persistence.Repositories;

public class UnitOfWorkP : IUnitOfWorkP
{
    private readonly AppDbContext _context;
    

    public UnitOfWorkP(AppDbContext context)
    {
        _context = context;
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}