using ExpenseTrackerApi.Application.Categories.Dtos;
using ExpenseTrackerApi.Domain.Entities;

namespace ExpenseTrackerApi.Application.Common.Mappings;

public static class CategoryMappingExtensions
{
    public static CategoryDto ToDto(this Category entity)
        => new(entity.Id, entity.Name);

    public static Category ToEntity(this CategoryDto dto)
        => new() { Id = dto.Id, Name = dto.Name };
}
