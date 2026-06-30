using ExpenseTrackerApi.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerApi.Application.Expenses.Commands.DeleteExpense;

public class DeleteExpenseCommandHandler : IRequestHandler<DeleteExpenseCommand>
{
    private readonly IAppDbContext _dbContext;

    public DeleteExpenseCommandHandler(IAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(DeleteExpenseCommand request, CancellationToken cancellationToken)
    {
        var expense = await _dbContext.Expenses.FirstOrDefaultAsync(x => x.Id == request.Id);

        if (expense is not null)
        {
            _dbContext.Expenses.Attach(expense);
            _dbContext.Expenses.Remove(expense);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
