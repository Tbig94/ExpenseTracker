using ExpenseTrackerApi.Application.Common.Interfaces;
using ExpenseTrackerApi.Infrastructure.Persistence;
using ExpenseTrackerApi.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//var configuration = builder.Configuration;
var configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false)
        .Build();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<IAppDbContext, AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
builder.Services.AddScoped<ITokenService, JwtTokenService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    //.AddJwtBearer(jwtOptions =>
    //{
    //    jwtOptions.Authority = "ExpenseTrackerApi";
    //    jwtOptions.Audience = "ExpenseTrackerUi";
    //    jwtOptions.RequireHttpsMetadata = false;
    //    //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Secret"]!)),
    //    jwtOptions.TokenValidationParameters = new()
    //    {
    //        ValidateIssuerSigningKey = true,
    //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("kurva_hosszu_teszt_secret_ami_biztos_jo_lesz")),
    //        // ...
    //    };
    //    jwtOptions.Events = new JwtBearerEvents
    //    {
    //        OnAuthenticationFailed = context =>
    //        {
    //            Console.WriteLine($"Authentication failed: {context.Exception.Message}");
    //            return Task.CompletedTask;
    //        }
    //    };
    //});
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuration["JwtSettings:Secret"]!)
            ),
            ValidateIssuer = true,
            ValidIssuer = configuration["JwtSettings:Issuer"],
            ValidateAudience = true,
            ValidAudience = configuration["JwtSettings:Audience"],
            ValidateLifetime = true
        };
        options.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                Console.WriteLine($"Authentication failed: {context.Exception.Message}");
                return Task.CompletedTask;
            }
        };
    });
//konfiguráció hozzáadása(Issuer, Audience, SigningKey, ValidateLifetime).
//Hiányzó app.UseAuthentication() hívás pótlása UseRouting() után és UseAuthorization() előtt.

ConfigureCors(builder);


// későbbre!!
//builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

ConfigureMediator(builder);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();              // /openapi/v1.json
    app.MapScalarApiReference();   // /scalar/v1 – interaktív UI
}


app.UseRouting();

app.UseCors("AllowAngular");      // ← UseRouting UTÁN, UseAuthentication ELŐTT

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

//app.UseExceptionHandler();

app.Run();


static void ConfigureMediator(WebApplicationBuilder builder)
{
    builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(
        typeof(ExpenseTrackerApi.Application.AssemblyReference).Assembly));
}

static void ConfigureCors(WebApplicationBuilder builder)
{
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAngular", policy =>
        {
            policy
                .WithOrigins("http://localhost:4200")  // Angular dev szerver
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
    });
}