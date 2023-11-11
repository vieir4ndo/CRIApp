using CRIApp.Application.Abstractions;
using CRIApp.Application.Dtos;
using CRIApp.Domain.Data;
using CRIApp.Domain.Entities;
using CRIApp.Domain.Exceptions;
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

    public async Task Login(LoginDto dto)
    {
        var user = await GetByEmail(dto.Username);

        if (user is not null)
        {
            var passwordHash = PasswordHasher.ComputeHash(dto.Password, user.PasswordSalt,  _settings.PasswordPepper, _settings.PasswordHashIterations);

            if (user.PasswordHash == passwordHash)
                return;
        }

        throw new ValidationException("Username or password did not match");
    }
    
    public async Task<User?> GetByEmail(string email)
    {
        return await _repository.GetByEmail(email);
    }

    public async Task<User?> GetAndValidateById(Guid id)
    {
        var user = await _repository.GetById(id);

        if (user is null)
            throw new NotFoundException("User not found");

        return user;
    }
}