using CRIApp.Application.Dtos;
using CRIApp.Domain.Entities;

namespace CRIApp.Application.Abstractions;

public interface IUserService
{ 
    Task Create(CreateUserDto dto);
    Task Login(LoginDto dto);
    Task<User?> GetByEmail(string email);
}