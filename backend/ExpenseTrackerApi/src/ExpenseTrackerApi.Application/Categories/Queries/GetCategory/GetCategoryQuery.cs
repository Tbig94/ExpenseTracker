using ExpenseTrackerApi.Application.Categories.Dtos;
using MediatR;

namespace ExpenseTrackerApi.Application.Categories.Queries.GetCategory;

public record GetCategoryQuery(int Id) : IRequest<CategoryDto?>;
