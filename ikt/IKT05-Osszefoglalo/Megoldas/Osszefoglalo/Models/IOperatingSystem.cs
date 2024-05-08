namespace Osszefoglalo.Models
{
    public interface IOperatingSystem
    {
        string System {  get; }
        string FirstName { get; }
        string LastName { get; }
        string MobileNumber { get; }
        string Message { get; }

        Response Response { get; }

        public MessageToSend CreateMessage();
        public Task<Response> SendMessage();

    }
}
