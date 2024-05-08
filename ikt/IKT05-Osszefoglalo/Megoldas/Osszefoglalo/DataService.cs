
using Osszefoglalo.Models;

namespace Osszefoglalo
{
    public static class DataService
    {
        public static async Task CreateNewMessage()
        {
            StoredMessage message =ConsoleFunctions.GetMessageData();

            DateTime selectedDate = ConsoleFunctions.ReadDate(DateTime.Now.Date);

            string fileName = $"messages_({selectedDate.Year}.{selectedDate.Month}.{selectedDate.Day}).json";

            List<StoredMessage> storedMessages = await FileService.ReadFromFileAsync<StoredMessage>(fileName, "data");

            storedMessages.Add(message);

            await FileService.WriteToJsonFile(storedMessages, fileName, "data");
        }
    }
}
