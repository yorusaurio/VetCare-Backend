namespace VetCare.API.Store.Domain.Repositories;

public interface IUnitOfWorkS
{
    Task CompleteAsync();
}