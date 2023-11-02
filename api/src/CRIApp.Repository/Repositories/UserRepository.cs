using CRIApp.Domain.Data;
using CRIApp.Domain.Entities;

namespace CRIApp.Repository.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppContext Context;

    public UserRepository(AppContext context)
    {
        Context = context;
    }
    public async Task Create(User user)
    {
        await Context.User.AddAsync(user);
        await Context.SaveChangesAsync();
    }
}