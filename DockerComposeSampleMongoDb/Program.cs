using DockerComposeSampleMongoDb.Data;
using DockerComposeSampleMongoDb.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

string MongoDbConnectionString = Environment.GetEnvironmentVariable("MongoDbConnectionString");
string MongoDbName = Environment.GetEnvironmentVariable("MongoDbName");
builder.Services.AddDbContext<MongoDbContext>(option =>
    option.UseMongoDB(MongoDbConnectionString, MongoDbName));

builder.Services.AddScoped<ICategoryService, CategoryService>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthorization();

app.MapControllers();

app.Run();