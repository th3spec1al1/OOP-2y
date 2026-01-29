using Lab5.Application.Abstractions.Persistence.Queries;
using Lab5.Domain.Sessions;

namespace Lab5.Application.Abstractions.Persistence.Repositories;

public interface ISessionRepository
{
    void AddUser(UserSession session);

    void AddAdmin(AdminSession session);

    IEnumerable<UserSession> QueryUsers(SessionQuery query);

    IEnumerable<AdminSession> QueryAdmins(SessionQuery query);
}