using ExpenseTrackerApi.Application.Common.Interfaces;
using ExpenseTrackerApi.Application.Common.Mappings;
using ExpenseTrackerApi.Application.Expenses.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerApi.Application.Expenses.Queries.GetAllExpenses;

public class GetAllExpensesQueryHandler : IRequestHandler<GetAllExpensesQuery, List<ExpenseDto>>
{
    private readonly IAppDbContext _dbContext;

    public GetAllExpensesQueryHandler(IAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<ExpenseDto>> Handle(GetAllExpensesQuery request, CancellationToken cancellationToken)
    {
        var expenses = await _dbContext.Expenses
            .Include(x => x.Category)
            .ToListAsync(cancellationToken);
        var expenseDtos = new List<ExpenseDto>();
        foreach (var expense in expenses)
        {
            expenseDtos.Add(ExpenseMappingExtension.ToDto(expense));
        }

        return expenseDtos;
    }
}
