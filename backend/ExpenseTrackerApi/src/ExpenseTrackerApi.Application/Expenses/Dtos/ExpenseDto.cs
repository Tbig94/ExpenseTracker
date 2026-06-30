namespace ExpenseTrackerApi.Application.Expenses.Dtos;

public record ExpenseDto
{
    public int? Id { get; init; }

    public int? CategoryId { get; init; }

    public DateTime? Date { get; init; }

    public string? Description { get; init; }
};

