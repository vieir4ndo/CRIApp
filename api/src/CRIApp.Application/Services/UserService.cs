using CRIApp.Application.Abstractions;
using CRIApp.Application.Dtos;
using CRIApp.Domain.Data;

namespace CRIApp.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }
    public async Task Create(CreateUserDto dto)
    {
        await _repository.Create(dto.ToDomainObject());
    }
}