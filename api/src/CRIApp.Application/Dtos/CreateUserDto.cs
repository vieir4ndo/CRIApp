using CRIApp.Domain.Entities;
using CRIApp.Domain.Enums;

namespace CRIApp.Application.Dtos;

public class CreateUserDto
{
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public Sex Sex { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public FamilyType? FamilyType { get; set; }
    public EducationalLevel? EducationalLevel { get; set; }

    public User ToDomainObject(string passwordHash, string passwordSalt)
    {
        return new User(Name, BirthDate, Sex, Email, passwordHash, passwordSalt, FamilyType, EducationalLevel);
    }
}