using CRIApp.Domain.Entities;

namespace CRIApp.Domain.Data;

public interface IQuestionRepository : IRepository<Question>
{
    Task<IEnumerable<Question>> GetAll();

    Task<Question> GetById(Guid id);

    Task<IEnumerable<Answer>> GetAnswers(Guid id);

    void Add(Question question);
    
    void Update(Question question);

    void Add(Answer answer);
} 