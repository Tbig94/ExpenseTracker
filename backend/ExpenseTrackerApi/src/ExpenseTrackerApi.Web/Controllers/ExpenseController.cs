using ExpenseTrackerApi.Application.Expenses.Commands.CreateExpense;
using ExpenseTrackerApi.Application.Expenses.Commands.DeleteExpense;
using ExpenseTrackerApi.Application.Expenses.Dtos;
using ExpenseTrackerApi.Application.Expenses.Queries.GetAllExpenses;
using ExpenseTrackerApi.Application.Expenses.Queries.GetExpensesByFilter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackerApi.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpenseController : ControllerBase
{
    private readonly IMediator _mediator;

    public ExpenseController(IMediator mediator) => _mediator = mediator;

    [HttpGet(nameof(GetByFilter))]
    public async Task<IActionResult> GetByFilter(GetExpensesFilterDto dto)
        => Ok(await _mediator.Send(new GetExpensesByFilterQuery(dto)));

    [HttpGet(nameof(GetAll))]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllExpensesQuery()));

    [HttpPost(nameof(Create))]
    public async Task<IActionResult> Create(ExpenseDto dto)
    {
        await _mediator.Send(new CreateExpenseCommand(dto));

        return NoContent();
    }

    [HttpDelete(nameof(Delete))]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteExpenseCommand(id));

        return NoContent();
    }

}
