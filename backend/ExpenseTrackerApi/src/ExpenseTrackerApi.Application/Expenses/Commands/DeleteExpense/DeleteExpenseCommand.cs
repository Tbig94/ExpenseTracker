using MediatR;

namespace ExpenseTrackerApi.Application.Expenses.Commands.DeleteExpense;

public record DeleteExpenseCommand(int Id) : IRequest
{
}
