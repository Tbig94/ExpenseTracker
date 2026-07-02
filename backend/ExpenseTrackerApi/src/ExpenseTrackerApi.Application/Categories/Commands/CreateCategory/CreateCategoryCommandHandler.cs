using ExpenseTrackerApi.Application.Common.Interfaces;
using ExpenseTrackerApi.Domain.Entities;
using MediatR;

namespace ExpenseTrackerApi.Application.Categories.Commands.CreateCategory;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Guid>
{
    private readonly IAppDbContext _dbContext;
    private readonly ICurrentUserService _currentUser;

    public CreateCategoryCommandHandler(IAppDbContext dbContext, ICurrentUserService currentUser)
    {
        _dbContext = dbContext;
        _currentUser = currentUser;
    }

    public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var userId = _currentUser.UserId;

        var category = new Category(userId, request.Name, request.Color);

        await _dbContext.Categories.AddAsync(category, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return category.Id;
    }
}
