public static class FileService
    {
    public static async Task<List<Student>> GetStudentsAsync(string fileName)
    { 
        List<Student> students = new List<Student>();
        Student student = null;
        string line = null;
        string[] data = null;

        string path = Path.Combine("source", fileName);

        using FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None, 128);
        using StreamReader sr = new StreamReader(fs, Encoding.UTF7);

        await sr.ReadLineAsync();

        while (!sr.EndOfStream) {
        student = new Student();

            line = await sr.ReadLineAsync();
            data = line.Split(";");
            student.Name = data[0];
            student.Class = data[1];
            student.StartingDay =int.Parse( data[2]);
            student.EndingDay = int.Parse(data[3]);
            student.MissedHours = int.Parse(data[4]);
            students.Add(student);
        }

        return students;
    }

    public static async Task WriteToFileAsync(List<Class> classes, string filename)
    {
        Directory.CreateDirectory("output");
        string path = Path.Combine("output", $"{filename}.csv");

        using FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 128);
        using StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);

        foreach (Class @class in classes)
        {
            await sw.WriteLineAsync($"{@class}");
        }
    }
    }

