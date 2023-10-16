namespace CRIApp.Domain.Entities;

public class Question : Entity, IAggregateRoot
{
    public string Text { get; private set; }
    
    public List<Answer> Answers { get; private set; }
    
    public Guid AdminId { get; private set; }
    public User Admin { get; private set; }
}