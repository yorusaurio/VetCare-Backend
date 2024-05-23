namespace VetCare.API.Appointment.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}