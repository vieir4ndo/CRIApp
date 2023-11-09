using CRIApp.Domain.Data;
using CRIApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRIApp.Repository.Repositories;

public class QuestionRepository : IQuestionRepository
{

    private readonly AppContext Context;

    public QuestionRepository(AppContext context)
    {
        Context = context;
    }
    
    public async Task<IEnumerable<Question>> GetAll()
    {
        return await Context.Question
            .ToListAsync();
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