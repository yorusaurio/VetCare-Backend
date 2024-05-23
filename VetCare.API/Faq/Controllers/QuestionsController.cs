using AutoMapper;
using VetCare.API.Identification.Authorization.Attributes; //this library it's very important 
using VetCare.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using VetCare.API.Faq.Domain.Models;
using VetCare.API.Faq.Domain.Services;
using VetCare.API.Faq.Resources;

namespace VetCare.API.Faq.Controllers;

[Authorize]
[ApiController]
[Route("/api/v1/[controller]")]

public class QuestionsController :ControllerBase
{
    private readonly IQuestionService _questionService;
    private readonly IMapper _mapper;

    public QuestionsController(IQuestionService questionService, IMapper mapper)
    {
        _questionService = questionService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<QuestionResource>> GetAllAsync()
    {
        var questions = await _questionService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Question>, IEnumerable<QuestionResource>>(questions);

        return resources;
    }
    
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveQuestionResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var question = _mapper.Map<SaveQuestionResource, Question>(resource);

        var result = await _questionService.SaveAsync(question);

        if (!result.Success)
            return BadRequest(result.Message);

        var questionResource = _mapper.Map<Question, QuestionResource>(result.Resource);

        return Ok(questionResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveQuestionResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var question = _mapper.Map<SaveQuestionResource, Question>(resource);

        var result = await _questionService.UpdateAsync(id, question);

        if (!result.Success)
            return BadRequest(result.Message);

        var questionResource = _mapper.Map<Question, QuestionResource>(result.Resource);

        return Ok(questionResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _questionService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var questionResource = _mapper.Map<Question, QuestionResource>(result.Resource);

        return Ok(questionResource);
    }
}