using CRIApp.Domain.Data;
using CRIApp.Domain.Entities;

namespace CRIApp.Infrastructure.Repositories;

public class QuestionRepository : IQuestionRepository
{

    public Task<IEnumerable<Question>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Question> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Answer>> GetAnswers(Guid id)
    {
        throw new NotImplementedException();
    }

    public void Add(Question question)
    {
        throw new NotImplementedException();
    }

    public void Update(Question question)
    {
        throw new NotImplementedException();
    }

    public void Add(Answer answer)
    {
        throw new NotImplementedException();
    }
}