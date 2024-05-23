namespace VetCare.API.Center.Domain.Repositories;

public interface IUnitOfWorkV
{
    Task CompleteAsync();
}