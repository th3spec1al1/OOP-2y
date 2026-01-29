using Lab5.Application.Abstractions.Persistence.Queries;
using Lab5.Application.Abstractions.Persistence.Repositories;
using Lab5.Domain.Sessions;

namespace Lab5.Infrastructure.Persistence.Repositories;

public class SessionRepository : ISessionRepository
{
    private readonly Dictionary<Guid, UserSession> _userSessions = [];
    private readonly Dictionary<Guid, AdminSession> _adminSessions = [];

    public void AddUser(UserSession session)
    {
        _userSessions.Add(session.Id, session);
    }

    public void AddAdmin(AdminSession session)
    {
        _adminSessions.Add(session.Id, session);
    }

    public IEnumerable<UserSession> QueryUsers(SessionQuery query)
    {
        IEnumerable<UserSession> result = _userSessions.Values;

        if (query.SessionIds.Length > 0)
        {
            result = result.Where(s => query.SessionIds.Contains(s.Id));
        }

        return result;
    }

    public IEnumerable<AdminSession> QueryAdmins(SessionQuery query)
    {
        IEnumerable<AdminSession> result = _adminSessions.Values;

        if (query.SessionIds.Length > 0)
        {
            result = result.Where(s => query.SessionIds.Contains(s.Id));
        }

        return result;
    }
}