using Microsoft.AspNetCore.SignalR;
using RemoteAccess.Services;
using RemoteAccess.Interfaces;
using System.Threading.Tasks;

namespace RemoteAccess.Hubs
{
    public class SessionHub : Hub
    {
        private readonly SessionService _sessionService;
        private const int MaxConnectionsPerSession = 2;

        public SessionHub(SessionService sessionService)
        {
            _sessionService = sessionService;
        }

        public async Task<string> CreateSession()
        {
            string sessionId = _sessionService.CreateSession();
            await Groups.AddToGroupAsync(Context.ConnectionId, sessionId);
            return sessionId;
        }

        public async Task JoinSession(string sessionId)
        {
            if (!_sessionService.IsSessionExists(sessionId))
            {

                await Clients.Caller.SendAsync("Error", "Session is not found");
                return;
            }

            var groupConnectionsCount = _sessionService.GetGroupConnectionCount(sessionId);
            if (groupConnectionsCount >= MaxConnectionsPerSession)
            {
                
                await Clients.Caller.SendAsync("Error", "Session is not found");
                return;
            }

            await Groups.AddToGroupAsync(Context.ConnectionId, sessionId);
            await Clients.Group(sessionId).SendAsync("ReceiveMessage", $"Користувач приєднався до сесії {sessionId}");
        }

        public async Task RemoveSession(string sessionId)
        {
            if (_sessionService.IsSessionExists(sessionId))
            {
                _sessionService.RemoveSession(sessionId);
                await Clients.Group(sessionId).SendAsync("SessionEnded", $"Сесія {sessionId} завершена");
            }
        }

    }
}
