using MediatR;

namespace ExpenseTrackerApi.Application.Categories.Commands.DeleteCategory;

public record DeleteCategoryCommand(int Id) : IRequest;
