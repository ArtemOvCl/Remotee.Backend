namespace RemoteAccess.Interfaces
{
    public interface ISessionHub
    {
        Task<string> CreateSession();
        Task<bool> JoinSession(string sessionId);
        public string GetComputerConnectionId();
    }
}
