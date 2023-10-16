using CRIApp.Domain.Enums;

namespace CRIApp.Domain.Entities;

public class User : Entity
{
    #region MandatoryFields
    
    public string Name { get; private set; }
    public DateOnly BirthDate { get; private set; }
    public Sex Sex { get; private set; }
    public string Email { get; private set; }
    private string Password { get; set; }
    
    #endregion
    
    #region OptionFields

    public int? NumberOfChildren { get; private set; }
    public FamilyType? FamilyType { get; private set; }
    public EducationalLevel? EducationalLevel { get; private set; }
    public List<Answer> Answers { get; private set; } = new();
    public List<Child> Children { get; private set; } = new();

    #endregion
}