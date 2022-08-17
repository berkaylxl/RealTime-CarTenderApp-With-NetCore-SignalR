using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using TenderApp.Business;
using TenderApp.DataAccess;
using TenderApp.DataAccess.Abstract;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TenderApp.Business.Services.Abstract;
using TenderApp.Business.Services;
using TenderApp.Business.Validation;
using FluentValidation;
using TenderApp.Business.Mapping;
using TenderApp.Entities.DTOs;
using TenderApp.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IUserDal, UserDal>();
builder.Services.AddSingleton<IUserService, UserManager>();

//Validator Services

builder.Services.AddAutoMapper(typeof(UserProfile));
builder.Services.AddScoped<IValidator<User>, UserValidator>();

//Authenticate
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("S3CR3TKEY!?&9785425")),
    };
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
