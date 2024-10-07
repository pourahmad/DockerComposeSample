using DockerComposeSample.Data;
using DockerComposeSample.Services;
using DockerComposeSample.Services.Redis;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

string DB_HOST = Environment.GetEnvironmentVariable("DB_HOST");
string DB_NAME = Environment.GetEnvironmentVariable("DB_NAME");
string DB_SA_PASSWORD = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");

builder.Services.AddDbContext<AppDbContext>(option =>
{
    var connectionstring = $"Data Source={DB_HOST};Initial Catalog={DB_NAME}; User ID=sa;Password={DB_SA_PASSWORD};TrustServerCertificate=True;";
    option.UseSqlServer(connectionstring);
    //option.UseSqlServer(builder.Configuration.GetConnectionString(connectionstring));
});

string DB_REDIS_HOST = Environment.GetEnvironmentVariable("DB_REDIS_HOST");
builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(DB_REDIS_HOST));
builder.Services.AddHttpClient();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserService, UserServices>();
builder.Services.AddScoped<IRedisCatchServices, RedisCatchServices>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
