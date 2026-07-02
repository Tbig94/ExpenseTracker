using ExpenseTrackerApi.Application.Budgets.Commands.CreateBudget;
using ExpenseTrackerApi.Application.Budgets.Commands.DeleteBudget;
using ExpenseTrackerApi.Application.Budgets.Dtos;
using ExpenseTrackerApi.Application.Budgets.Queries.CheckBudgetOVerflow;
using ExpenseTrackerApi.Application.Budgets.Queries.GetBudgets;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackerApi.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BudgetController : ControllerBase
{
    private readonly IMediator _mediator;

    public BudgetController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(nameof(GetAll))]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetBudgetsQuery()));


    [HttpPost(nameof(Create))]
    public async Task<IActionResult> Create(BudgetDto budget)
    {
        await _mediator.Send(new CreateBudgetCommand(budget));

        return NoContent();
    }

    [HttpDelete(nameof(Delete))]
    public async Task<IActionResult> Delete(Guid userId, Guid categoryId)
    {
        await _mediator.Send(new DeleteBudgetCommand(userId, categoryId));

        return NoContent();
    }

    [HttpGet(nameof(CheckBudgetOverflow))]
    public async Task<IActionResult> CheckBudgetOverflow(Guid userId, Guid categoryId)
        => Ok(await _mediator.Send(new CheckBudgetOverflowQuery(userId, categoryId)));
}
