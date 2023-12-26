using Application.Interfaces;
using Application.Services;
using Domain.DTOs;
using Domain;
using Infraestructure.Data.Context;
using Infraestructure.Data.Repository;
using System.Diagnostics;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//// Agrega la configuración del servicio de autorización
//builder.Services.AddScoped<IServiceAuthorization<Usuario, AuthResultDTO>>(provider =>
//    new AuthorizationService(provider.GetRequiredService<IConfiguration>()));


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(
        options =>
        {
            options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"])),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        }
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configuración de la base de datos
DBContext db = new();
if (db.Database.EnsureCreated())
{
    Debug.WriteLine("No existe la base de datos");
    Debug.WriteLine("Creando la base de datos...");
    Debug.WriteLine("Se creó la base de datos!");
}
else
{
    Debug.WriteLine("La base de datos ya existe!");
}

db.Dispose();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers().RequireAuthorization();

app.Run();
