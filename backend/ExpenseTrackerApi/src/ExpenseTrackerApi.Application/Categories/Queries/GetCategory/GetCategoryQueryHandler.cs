using ExpenseTrackerApi.Application.Categories.Dtos;
using ExpenseTrackerApi.Application.Common.Interfaces;
using ExpenseTrackerApi.Application.Common.Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerApi.Application.Categories.Queries.GetCategory;

public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, CategoryDto?>
{
    private readonly IAppDbContext _dbContext;
    private readonly ICurrentUserService _currentUser;

    public GetCategoryQueryHandler(IAppDbContext dbContext, ICurrentUserService currentUser)
    {
        _dbContext = dbContext;
        _currentUser = currentUser;
    }

    public async Task<CategoryDto?> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        var category = await _dbContext.Categories
            .AsNoTrackingWithIdentityResolution()
            .FirstOrDefaultAsync(x => 
                x.Id == request.Id, //&&
                //x.UserId == _currentUser.UserId,
                cancellationToken);

        if (category is not null)
        {
            var categoryDto = CategoryMappingExtensions.ToDto(category);
            return categoryDto;
        }
        else return null;
    }
}
