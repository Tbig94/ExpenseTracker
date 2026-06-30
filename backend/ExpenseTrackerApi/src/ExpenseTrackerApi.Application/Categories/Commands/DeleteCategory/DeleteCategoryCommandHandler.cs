using ExpenseTrackerApi.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerApi.Application.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
{
    private readonly IAppDbContext _dbContext;

    public DeleteCategoryCommandHandler(IAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _dbContext.Categories
            .AsNoTrackingWithIdentityResolution()
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (category is not null)
        {
            _dbContext.Categories.Attach(category);
            _dbContext.Categories.Remove(category);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
