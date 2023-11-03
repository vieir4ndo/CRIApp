using CRIApp.Application.Abstractions;
using CRIApp.Application.Dtos;
using CRIApp.Domain.Data;
using CRIApp.Domain.Helpers;
using CRIApp.Domain.Settings;
using Microsoft.Extensions.Options;

namespace CRIApp.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly UserSettings _settings;

    public UserService(IUserRepository repository, IOptions<UserSettings> settings)
    {
        _repository = repository;
        _settings = settings.Value;
    }
    public async Task Create(CreateUserDto dto)
    {
        var passwordSalt = PasswordHasher.GenerateSalt();
        var passwordHash = PasswordHasher.ComputeHash(dto.Password, passwordSalt, _settings.PasswordPepper, _settings.PasswordHashIterations);

        var user = dto.ToDomainObject(passwordSalt, passwordHash);
        await _repository.Create(user);
    }
}