using CRIApp.Domain.Entities;

namespace CRIApp.Application.Abstractions;

public interface IQuestionService
{
    Task<IEnumerable<Question>> GetAll();
}