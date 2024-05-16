
using Osszefoglalo.Models;

namespace Osszefoglalo
{
    public static class DataService
    {
        public static async Task CreateNewMessageAsync()
        {
            StoredMessage message =ConsoleFunctions.GetMessageData();

            DateTime selectedDate = ConsoleFunctions.ReadDate(DateTime.Now.Date);

            string fileName = $"messages_({selectedDate.Year}-{selectedDate.Month}-{selectedDate.Day}).json";

            List<StoredMessage> storedMessages = await FileService.ReadFromFileAsync<StoredMessage>(fileName, "data");

            storedMessages.Add(message);

            await FileService.WriteToJsonFile(storedMessages, fileName, "data");
        }

        public static async Task DeleteMessageAsync()
        {
            List<string> fileNames = ConsoleFunctions.GetFileNames("data");
            int selectedFile = Menus.ReusableMenu(fileNames);
            if (selectedFile == -1) { return; }

            string fileName = fileNames[selectedFile] + ".json";
            List<StoredMessage> storedMessages = await FileService.ReadFromFileAsync<StoredMessage>(fileName, "data");

            int selectedMessage = Menus.ReusableMenu(storedMessages);
            if (selectedMessage == -1) { return; }

            storedMessages.Remove(storedMessages[selectedMessage]);

            if (storedMessages.Count == 0)
            {
                File.Delete(Path.Combine( Path.GetFullPath($"data").Replace($"bin\\Debug\\net8.0\\", ""), fileName) );
            }
            else
            {
                await FileService.WriteToJsonFile(storedMessages, fileName , "data");
            }

        }

        public static async Task SendMessageAsync()
        { 
            DateTime today = DateTime.Now;
            string fileName = $"messages_({today.Year}-{today.Month}-{today.Day}).json";
            List<OperatingSystemMy> storedMessages = FactorialMessageCreator( await FileService.ReadFromFileAsync<StoredMessage>(fileName, "data"));

            if (storedMessages.Count == 0) 
            {
                Console.WriteLine("A mai napra nincsenek üzenetek!");
                await Task.Delay(1000);
                return;
            }

            List<Response> responses = new List<Response>();
            Response response = new Response();

            foreach (var message in  storedMessages)
            {
                response =await message.SendMessageAsync();
                responses.Add(response);
            }

            List<Response> succesfulResponses = new List<Response>();
            List<Response> unsuccesfulResponses = new List<Response>();

            foreach (var respons in responses)
            {
                if (respons.IsSucces)
                {
                    succesfulResponses.Add(respons);
                }
                else
                {
                    unsuccesfulResponses.Add(respons);
                }
            }
            await FileService.WriteToTxtFile(succesfulResponses, $"delivered_({today.Year}-{today.Month}-{today.Day}).txt" , "logs");
            await FileService.WriteToTxtFile(unsuccesfulResponses, $"not-delivered_({today.Year}-{today.Month}-{today.Day}).txt", "logs");

        }

        public static List<OperatingSystemMy> FactorialMessageCreator(List<StoredMessage> data)
        {
            List<OperatingSystemMy> result = new List<OperatingSystemMy>();
            OperatingSystemMy temp = null;
            foreach (var message in data)
            {
                switch (message.System)
                {
                    case "ios":
                        temp = new IOS(message.System, message.FirstName, message.LastName, message.MobileNumber, message.Message);
                        break;
                    case "andriod":
                        temp = new Android(message.System, message.FirstName, message.LastName, message.MobileNumber, message.Message);

                        break;
                    case "windows":
                        temp = new Windows(message.System, message.FirstName, message.LastName, message.MobileNumber, message.Message);
                        break;
                }
                result.Add(temp);
            }

            return result;
        }
    }
}
