

namespace Osszefoglalo.Models
{
    public class IOS : OperatingSystemMy
    {

        public override MessageToSend CreateMessage()
        {
            int SystemNumber = Convert.ToInt32(Enum.Parse<OperatingSystemsEnum>(System.ToLower()));
            MessageToSend message = new MessageToSend($"{System}|{FirstName}|{LastName}|{MobileNumber}|{Message}", SystemNumber);
            return message;
        }

        public override async Task<Response> SendMessage()
        {
            Response response =await HTTPService.SendPostRequestAsync("api/send/ios", CreateMessage());
            return response;
        }
        public IOS() : base() { }
        public IOS(string system,string firstName,string lastName, string mobileNumber, string message) : base(system, firstName, lastName, mobileNumber, message) { }

    }
}
