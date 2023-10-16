namespace CRIApp.Domain.Entities;

public class Answer : Entity
{
    public string Text { get; private set; }
    
    public Guid QuestionId { get; private set; }
    public Question Question { get; private set; }
    
    public Guid ChildId { get; private set; }
    public Child Child { get; private set; }
    
    public Guid PrcId { get; private set; }
    public User Prc { get; private set; }
}