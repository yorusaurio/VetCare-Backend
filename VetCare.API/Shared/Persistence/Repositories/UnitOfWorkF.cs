
using VetCare.API.Faq.Domain.Repositories;
using VetCare.API.Shared.Persistence.Contexts;

namespace VetCare.API.Shared.Persistence.Repositories;

public class UnitOfWorkF : IUnitOfWorkF
{
    private readonly AppDbContext _context;

    public UnitOfWorkF(AppDbContext context)
    {
        _context = context;
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}