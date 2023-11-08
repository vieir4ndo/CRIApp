using CRIApp.Domain.Data;
using CRIApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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

    public async Task<User?> GetByEmail(string email)
    {
        return await Context.User.FirstOrDefaultAsync(x => x.Email == email);
    }
}