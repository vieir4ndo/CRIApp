using CRIApp.Domain.Enums;

namespace CRIApp.Domain.Entities;

public class User : Entity, IAggregateRoot
{
    public string Name { get; private set; }
    public DateOnly BirthDate { get; private set; }
    public Sex Sex { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public bool Active { get; private set; }
    public int? NumberOfChildren { get; private set; }
    public FamilyType? FamilyType { get; private set; }
    public EducationalLevel? EducationalLevel { get; private set; }
    public List<Answer> Answers { get; private set; } = new();
    public List<Child> Children { get; private set; } = new();
    public List<Question> Questions { get; private set; } = new();
    public List<AudiovisualResource> AudiovisualResources { get; private set; } = new();
    public List<Award> Awards { get; private set; } = new();
    
    public void Activate() => Active = true;

    public void Deactivate() => Active = false;
}