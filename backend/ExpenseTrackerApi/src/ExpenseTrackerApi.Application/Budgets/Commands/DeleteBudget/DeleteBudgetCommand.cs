using MediatR;

namespace ExpenseTrackerApi.Application.Budgets.Commands.DeleteBudget;

public record DeleteBudgetCommand(Guid UserId, Guid CategoryId) : IRequest;
