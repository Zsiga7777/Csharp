

namespace Osszefoglalo.Models
{
    public abstract class OperatingSystemMy : IOperatingSystem
    {
        public string System { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string MobileNumber { get; private set; }
        public string Message { get; private set; }

        public Response Response { get; private set; }

        public abstract MessageToSend CreateMessage();
        public abstract Task<Response> SendMessage();

        public OperatingSystemMy()
        {
        }

        public OperatingSystemMy(string system, string firstName, string lastName, string mobileNumber, string message)
        {
            System = system;
            FirstName = firstName;
            LastName = lastName;
            MobileNumber = mobileNumber;
            Message = message;
        }
    }
}
