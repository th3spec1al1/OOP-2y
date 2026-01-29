using Lab5.Application.Contracts.Models;
using Lab5.Application.Contracts.Transactions;
using Microsoft.AspNetCore.Mvc;
using GetHistoryOp = Lab5.Application.Contracts.Transactions.Operations.GetHistory;

namespace Lab5.Presentation.Http.Controllers;

[ApiController]
[Route("api/transactions")]
public sealed class TransactionController : ControllerBase
{
    private readonly ITransactionService _transactionService;

    public TransactionController(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    [HttpGet]
    public ActionResult<IReadOnlyCollection<TransactionDto>> GetHistory(
        [FromQuery] Guid sessionId)
    {
        var request = new GetHistoryOp.Request(sessionId);

        GetHistoryOp.Response response = _transactionService.GetHistory(request);

        return response switch
        {
            GetHistoryOp.Response.Success s => Ok(s.Transactions),
            GetHistoryOp.Response.InvalidSession => Unauthorized(),
            _ => BadRequest(),
        };
    }
}