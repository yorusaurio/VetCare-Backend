using Microsoft.EntityFrameworkCore;
using VetCare.API.Shared.Persistence.Contexts;
using VetCare.API.Shared.Persistence.Repositories;
using VetCare.API.Faq.Domain.Models;
using VetCare.API.Faq.Domain.Repositories;

namespace VetCare.API.Faq.Persistence.Repositories;

public class QuestionRepository : BaseRepository, IQuestionRepository
{
    public QuestionRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Question>> ListAsync()
    {
        return await _context.Questions
            .ToListAsync();
    }

    public async Task AddAsync(Question question)
    {
        await _context.Questions.AddAsync(question);
    }

    public async Task<Question> FindByIdAsync(int questionId)
    {
        return await _context.Questions
            .FirstOrDefaultAsync(p => p.Id == questionId);
    }

    public void Update(Question question)
    {
        _context.Questions.Update(question);
    }

    public void Remove(Question question)
    {
        _context.Questions.Remove(question);
    }
}