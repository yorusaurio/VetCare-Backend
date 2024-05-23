using VetCare.API.Faq.Domain.Models;

namespace VetCare.API.Faq.Domain.Repositories;

public interface IQuestionRepository
{
    Task<IEnumerable<Question>> ListAsync();
    Task AddAsync(Question question);
    Task<Question> FindByIdAsync(int questionId);
    void Update(Question question);
    void Remove(Question question);
}