using CRIApp.Api.Controllers.Validators;
using CRIApp.Application.Dtos;
using CRIApp.Domain.Enums;
using CRIApp.Domain.Exceptions;

namespace CRIApp.Api.Controllers.Requests;

public class CreateUserRequest
{
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
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

    public void ValidateAndThrow()
    {
        var result = new CreateUserRequestValidator().Validate(this);

        if (result.IsValid) 
            return;
        
        var errors = new List<string>();
        result.Errors.ForEach(x => errors.Add(x.ErrorMessage));
        throw new ValidationException(errors);
    }
}