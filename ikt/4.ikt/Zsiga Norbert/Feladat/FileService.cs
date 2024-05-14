using System.Text.Json;
public static class FileService
    {
    public static async Task<List<T>> ReadFromFileAsync<T>(string fileName)
    {   
        Directory.CreateDirectory("..\\..\\..\\data");
        string folderPath = Path.GetFullPath("data").Replace($"bin\\Debug\\net8.0\\", "");
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

    public static async Task WriteToJsonFile<T>(List<T> list, string fileName)
    {
        Directory.CreateDirectory("..\\..\\..\\data");
        string folderPath = Path.GetFullPath("data").Replace($"bin\\Debug\\net8.0\\", "");
        string path = Path.Combine(folderPath, fileName);
        using FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 128);
        await JsonSerializer.SerializeAsync(fs, list);
    }
    }

