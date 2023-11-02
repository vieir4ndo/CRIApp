using CRIApp.Domain.Entities;

namespace CRIApp.Domain.Data;

public interface IUserRepository : IRepository<User>
{
    Task Create(User user);
}