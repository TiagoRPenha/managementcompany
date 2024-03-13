using Management.Api.Configurations;
using Management.Application.Commands.CompanyCommand.CreateCompany;
using Management.Application.Mappings;
using Management.Infrastructure.DbContextConfiguration;
using Microsoft.EntityFrameworkCore;
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

builder.Services.AddDbContext<ManagementContext>(options =>
    options.UseMySql(connection, ServerVersion.AutoDetect(connection))
);

builder.Services.ResolveDependenciesInjection();
builder.Services.AddMediatR(m => m.RegisterServicesFromAssembly(typeof(CreateCompanyCommand).Assembly));

builder.Services.AddAutoMapper(typeof(ManagerMapping));

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

//MigrationsConfig.MigrationInitialisation(app);

app.Run();
