namespace RemoteAccess.Interfaces
{
    public interface ISessionHub
{
    Task ReceiveMessage(string message);
    Task SessionEnded(string message);
    Task Error(string message);
}

}
