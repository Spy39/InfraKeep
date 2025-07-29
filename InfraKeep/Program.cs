using FluentValidation;
using FluentValidation.AspNetCore;
using InfraKeep.Domain;
using InfraKeep.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using InfraKeep.Domain.Roles;
using Microsoft.AspNetCore.Identity;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddFluentValidation();
builder.Services.AddValidatorsFromAssemblyContaining<InfraKeep.Application.AssemblyReference>();

//EF Core
var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseNpgsql(connectionString));
builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = "your-app",
            ValidateAudience = true,
            ValidAudience = "your-app",
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(".............")), // Составить ключ подписи определенного размера
            ValidateIssuerSigningKey = true,
        };
    });


builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
//SQRS
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(InfraKeep.Application.AssemblyReference).Assembly));

builder.Services.AddAutoMapper(typeof(InfraKeep.Application.AssemblyReference).Assembly);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();