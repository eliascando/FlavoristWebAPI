using FlavoristWebAPI.Config;
using Infraestructure.Authorization.Jwt;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add Jwt Authentication and Authorization
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireClaim(ClaimTypes.Role, "Admin"));
});

// Inject Dependencies
builder.Services.InjectDependencies(builder.Configuration);

// Build the container
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Use Cors Policy
app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers().RequireAuthorization();

app.Run();
