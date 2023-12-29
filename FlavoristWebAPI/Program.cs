using FlavoristWebAPI.Config;
using Infraestructure.Authorization.Jwt;

var builder = WebApplication.CreateBuilder(args);

// Add Project Dependencies
builder.Services.AddProjectDependencies(builder.Configuration);

// Add Jwt Authentication
builder.Services.AddJwtAuthentication(builder.Configuration);

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
