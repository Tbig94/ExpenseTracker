using MediatR;

namespace ExpenseTrackerApi.Application.Categories.Commands.CreateCategory;

public record CreateCategoryCommand(string Name) : IRequest<int>;
