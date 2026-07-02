using ExpenseTrackerApi.Application.Dashboard.Dtos;
using MediatR;

namespace ExpenseTrackerApi.Application.Dashboard.Queries;

public class GetComplexStatisticsQuery : IRequest<DashboardDto>
{
}
