using ExpenseTrackerApi.Application.Categories.Dtos;
using ExpenseTrackerApi.Application.Common.Interfaces;
using ExpenseTrackerApi.Application.Common.Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerApi.Application.Categories.Queries.GetCategories;

public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, List<CategoryDto>>
{
    private readonly IAppDbContext _dbContext;

    public GetCategoriesQueryHandler(IAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = _dbContext.Categories
            .AsNoTrackingWithIdentityResolution();

        var dtos = new List<CategoryDto>();
        foreach (var category in categories)
        {
            dtos.Add(CategoryMappingExtensions.ToDto(category));
        }

        return dtos;
    }
}
        