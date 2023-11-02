using CRIApp.Domain.Enums;

namespace CRIApp.Domain.Entities;

public class Child : Entity
{
    public string Name { get; private set; }
    public DateOnly BirthDate { get; private set; }
    public Sex Sex { get; private set; }
    public int MonthsOfBreastFeeding { get; private set; }
    public Guid PrcId { get; private set; }
    public User Prc { get; private set; }
    public List<Answer> Answers { get; private set;  }
}