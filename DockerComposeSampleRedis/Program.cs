using DockerComposeSampleRedis.Services.Redis;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

string DB_REDIS_HOST = Environment.GetEnvironmentVariable("DB_REDIS_HOST");
builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(DB_REDIS_HOST));
builder.Services.AddHttpClient();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
