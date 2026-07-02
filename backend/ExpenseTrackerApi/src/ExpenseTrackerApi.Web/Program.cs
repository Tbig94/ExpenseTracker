using ExpenseTrackerApi.Application.Common.Behaviours;
using ExpenseTrackerApi.Application.Common.Interfaces;
using ExpenseTrackerApi.Infrastructure.Persistence;
using ExpenseTrackerApi.Infrastructure.Services;
using ExpenseTrackerApi.Web.Middlewares;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<IAppDbContext, AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();


// későbbre!!
//builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

ConfigureMediatr(builder);

//System.AggregateException:
//'Some services are not able to be constructed (Error while validating the service descriptor
//  'ServiceType: MediatR.IRequestHandler`2[ExpenseTrackerApi.Application.Categories.Queries.GetCategory.GetCategoryQuery,
//  ExpenseTrackerApi.Application.Categories.Dtos.CategoryDto] Lifetime:
//  Transient ImplementationType: ExpenseTrackerApi.Application.Categories.Queries.GetCategory.GetCategoryQueryHandler':
//  Unable to resolve service for type 'ExpenseTrackerApi.Application.Common.Interfaces.IAppDbContext'
//  while attempting to activate 'ExpenseTrackerApi.Application.Categories.Queries.GetCategory.GetCategoryQueryHandler'.) (Error while validating the service descriptor 'ServiceType: MediatR.IRequestHandler`2[ExpenseTrackerApi.Application.Categories.Queries.GetCategories.GetCategoriesQuery,System.Collections.Generic.List`1[ExpenseTrackerApi.Application.Categories.Dtos.CategoryDto]] Lifetime: Transient ImplementationType: ExpenseTrackerApi.Application.Categories.Queries.GetCategories.GetCategoriesQueryHandler': Unable to resolve service for type 'ExpenseTrackerApi.Application.Common.Interfaces.IAppDbContext' while attempting to activate 'ExpenseTrackerApi.Application.Categories.Queries.GetCategories.GetCategoriesQueryHandler'.)'

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();              // /openapi/v1.json
    app.MapScalarApiReference();   // /scalar/v1 – interaktív UI
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app.UseExceptionHandler();

app.Run();


static void ConfigureMediatr(WebApplicationBuilder builder)
{
    //builder.Services.AddMediatR(cfg =>
    //    cfg.RegisterServicesFromAssemblyContaining<Program>());

    builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(
        typeof(ExpenseTrackerApi.Application.AssemblyReference).Assembly));

    //builder.Services.AddTransient(
    //    typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
    //builder.Services.AddTransient(
    //    typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
}