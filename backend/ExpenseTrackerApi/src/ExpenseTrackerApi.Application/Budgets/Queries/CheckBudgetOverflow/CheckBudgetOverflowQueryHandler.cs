using ExpenseTrackerApi.Application.Budgets.Dtos;
using ExpenseTrackerApi.Application.Common;
using ExpenseTrackerApi.Application.Common.Interfaces;
using ExpenseTrackerApi.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerApi.Application.Budgets.Queries.CheckBudgetOVerflow;

public class CheckBudgetOverflowQueryHandler : IRequestHandler<CheckBudgetOverflowQuery, BudgetStatusDto>
{
    private readonly IAppDbContext _dbContext;

    public CheckBudgetOverflowQueryHandler(IAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<BudgetStatusDto> Handle(CheckBudgetOverflowQuery request, CancellationToken cancellationToken)
    {
        var budget = await _dbContext.Budgets.FirstOrDefaultAsync(x => x.UserId == request.UserId && x.CategoryId == request.CategoryId, cancellationToken);
        var expense = await _dbContext.Expenses.FirstOrDefaultAsync(x => x.UserId == request.UserId && x.CategoryId == request.CategoryId, cancellationToken);

        var budgetState = BudgetStateCalculator.Calculate(budget.LimitAmount, expense.Amount);

        var budgetStatus = new BudgetStatusDto(budget.LimitAmount, expense.Amount, budget.LimitAmount - expense.Amount, budgetState);

        return budgetStatus;
    }
}
