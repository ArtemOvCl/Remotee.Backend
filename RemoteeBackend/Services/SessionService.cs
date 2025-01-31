using System;
using System.Collections.Concurrent;

namespace RemoteAccess.Services
{
    public class SessionService
    {
        private readonly ConcurrentDictionary<string, string> _activeSessions = new();

        public string CreateSessionId()
        {
            string sessionId = Guid.NewGuid().ToString();
            _activeSessions.TryAdd(sessionId, string.Empty);
            return sessionId;
        }

        public bool TrySetOwner(string sessionId, string connectionId)
        {
            return _activeSessions.TryAdd(sessionId, connectionId);
        }

        public bool IsSessionTaken(string sessionId)
        {
            return _activeSessions.ContainsKey(sessionId);
        }

        public string? GetOwner(string sessionId)
        {
            _activeSessions.TryGetValue(sessionId, out var owner);
            return owner;
        }

        public void RemoveSession(string sessionId)
        {
            _activeSessions.TryRemove(sessionId, out _);
        }
    }
}
