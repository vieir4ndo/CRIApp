using CRIApp.Application.Dtos;

namespace CRIApp.Application.Abstractions;

public interface IQuestionService
{
    Task<IEnumerable<QuestionDto>> GetAll();
}