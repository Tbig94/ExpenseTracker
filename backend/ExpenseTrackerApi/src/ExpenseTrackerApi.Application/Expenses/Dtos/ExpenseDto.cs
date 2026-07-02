namespace ExpenseTrackerApi.Application.Expenses.Dtos;

public record ExpenseDto
{
    public Guid? Id { get; init; }

    public Guid? CategoryId { get; init; }

    public Guid? UserId { get; init; }

    public DateTime? Date { get; init; }

    public decimal Amount { get; init; }

    public string? Description { get; init; }


};

