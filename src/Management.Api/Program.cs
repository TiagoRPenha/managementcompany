// <summary> Program, Application configuration class </summary>
// <remarks>
// <para>author: <c>tiago.penha</c></para>
// <para>date: <c>2024-03-14</c></para>
// </remarks>
using Management.Api.Configurations;
using Management.Api.Configurations.EventSourcing;
using Management.Application.Commands.CompanyCommand.CreateCompany;
using Management.Application.Mappings;
using Management.Core.Configurations;
using Management.Infrastructure.DbContextConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StackExchange.Redis;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connection = builder.Configuration.GetConnectionString("WebApiDatabase");

#region Adding the Context Application
builder.Services.AddDbContext<ManagementContext>(options =>
    options.UseMySql(connection, ServerVersion.AutoDetect(connection))
);
#endregion

#region Adding class Resolve Dependencies Injection
builder.Services.ResolveDependenciesInjection();
#endregion

#region Adding the Mediator
builder.Services.AddMediatR(m => m.RegisterServicesFromAssembly(typeof(CreateCompanyCommand).Assembly));
#endregion

#region Adding the AutoMapper
builder.Services.AddAutoMapper(typeof(ManagerMapping));
#endregion

#region Adding the Configuration Event Sourcing with Redis
builder.Services.AddEventHandlers(typeof(Program));
builder.Services.AddSingleton<IEventListener>((provider =>
    new EventListener(provider.GetRequiredService<IDatabase>(),
    provider.GetRequiredService<IOptions<RedisConfig>>(),
    provider.GetRequiredService<ILogger<EventListener>>(),
    provider)));

builder.Services.Configure<RedisConfig>(builder.Configuration.GetSection("RedisConfig"));
var redis = ConnectionMultiplexer.Connect(builder.Configuration.GetSection("RedisConfig:Url").Value!);
var redisDatabase = redis.GetDatabase();
builder.Services.AddSingleton(redisDatabase);
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.ListenForRedisEvents();

MigrationsConfiguration.MigrationInitialisation(app);

app.Run();
