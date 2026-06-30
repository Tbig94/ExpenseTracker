using ExpenseTrackerApi.Application.Common.Interfaces;
using ExpenseTrackerApi.Domain.Entities;
using MediatR;

namespace ExpenseTrackerApi.Application.Expenses.Commands.CreateExpense;

public class CreateExpenseCommandHandler : IRequestHandler<CreateExpenseCommand>
{
    private readonly IAppDbContext _dbContext;

    public CreateExpenseCommandHandler(IAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
    {
        var expense = new Expense()
        {
            CategoryId = request.Expense.CategoryId.Value,
            Date = request.Expense.Date.Value,
            Description = request.Expense.Description,
        };

        await _dbContext.Expenses.AddAsync(expense, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
