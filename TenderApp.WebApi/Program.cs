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
using TenderApp.Business.SignalRHub;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(opt => opt.AddDefaultPolicy((policy) =>
{
    policy.AllowAnyMethod()
          .AllowAnyHeader()
          .AllowCredentials()
          .SetIsOriginAllowed(origin => true);
}));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IAuthService, AuthManager>();

builder.Services.AddSingleton<IDocumentDal, DocumentDal>();
builder.Services.AddSingleton<IDocumentService, DocumentManager>();

builder.Services.AddSingleton<ICarDal, CarDal>();
builder.Services.AddSingleton<ICarService, CarManager>();

builder.Services.AddSingleton<ITenderDal, TenderDal>();
builder.Services.AddSingleton<ITenderService, TenderManager>();

builder.Services.AddSingleton<ICorporateCustomerDal, CorporateCustomerDal>();
builder.Services.AddSingleton<ICorporateCustomerService, CorporateCustomerManager>();

builder.Services.AddSingleton<IIndividualCustomerDal, IndividualCustomerDal>();
builder.Services.AddSingleton<IIndividualCustomerService, IndividualCustomerManager>();

builder.Services.AddSignalR();

//Validator Services

builder.Services.AddAutoMapper(typeof(UserProfile));
builder.Services.AddScoped<IValidator<User>, LoginValidator>();
builder.Services.AddScoped<IValidator<IndividualCustomer>, IndividualCustomerRegisterValidator>();
builder.Services.AddScoped<IValidator<CorporateCustomer>, CorporateCustomerRegisterValidator>();

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


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.MapHub<TenderHub>("/tenderHub");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();


app.Run();
