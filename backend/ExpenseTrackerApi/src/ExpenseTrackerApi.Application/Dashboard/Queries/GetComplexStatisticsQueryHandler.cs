using ExpenseTrackerApi.Application.Common;
using ExpenseTrackerApi.Application.Common.Interfaces;
using ExpenseTrackerApi.Application.Dashboard.Dtos;
using ExpenseTrackerApi.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerApi.Application.Dashboard.Queries;

public class GetComplexStatisticsQueryHandler : IRequestHandler<GetComplexStatisticsQuery, DashboardDto>
{
    private readonly IAppDbContext _dbContext;
    private readonly ICurrentUserService _currentUser;

    public GetComplexStatisticsQueryHandler(IAppDbContext dbContext, ICurrentUserService currentUser)
    {
        _dbContext = dbContext;
        _currentUser = currentUser;
    }
    public async Task<DashboardDto> Handle(GetComplexStatisticsQuery request, CancellationToken cancellationToken)
    {
        var dashboardDto = new DashboardDto();

        var now = DateTime.UtcNow;
        var lastMonth = now.AddMonths(-1);

        dashboardDto.CurrentMonth = new()
        {
            Year = now.Year,
            Month = now.Month
        };

        // +++ 1. +++
        var currentMonthExpense = await _dbContext.Expenses
                .Where(x => x.UserId == _currentUser.UserId &&
                            x.Date.Year == now.Year &&
                            x.Date.Month == now.Month)
                .Select(x => x.Amount).SumAsync(cancellationToken);

        var lastMonthExpense = await _dbContext.Expenses
                .Where(x => x.UserId == _currentUser.UserId &&
                            x.Date.Year == now.Year &&
                            x.Date.Month == lastMonth.Month)
                .Select(x => x.Amount).SumAsync(cancellationToken);

        dashboardDto.MonthlySummary = new()
        {
            TotalAmount = currentMonthExpense,
            PreviousMonthAmount = lastMonthExpense,
            ChangePercent = lastMonthExpense == 0
                ? 0
                : (currentMonthExpense / lastMonthExpense * 100) - 100
        };

        // +++ 2. +++
        var categoryBreakdowns = await _dbContext.Expenses
            .Where(x => x.UserId == _currentUser.UserId
                     && x.Date.Year == now.Year
                     && x.Date.Month == now.Month)
            .GroupBy(x => new { x.Category.Name, x.Category.Color })
            .Select(g => new CategoryBreakdownDto
            {
                CategoryName = g.Key.Name,
                CategoryColor = g.Key.Color,
                Amount = g.Sum(x => x.Amount),
                Percentage = currentMonthExpense == 0
                    ? 0
                    : g.Sum(x => x.Amount) / currentMonthExpense * 100
            })
            .ToListAsync(cancellationToken);

        dashboardDto.CategoryBreakdowns = categoryBreakdowns;

        // +++ 3. +++
        var budgets = await _dbContext.Budgets
            .Where(b => b.UserId == _currentUser.UserId
                     && b.Month == now.Month
                     && b.Year == now.Year)
            .Select(b => new
            {
                b.LimitAmount,
                b.Category.Name,
                b.Category.Color,
                SpentAmount = _dbContext.Expenses
                    .Where(e => e.UserId == _currentUser.UserId
                             && e.CategoryId == b.CategoryId
                             && e.Date.Month == now.Month
                             && e.Date.Year == now.Year)
                    .Sum(e => (decimal?)e.Amount) ?? 0m
            })
            .ToListAsync(cancellationToken);

        dashboardDto.Budgets = budgets
        .Select(b => new BudgetDashboardDto
        {
            CategoryName = b.Name,
            CategoryColor = b.Color,
            LimitAmount = b.LimitAmount,
            SpentAmount = b.SpentAmount,
            RemainingAmount = b.LimitAmount - b.SpentAmount,
            State = BudgetStateCalculator.Calculate(b.LimitAmount, b.SpentAmount)
        })
        .ToList();

        // +++ 4. +++
        var topExpenses = await _dbContext.Expenses
            .Include(x => x.Category)
            .Where(x => x.UserId == _currentUser.UserId &&
                        x.Date.Month == now.Month)
            .OrderByDescending(x => x.Amount)
            .Take(3)
            .ToListAsync(cancellationToken);

        foreach (var item in topExpenses)
        {
            dashboardDto.TopExpenses.Add(new()
            {
                Amount = item.Amount,
                CategoryName = item.Category.Name,
                Date = item.Date,
                Description = item.Description
            });
        }

        dashboardDto.Budgets
            .Where(b => b.State == BudgetState.NearLimit ||
                        b.State == BudgetState.Exceeded)
            .ToList();

        return dashboardDto;
    }
}
