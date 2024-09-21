using DockerComposeSample.Entities;

namespace DockerComposeSample.Services;

public interface IUserService
{
    Task<object> GetByIdAsync(Guid id);
    Task<object> GetAllAsync();
    Task<Guid> AddAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(Guid id);
}
