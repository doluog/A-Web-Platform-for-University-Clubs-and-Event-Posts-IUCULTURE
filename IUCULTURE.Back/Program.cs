using AutoMapper;
using IUCULTURE.Back.Core.Application.Interfaces;
using IUCULTURE.Back.Core.Application.Mappings;
using IUCULTURE.Back.Infrastructure.Tools;
using IUCULTURE.Back.Persistence.Context;
using IUCULTURE.Back.Persistence.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.RequireHttpsMetadata = false;
        opt.TokenValidationParameters = new
        Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidAudience = JwtTokenDefaults.ValidAudience,
            ValidIssuer = JwtTokenDefaults.ValidIssuer,
            ClockSkew = TimeSpan.Zero,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key)),
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
        };
    });


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
IServiceCollection serviceCollection = builder.Services.AddDbContext<IUCULTUREContext>(opt =>
    {
        opt.UseSqlServer(builder.Configuration.GetConnectionString("Local"));
    });

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
builder.Services.AddAutoMapper(opt =>
{
    opt.AddProfiles(new List<Profile>()
    {
        new ActivityProfile(),
        new ClubProfile(),
    });
});

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
