using ExpenseTrackerApi.Application.Budgets.Dtos;
using ExpenseTrackerApi.Application.Common.Interfaces;
using ExpenseTrackerApi.Application.Common.Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerApi.Application.Budgets.Queries.GetBudgets;

public class GetBudgetsQueryHandler : IRequestHandler<GetBudgetsQuery, List<BudgetDto>>
{
    private readonly IAppDbContext _dbContext;

    public GetBudgetsQueryHandler(IAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<BudgetDto>> Handle(GetBudgetsQuery request, CancellationToken cancellationToken)
    {
        var budgets = await _dbContext.Budgets
            .Where(x => x.Id == request.UserId)
            .AsNoTrackingWithIdentityResolution()
            .ToListAsync(cancellationToken);

        var budgetDtos = new List<BudgetDto>();
        foreach (var budget in budgets)
        {
            budgetDtos.Add(BudgetMappingExtension.ToDto(budget));
        }

        return budgetDtos;
    }
}
