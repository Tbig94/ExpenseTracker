using ExpenseTrackerApi.Application.Common.Interfaces;
using ExpenseTrackerApi.Application.Common.Mappings;
using MediatR;

namespace ExpenseTrackerApi.Application.Budgets.Commands.CreateBudget;

public class CreateBudgetCommandHandler : IRequestHandler<CreateBudgetCommand>
{
    private readonly IAppDbContext _dbContext;

    public CreateBudgetCommandHandler(IAppDbContext dbContect)
    {
        _dbContext = dbContect;
    }

    public async Task Handle(CreateBudgetCommand request, CancellationToken cancellationToken)
    {
        var budget = BudgetMappingExtension.ToEntity(request.Budget);

        await _dbContext.Budgets.AddAsync(budget, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
