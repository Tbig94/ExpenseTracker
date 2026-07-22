using ExpenseTrackerApi.Application.Common.Interfaces;
using ExpenseTrackerApi.Application.Common.Mappings;
using ExpenseTrackerApi.Application.Expenses.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerApi.Application.Expenses.Queries.GetExpensesByFilter;

public class GetExpensesByFilterQueryHandler : IRequestHandler<GetExpensesByFilterQuery, List<ExpenseDto>>
{
    private readonly IAppDbContext _dbContext;

    public GetExpensesByFilterQueryHandler(IAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<ExpenseDto>> Handle(GetExpensesByFilterQuery request, CancellationToken cancellationToken)
    {
        string? filterText = request.Filter.Text?.ToLower();

        var q = _dbContext.Expenses
            .Include(x => x.Category)
            .AsNoTrackingWithIdentityResolution()
            .AsQueryable();
        if (request.Filter.MinDate is not null)
        {
            q = q.Where(x => x.Date >= request.Filter.MinDate);
        }
        if (request.Filter.MaxDate is not null)
        {
            q = q.Where(x => x.Date <= request.Filter.MaxDate);
        }
        if (request.Filter.MinAmount is not null)
        {
            q = q.Where(x => x.Amount >= request.Filter.MinAmount);
        }
        if (request.Filter.MaxAmount is not null)
        {
            q = q.Where(x => x.Amount <= request.Filter.MaxAmount);
        }
        if (filterText is not null)
        {
            q = q.Where(x => x.Description != null && x.Description.ToLower().Contains(filterText));
        }
        if (request.Filter.CategoryName is not null)
        {
            q = q.Where(x => x.Category != null && x.Category.Name == request.Filter.CategoryName);
        }

        var expenses = await q.ToListAsync(cancellationToken);
        var expenseDtos = new List<ExpenseDto>();

        foreach (var expense in expenses)
        {
            expenseDtos.Add(ExpenseMappingExtension.ToDto(expense));
        }

        return expenseDtos;
    }
}
