

using Osszefoglalo.enums;

namespace Osszefoglalo.Models
{
    public class Windows : OperatingSystemMy
    {
        public override MessageToSend CreateMessage()
        {
            int SystemNumber = Convert.ToInt32(Enum.Parse<OperatingSystemsEnum>(System.ToLower()));
            MessageToSend message = new MessageToSend($"{System}*{FirstName}*{LastName}*{MobileNumber}*{Message}", SystemNumber);
            return message;
        }

        public override async Task<Response> SendMessageAsync()
        {
            Response response = await HTTPService.SendPostRequestAsync("api/send/windows", CreateMessage());
            return response;
        }
        public Windows() : base() { }
        public Windows(string system, string firstName, string lastName, string mobileNumber, string message) : base(system, firstName, lastName, mobileNumber, message) { }

    }
}

