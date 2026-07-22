using ExpenseTrackerApi.Application.Budgets.Dtos;
using ExpenseTrackerApi.Application.Statistics.Dtos;
using ExpenseTrackerApi.Application.Statistics.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackerApi.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StatisticsController : ControllerBase
{
    private readonly IMediator _mediator;

    public StatisticsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize]
    [HttpGet(nameof(GetMonthlyStatistics))]
    public async Task<MonthlyStatisticsDto> GetMonthlyStatistics([FromQuery] BudgetDto dto)
    {
        var result = await _mediator.Send(new MonthlyStatisticsQuery(dto));

        return result;
    }
}
