using ExpenseTrackerApi.Application.Auth.Commands;
using ExpenseTrackerApi.Application.Auth.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackerApi.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [AllowAnonymous]
    [HttpPost(nameof(Register))]
    public async Task<IActionResult> Register(RegisterDto user)
    {
        await _mediator.Send(new RegisterCommand(user));

        return NoContent();
    }

    [AllowAnonymous]
    [HttpPost(nameof(Login))]
    public async Task<IActionResult> Login(LoginDto user)
    {
        var result = await _mediator.Send(new LoginCommand(user));

        return Ok(result);
    }
}
