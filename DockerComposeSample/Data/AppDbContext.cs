using DockerComposeSample.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace DockerComposeSample.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        var databaseCreate = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
        if (databaseCreate != null)
        {
            if(!databaseCreate.CanConnect()) databaseCreate.Create();
            if(!databaseCreate.HasTables()) databaseCreate.CreateTables();
        }
    }

    public DbSet<User> Users { get; set; }
}
