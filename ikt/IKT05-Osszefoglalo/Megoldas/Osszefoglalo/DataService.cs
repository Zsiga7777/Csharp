
using Osszefoglalo.Models;

namespace Osszefoglalo
{
    public static class DataService
    {
        public static async Task CreateNewMessage()
        {
            StoredMessage message =ConsoleFunctions.GetMessageData();

            DateTime selectedDate = ConsoleFunctions.ReadDate(DateTime.Now.Date);

            string fileName = $"messages_({selectedDate.Year}-{selectedDate.Month}-{selectedDate.Day}).json";

            List<StoredMessage> storedMessages = await FileService.ReadFromFileAsync<StoredMessage>(fileName, "data");

            storedMessages.Add(message);

            await FileService.WriteToJsonFile(storedMessages, fileName, "data");
        }

        public static async Task DeleteMessage()
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
    }
}
