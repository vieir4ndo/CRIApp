using CRIApp.Application.Dtos;

namespace CRIApp.Application.Abstractions;

public interface IUserService
{ 
    Task Create(CreateUserDto dto);
}