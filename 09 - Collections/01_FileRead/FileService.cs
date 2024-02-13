public static class FileService
{
    public static async Task<List<Student>> ReadFromFileAsync(string fileName)
    { 
        List<Student> students = new List<Student>();
        Student student = null;
        string line = string.Empty;
        string[] data = null;

        string path = Path.Combine("source", fileName);

        using FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None);
        using StreamReader sr = new StreamReader(fs, Encoding.UTF7);

        while (!sr.EndOfStream)
        { 
           line = await sr.ReadLineAsync();
           data = line.Split('\t');

            student = new Student();
            student.Name = data[0];
            student.Average = double.Parse(data[1]);

            students.Add(student);
        }
        return students;
    }

    public static async Task<List<Student>> ReadFromFileAsyncMethod2(string fileName)
    {
        List<Student> students = new List<Student>();
        Student student = null;
        string path = Path.Combine("source", fileName);

        string temp = File.ReadAllText(path,Encoding.UTF8);

        string[] splitted = temp.Split('\n');
        string[] data = null;
        
        foreach (string line in splitted)
        {
            data = line.Split("\t");
            data[1] = data[1].Replace('\t', ' ').TrimEnd();

            student = new Student();
            student.Name = data[0] ;
            student.Average = double.Parse(data[1]);
            students.Add(student);
        }
        
        return students;
    }

    public static async Task<List<Student>> ReadFromFileAsyncMethod3(string fileName)
    {
        List<Student> students = new List<Student>();
        Student student = null;
        string path = Path.Combine("source", fileName);

        string[] temp = File.ReadAllLines(path, Encoding.UTF8);

        string[] data = null;

        foreach (string line in temp)
        {
            data = line.Split("\t");

            student = new Student();
            student.Name = data[0];
            student.Average = double.Parse(data[1]);
            students.Add(student);
        }

        return students;
    }

}

