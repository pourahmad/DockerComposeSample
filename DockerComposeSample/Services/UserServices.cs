using DockerComposeSample.Data;
using DockerComposeSample.Entities;
using Microsoft.EntityFrameworkCore;

namespace DockerComposeSample.Services;

public class UserServices(AppDbContext context) : IUserService
{
    private readonly AppDbContext _context = context;
    public async Task<object> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }
    public async Task<object> GetByIdAsync(Guid id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<Guid> AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return user.Id;
    }

    public async Task UpdateAsync(User user)
    {
        var userFind = await _context.Users.FindAsync(user.Id);
        userFind.FullName = user.FullName;

        _context.Users.Update(userFind);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var userFind = await _context.Users.FindAsync(id);

        _context.Users.Remove(userFind);
        await _context.SaveChangesAsync();
    }
}
