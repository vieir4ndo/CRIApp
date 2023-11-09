using CRIApp.Application.Abstractions;
using CRIApp.Application.Dtos;
using CRIApp.Domain.Data;

namespace CRIApp.Application.Services;

public class QuestionService : IQuestionService
{
    private readonly IQuestionRepository _questionRepository;

    public QuestionService(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }
    public async Task<IEnumerable<QuestionDto>> GetAll()
    {
        var questions = await _questionRepository.GetAll();

        return questions.Select(question => new QuestionDto(question));
    }
}