using VetCare.API.Faq.Domain.Models;
using VetCare.API.Faq.Domain.Services.Communication;

namespace VetCare.API.Faq.Domain.Services;

public interface IQuestionService
{
    Task<IEnumerable<Question>> ListAsync();
    Task<QuestionResponse> SaveAsync(Question question);
    Task<QuestionResponse> UpdateAsync(int questionId, Question question);
    Task<QuestionResponse> DeleteAsync(int questionId);
}