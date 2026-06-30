using ExpenseTrackerApi.Application.Expenses.Dtos;
using ExpenseTrackerApi.Domain.Entities;

namespace ExpenseTrackerApi.Application.Common.Mappings;

public static class ExpenseMappingExtension
{
    public static ExpenseDto ToDto(this Expense entity)
    {
        var categoryDto = CategoryMappingExtensions.ToDto(entity.Category);
        var dto = new ExpenseDto
        {
            Id = entity.Id,
            Date = entity.Date,
            CategoryId = entity.CategoryId,
            Description = entity.Description,
        };
        return dto;
    }

    public static Expense ToEntity(this ExpenseDto dto)
    {
        var entity = new Expense() { CategoryId = dto.CategoryId!.Value, Date = dto.Date!.Value, Description = dto.Description };
        return entity;
    }
}
