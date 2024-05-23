namespace VetCare.API.Profiles.Domain.Repositories;

public interface IUnitOfWorkP
{
    Task CompleteAsync();
}