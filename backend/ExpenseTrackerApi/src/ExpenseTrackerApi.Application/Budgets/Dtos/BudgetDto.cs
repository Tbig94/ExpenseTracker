using ExpenseTrackerApi.Domain.Enums;

namespace ExpenseTrackerApi.Application.Budgets.Dtos;

public record BudgetDto(
    Guid UserId,
    Guid CategoryId,
    decimal? LimitAmount,
    int Month,
    int Year);


public record BudgetStatusDto(
    decimal LimitAmount,
    decimal SpentAmount,
    decimal RemainingAmount,
    BudgetState State
    );