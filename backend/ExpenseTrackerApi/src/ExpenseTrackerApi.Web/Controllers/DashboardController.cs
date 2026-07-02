using ExpenseTrackerApi.Application.Dashboard.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackerApi.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DashboardController : ControllerBase
{
    private readonly IMediator _mediator;

    public DashboardController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(nameof(GetDashboardData))]
    public async Task<IActionResult> GetDashboardData()
        => Ok(await _mediator.Send(new GetComplexStatisticsQuery()));
}
