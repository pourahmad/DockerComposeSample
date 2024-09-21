using DockerComposeSample.Data;
using DockerComposeSample.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(option =>
{
    string DB_HOST = Environment.GetEnvironmentVariable("DB_HOST");
    string DB_NAME = Environment.GetEnvironmentVariable("DB_NAME");
    string DB_SA_PASSWORD = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
    var connectionstring = $"Data Source={DB_HOST};Initial Catalog={DB_NAME}; User ID=sa;Password={DB_SA_PASSWORD};TrustServerCertificate=True";
    option.UseSqlServer(builder.Configuration.GetConnectionString(connectionstring));
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserService, UserServices>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
