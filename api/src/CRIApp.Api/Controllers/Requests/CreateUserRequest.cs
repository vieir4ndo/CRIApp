using CRIApp.Application.Dtos;
using CRIApp.Domain.Enums;

namespace CRIApp.Api.Controllers.Requests;

public class CreateUserRequest
{
    public string Name { get; set; }
    public DateOnly BirthDate { get; set; }
    public Sex Sex { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public FamilyType? FamilyType { get; set; }
    public EducationalLevel? EducationalLevel { get; set; }

    public CreateUserDto ToDto()
    {
        return new CreateUserDto()
        {
            Name = Name,
            BirthDate = BirthDate,
            Sex = Sex,
            Email = Email,
            Password = Password,
            FamilyType = FamilyType,
            EducationalLevel = EducationalLevel
        };
    }
}