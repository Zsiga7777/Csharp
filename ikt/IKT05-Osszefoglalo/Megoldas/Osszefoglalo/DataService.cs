
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

            List<StoredMessage> storedMessages = await FileService.ReadFromJsonFileAsync<StoredMessage>(fileName, "data");

            storedMessages.Add(message);

            await FileService.WriteToJsonFileAsync(storedMessages, fileName, "data");
        }

        public static async Task DeleteMessageAsync()
        {
            List<string> fileNames = GetDatesFromFileNames("data", DateTime.Today);
            int selectedFile = Menus.ReusableMenu(fileNames);
            if (selectedFile == -1) { return; }

            string fileName = "messages_(" + fileNames[selectedFile] +")" + ".json";
            List<StoredMessage> storedMessages = await FileService.ReadFromJsonFileAsync<StoredMessage>(fileName, "data");

            int selectedMessage = Menus.ReusableMenu(storedMessages);
            if (selectedMessage == -1) { return; }

            storedMessages.Remove(storedMessages[selectedMessage]);

            if (storedMessages.Count == 0)
            {
                File.Delete(Path.Combine( Path.GetFullPath($"data").Replace($"bin\\Debug\\net8.0\\", ""), fileName) );
            }
            else
            {
                await FileService.WriteToJsonFileAsync(storedMessages, fileName , "data");
            }

        }

        public static async Task SendMessageAsync()
        { 
            DateTime today = DateTime.Now;
            string fileName = $"messages_({today.Year}-{today.Month}-{today.Day}).json";
            List<OperatingSystemMy> storedMessages = FactorialMessageCreator( await FileService.ReadFromJsonFileAsync<StoredMessage>(fileName, "data"));

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
            await FileService.WriteToTxtFileAsync(succesfulResponses, $"delivered_({today.Year}-{today.Month}-{today.Day}).txt" , "logs");
            await FileService.WriteToTxtFileAsync(unsuccesfulResponses, $"not-delivered_({today.Year}-{today.Month}-{today.Day}).txt", "logs");

        }

        public static async Task MakeReportAsnyc()
        {
            List<string> dates = GetDatesFromFileNames("logs");

            int selectedDate = Menus.ReusableMenu(dates);
            if (selectedDate == -1) { return; }

            List<Response> succesfulResponses = await FileService.ReadFromLogsTxtFileAsync($"delivered_({dates[selectedDate]}).txt", "logs");
            List<Response> unsuccesfulResponses = await FileService.ReadFromLogsTxtFileAsync($"not-delivered_({dates[selectedDate]}).txt", "logs");

            Report report = CreateReport(succesfulResponses, unsuccesfulResponses);

            await FileService.WriteToJsonFileAsync<Report>([report], $"report_({dates[selectedDate]}).json", "report");
            Console.Clear();
            Console.WriteLine(report);
            await Task.Delay(10000);
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

        public static List<string> GetDatesFromFileNames(string folder)
        {
            List<string> fileNames = ConsoleFunctions.GetFileNames(folder);
            List<string> dates = new List<string>();
            string[] temp = null;
            foreach (var filename in fileNames)
            {
                temp = filename.Split('(');
                temp = temp[1].Split(")");
                dates.Add(temp[0]);
            }
            dates = dates.Distinct().ToList();

            return dates;
        }

        public static List<string> GetDatesFromFileNames(string folder, DateTime max)
        {
            List<string> fileNames = ConsoleFunctions.GetFileNames(folder);
            List<string> dates = new List<string>();
            string[] temp = null;
            foreach (var filename in fileNames)
            {
                temp = filename.Split('(');
                temp = temp[1].Split(")");
                if (max >= DateTime.Parse(temp[0]))
                {
                    dates.Add(temp[0]);
                }
            }
            dates = dates.Distinct().ToList();

            return dates;
        }

        public static Report CreateReport(List<Response> succesfulResponses, List<Response> unsuccesfulResponses)
        {
            Report report = new Report();
            report.Success = succesfulResponses.Count;
            report.Date = succesfulResponses[0].DateTime;

            foreach (var response in unsuccesfulResponses)
            {
                if (report.Errors.Any(x => x.Reason == response.ErrorMessage))
                {
                    report.Errors.First(x => x.Reason == response.ErrorMessage).Count++;
                }
                else
                {
                    report.Errors.Add(new Error(response.ErrorMessage, 1));
                }
            }

            return report;
        }
    }
}
