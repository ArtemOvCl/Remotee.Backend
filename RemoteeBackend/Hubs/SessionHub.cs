using Microsoft.AspNetCore.SignalR;
using RemoteAccess.Services;
using RemoteAccess.Interfaces;
using System.Threading.Tasks;

namespace RemoteAccess.Hubs
{
    public class SessionHub : Hub<ISessionHub>
    {
        private readonly SessionService _sessionService;
        private static string? _computerConnectionId;

        public SessionHub(SessionService sessionService)
        {
            _sessionService = sessionService;
        }

        public async Task<string> CreateSession()
        {

            _computerConnectionId ??= Context.ConnectionId;

            string sessionId = _sessionService.CreateSessionId();
            await Groups.AddToGroupAsync(Context.ConnectionId, sessionId);
            return sessionId; 
        }

        public async Task<bool> JoinSession(string sessionId)
        {
            if (_sessionService.IsSessionTaken(sessionId))  
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, sessionId); 
                return true;
            }

            return false;
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var sessionId = _sessionService.GetOwner(Context.ConnectionId);
            if (sessionId != null)
            {
                _sessionService.RemoveSession(sessionId); 
            }

            await base.OnDisconnectedAsync(exception);
        }

        public string GetComputerConnectionId()
        {

#pragma warning disable CS8603
            return _computerConnectionId;
#pragma warning restore CS8603
        }
    }
}
