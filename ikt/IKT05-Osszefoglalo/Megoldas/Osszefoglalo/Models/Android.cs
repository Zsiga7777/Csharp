
namespace Osszefoglalo.Models
{
    public class Android : OperatingSystemMy
    {
            public override MessageToSend CreateMessage()
            {
            int SystemNumber = Convert.ToInt32(Enum.Parse<OperatingSystemsEnum>(System.ToLower()));
            MessageToSend message = new MessageToSend($"{System}#{FirstName}#{LastName}#{MobileNumber}#{Message}", SystemNumber);
                return message;
            }

            public override async Task<Response> SendMessage()
            {
                Response response = await HTTPService.SendPostRequestAsync("api/send/android", CreateMessage());
                return response;
            }
            public Android() : base() { }
            public Android(string system, string firstName, string lastName, string mobileNumber, string message) : base(system, firstName, lastName, mobileNumber, message) { }

        }
}
