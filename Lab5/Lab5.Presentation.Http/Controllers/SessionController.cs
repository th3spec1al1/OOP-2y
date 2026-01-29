using Lab5.Application.Contracts.Sessions;
using Lab5.Presentation.Http.Models;
using Microsoft.AspNetCore.Mvc;
using CreateAdminSessionOp = Lab5.Application.Contracts.Sessions.Operations.CreateAdminSession;
using CreateUserSessionOp = Lab5.Application.Contracts.Sessions.Operations.CreateUserSession;

namespace Lab5.Presentation.Http.Controllers;

[ApiController]
[Route("api/session")]
public sealed class SessionController : ControllerBase
{
    private readonly ISessionService _sessionService;

    public SessionController(ISessionService sessionService)
    {
        _sessionService = sessionService;
    }

    [HttpPost("user")]
    public ActionResult<Guid> CreateUserSession(
        [FromBody] CreateUserSessionRequest httpRequest)
    {
        var request = new CreateUserSessionOp.Request(
            httpRequest.AccountNumber,
            httpRequest.PinCode);

        CreateUserSessionOp.Response response = _sessionService.CreateUserSession(request);

        return response switch
        {
            CreateUserSessionOp.Response.Success s => Ok(s.SessionId),
            CreateUserSessionOp.Response.InvalidCredentials => Unauthorized(),
            _ => BadRequest(),
        };
    }

    [HttpPost("admin")]
    public ActionResult<Guid> CreateAdminSession(
        [FromBody] CreateAdminSessionRequest httpRequest)
    {
        var request = new CreateAdminSessionOp.Request(
            httpRequest.SystemPassword);

        CreateAdminSessionOp.Response response = _sessionService.CreateAdminSession(request);

        return response switch
        {
            CreateAdminSessionOp.Response.Success s => Ok(s.SessionId),
            CreateAdminSessionOp.Response.InvalidPassword => Unauthorized(),
            _ => BadRequest(),
        };
    }
}