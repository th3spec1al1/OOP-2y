using Lab5.Application.Contracts.Accounts;
using Lab5.Presentation.Http.Models;
using Microsoft.AspNetCore.Mvc;
using CreateAccountOp = Lab5.Application.Contracts.Accounts.Operations.CreateAccount;
using DepositOp = Lab5.Application.Contracts.Accounts.Operations.Deposit;
using WithdrawOp = Lab5.Application.Contracts.Accounts.Operations.Withdraw;

namespace Lab5.Presentation.Http.Controllers;

[ApiController]
[Route("api/account")]
public sealed class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost]
    public ActionResult<Guid> Create(
        [FromBody] CreateAccountRequest httpRequest)
    {
        var request = new CreateAccountOp.Request(
            httpRequest.AccountNumber,
            httpRequest.PinCode);

        CreateAccountOp.Response response = _accountService.Create(request);

        return response switch
        {
            CreateAccountOp.Response.Success s => Ok(s.AccountId),
            CreateAccountOp.Response.AccountAlreadyExists => Conflict(),
            _ => BadRequest(),
        };
    }

    [HttpPost("deposit")]
    public ActionResult<decimal> Deposit(
        [FromBody] DepositRequest httpRequest)
    {
        var request = new DepositOp.Request(
            httpRequest.SessionId,
            httpRequest.Amount);

        DepositOp.Response response = _accountService.Deposit(request);

        return response switch
        {
            DepositOp.Response.Success s => Ok(s.NewBalance),
            DepositOp.Response.InvalidSession => Unauthorized(),
            _ => BadRequest(),
        };
    }

    [HttpPost("withdraw")]
    public ActionResult<decimal> Withdraw(
        [FromBody] WithdrawRequest httpRequest)
    {
        var request = new WithdrawOp.Request(
            httpRequest.SessionId,
            httpRequest.Amount);

        WithdrawOp.Response response = _accountService.Withdraw(request);

        return response switch
        {
            WithdrawOp.Response.Success s => Ok(s.NewBalance),
            WithdrawOp.Response.InvalidSession => Unauthorized(),
            _ => BadRequest(),
        };
    }
}
