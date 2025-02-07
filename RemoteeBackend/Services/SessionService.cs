using System;
using System.Collections.Concurrent;

namespace RemoteAccess.Services
{
    public class SessionService
{
    private static readonly ConcurrentDictionary<string, int> _sessionConnections = new ConcurrentDictionary<string, int>();

    public string CreateSession()
    {
    string sessionId = Guid.NewGuid().ToString();

    _sessionConnections[sessionId] = 1;

    return sessionId;
    }   

    public void AddConnectionToSession(string sessionId)
    {

        _sessionConnections.AddOrUpdate(sessionId, 1, (key, oldValue) => oldValue + 1);
    }

    public void RemoveSession(string sessionId)
    {

        if (_sessionConnections.ContainsKey(sessionId) && _sessionConnections[sessionId] <= 0)
        {
            _sessionConnections.TryRemove(sessionId, out _);
        }
    }

    public bool IsSessionExists(string sessionId)
    {

    return _sessionConnections.ContainsKey(sessionId);
    }


    public int GetGroupConnectionCount(string sessionId)
    {
        return _sessionConnections.ContainsKey(sessionId) ? _sessionConnections[sessionId] : 0;
    }
}


}

