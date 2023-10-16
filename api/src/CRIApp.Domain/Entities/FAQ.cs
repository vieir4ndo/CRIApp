namespace CRIApp.Domain.Entities;

public class FAQ : Entity
{
    public string Question { get; private set; }
    public string Answer { get; private set; }
    
    public Guid AdminId { get; private set; }
    public User Admin { get; private set; }
}