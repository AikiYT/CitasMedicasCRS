using CitasMedicasApp.Persistance.Context;
using CitasMedicasApp.Persistance.Interface.Appointments;
using CitasMedicasApp.Persistance.Interface.Insurance;
using CitasMedicasApp.Persistance.Repositories.Appointments;
using CitasMedicasApp.Persistance.Repositories.Insurance;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CitaContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CitasMedicasDb")));

// el registro de cada una de las dependencias repositorios de configuracion //

builder.Services.AddScoped<IinsuranceNetworkTypeRepositorio, InsuranceNetworkTypeRepositorio>();
builder.Services.AddScoped<IinsuranceProvidersRepositorio, InsuranceProvidersRepositorio>();




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
