public interface ISessionService
{
    string CreateSession(string deviceType);
    bool ValidateSession(string sessionId, string deviceType);
    string GetSessionByDevice(string deviceId);
}