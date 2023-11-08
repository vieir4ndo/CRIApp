using CRIApp.Api.Controllers.Validators;
using CRIApp.Application.Dtos;
using CRIApp.Domain.Exceptions;

namespace CRIApp.Api.Controllers.Requests;

public class LoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }

    public LoginDto ToDto()
    {
        return new LoginDto()
        {
            Username = Username,
            Password = Password
        };
    }

    public void ValidateAndThrow()
    {
        var result = new LoginRequestValidator().Validate(this);

        if (result.IsValid)
            return;

        var errors = new List<string>();
        result.Errors.ForEach(x => errors.Add(x.ErrorMessage));
        throw new ValidationException(errors);
    }
}