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
        var q = _dbContext.Expenses
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
        if (request.Filter.Text is not null)
        {
            q = q.Where(x => x.Description != null && x.Description.Contains(request.Filter.Text, StringComparison.CurrentCultureIgnoreCase));
        }
        if (request.Filter.CategoryId is not null)
        {
            q = q.Where(x => x.CategoryId == request.Filter.CategoryId);
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
