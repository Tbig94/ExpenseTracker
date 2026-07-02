using ExpenseTrackerApi.Application.Budgets.Dtos;
using ExpenseTrackerApi.Application.Statistics.Dtos;
using MediatR;

namespace ExpenseTrackerApi.Application.Statistics.Queries;

public record MonthlyStatisticsQuery(BudgetDto Dto) : IRequest<MonthlyStatisticsDto>;
