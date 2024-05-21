
using Osszefoglalo.Models;
using System.Text;
using System.Text.Json;

namespace Osszefoglalo
{
    public static class FileService
    {
        public static async Task<List<T>> ReadFromJsonFileAsync<T>(string fileName, string folderName)
        {
            Directory.CreateDirectory($"..\\..\\..\\{folderName}");
            string folderPath = Path.GetFullPath($"{folderName}").Replace($"bin\\Debug\\net8.0\\", "");
            string path = Path.Combine(folderPath, fileName);
            List<T>? result = new List<T>();

            using FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read, FileShare.None, 128);
            if (fs.Length > 0)
            {
                result = await JsonSerializer.DeserializeAsync<List<T>>(fs);
            }
            else
            {
                result = new List<T>();
            }
            return result;
        }

        public static async Task WriteToJsonFileAsync<T>(List<T> list, string fileName, string folderName)
        {
            Directory.CreateDirectory($"..\\..\\..\\{folderName}");
            string folderPath = Path.GetFullPath($"{folderName}").Replace($"bin\\Debug\\net8.0\\", "");
            string path = Path.Combine(folderPath, fileName);
            using FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 128);
            await JsonSerializer.SerializeAsync(fs, list);
        }

        public static async Task WriteToTxtFileAsync<T>(List<T> list, string fileName, string folderName)
        {
            Directory.CreateDirectory($"..\\..\\..\\{folderName}");
            string folderPath = Path.GetFullPath($"{folderName}").Replace($"bin\\Debug\\net8.0\\", "");
            string path = Path.Combine(folderPath, fileName);

            using FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 128);
            using StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
            foreach (var item in list)
            {
                await sw.WriteLineAsync($"{item}");
            }
        }

        public static async Task<List<Response>> ReadFromLogsTxtFileAsync(string fileName, string folderName)
        {
            Directory.CreateDirectory($"..\\..\\..\\{folderName}");
            string folderPath = Path.GetFullPath($"{folderName}").Replace($"bin\\Debug\\net8.0\\", "");
            string path = Path.Combine(folderPath, fileName);

            List<Response>? result = new List<Response>();
            string[] temp;
            string line;
            Response response = null;

            using FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read, FileShare.None, 128);
            using StreamReader sr = new StreamReader(fs, Encoding.UTF8);

            while (!sr.EndOfStream)
            { 
                line =await sr.ReadLineAsync();
                temp = line.Split(";");

                response = new Response();
                response.IsSucces =bool.Parse( temp[0]);
                response.ErrorMessage = temp[1];
                response.DateTime = DateTime.Parse(temp[2]);

                result.Add(response);
            }

            return result;
        }

    }


}

