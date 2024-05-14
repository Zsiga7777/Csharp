using Custom.Library.ConsoleExtensions;
using Osszefoglalo.Models;


namespace Osszefoglalo
{
    public class ConsoleFunctions
    {
        public static void WriteMenu<T>(List<T> options, int selected)
        {
            Console.Clear();
            for (int i = 0; i < options.Count; i++)
            {
                if (i == selected)
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine(options[i]);
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"{options[i]}");
                }
            }
        }
        public static DateTime ReadDate(DateTime minDateTime)
        {
            bool isgood = false;
            string input = null;
            DateTime result;
            do
            {
                Console.Write($"Kérek egy dátumot {minDateTime} után (éééé-hh-nn): ");
                input = Console.ReadLine();
                isgood = DateTime.TryParse(input, out result);
            }
            while (!isgood || result < minDateTime);
            return result;
        }

        public static DateTime ReadDate(DateTime maxDateTime, string prompt)
        {
            bool isgood = false;
            string input = null;
            DateTime result;
            do
            {
                Console.Write($"{prompt} {maxDateTime} előtt (éééé-hh-nn): ");
                input = Console.ReadLine();
                isgood = DateTime.TryParse(input, out result);
            }
            while (!isgood || result > maxDateTime);
            return result;
        }

        public static StoredMessage GetMessageData()
        {   StoredMessage message = new StoredMessage();
            int systemId = Menus.ReusableMenu(["IOS", "Android", "Windows"]);

            switch (systemId)
            {
                case -1:
                    return null;
                case 0:
                    message.System = "ios";
                    break;
                case 1:
                    message.System = "android";
                    break;
                case 2:
                    message.System = "windows";
                    break;
            }

            message.FirstName = ExtendentConsole.ReadString("Kérem a keresztnevét: ");
            message.LastName = ExtendentConsole.ReadString("Kérem a családnevét: ");
            message.Message = ExtendentConsole.ReadString("Kérem az üzenetet: ");

            string phoneNumber = null;
            string phoneNumberCopy = null;
            long temp = 0;
            bool isNumber = false;
            string[] partsOfNumbers = null;
            bool isGoodPattern = false;
            do
            {
            phoneNumber = ExtendentConsole.ReadString("Kérem a telefonszámot ***-***-**** formában: ").Trim();
                phoneNumberCopy = phoneNumber.Replace("-", "");
                isNumber = long.TryParse(phoneNumberCopy, out  temp) ;
                phoneNumberCopy = phoneNumber;
                partsOfNumbers = phoneNumberCopy.Split('-');

                if (partsOfNumbers.Length>=3 && partsOfNumbers[0].Length == 3 && partsOfNumbers[1].Length == 3 && partsOfNumbers[2].Length == 4)
                { 
                    isGoodPattern = true;
                }
            }
            while (!isNumber || temp.ToString().Length != 10 || !isGoodPattern);
            
            message.MobileNumber = phoneNumber;

            return message;
        }

        public static List<string> GetFileNames(string folderName)
        {
            string folderPath = Path.GetFullPath("data").Replace($"bin\\Debug\\net8.0\\", "");
            List<string> nameOfFiles = Directory.GetFileSystemEntries(folderPath).ToList();
            string[] temp = null;

            for (int i = 0; i < nameOfFiles.Count;i++)
            {
                temp = nameOfFiles[i].Split("\\");
                nameOfFiles[i] = temp[temp.Length - 1].Split(".")[0];
            }

            return nameOfFiles;
        }


    }

    
}
