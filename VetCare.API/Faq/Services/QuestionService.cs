using VetCare.API.Faq.Domain.Models;
using VetCare.API.Faq.Domain.Repositories;
using VetCare.API.Faq.Domain.Services;
using VetCare.API.Faq.Domain.Services.Communication;

namespace VetCare.API.Faq.Services;


public class QuestionService : IQuestionService
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IUnitOfWorkF _unitOfWorkF;
    
    public QuestionService(IQuestionRepository questionRepository, IUnitOfWorkF unitOfWorkF)
    {
        _questionRepository = questionRepository;
        _unitOfWorkF = unitOfWorkF;
    }
    
    public async Task<IEnumerable<Question>> ListAsync()
    {
        return await _questionRepository.ListAsync();
    }

    public async Task<QuestionResponse> SaveAsync(Question question)
    {
        var existingQuestionWithId = await _questionRepository.FindByIdAsync(question.Id);
        if (existingQuestionWithId !=null)
            return new QuestionResponse("Question already exists");

        try
        {
            await _questionRepository.AddAsync(question);
            await _unitOfWorkF.CompleteAsync();
            return new QuestionResponse(question);
        }
        catch (Exception e)
        {
            return new QuestionResponse($"An error occurred while saving the question: {e.Message}");
        }
    }

    public async Task<QuestionResponse> UpdateAsync(int questionId, Question question)
    {
        // Validate Tutorial
        var existingQuestion = await _questionRepository.FindByIdAsync(questionId);
        if (existingQuestion == null)
            return new QuestionResponse("Question not found.");
        // Validate Title
        // var existingTutorialWithTitle = await _tutorialRepository.FindByTitleAsync(tutorial.Title);
        // if (existingTutorialWithTitle != null && existingTutorialWithTitle.Id != existingTutorial.Id)
        //      return new TutorialResponse("Tutorial title already exists.");
        
        //VERIFICAR VALIDACION -- AGREGAR EN LA INTERFAZ DEL MODELO FindByNameAsync para validar con nombre
        
        // Modify Fields
        existingQuestion.Name = question.Name;
        existingQuestion.Description = question.Description;
        
        try
        {
            _questionRepository.Update(existingQuestion);
            await _unitOfWorkF.CompleteAsync();

            return new QuestionResponse(existingQuestion);
            
        }
        catch (Exception e)
        {
            // Error Handling
            return new QuestionResponse($"An error occurred while updating the question: {e.Message}");
        }
    }

    public async Task<QuestionResponse> DeleteAsync(int questionId)
    {
        var existingQuestion = await _questionRepository.FindByIdAsync(questionId);
        
        // Validate Tutorial

        if (existingQuestion == null)
            return new QuestionResponse("Question not found.");
        
        try
        {
            _questionRepository.Remove(existingQuestion);
            await _unitOfWorkF.CompleteAsync();

            return new QuestionResponse(existingQuestion);
            
        }
        catch (Exception e)
        {
            // Error Handling
            return new QuestionResponse($"An error occurred while deleting the question: {e.Message}");
        }
    }
}