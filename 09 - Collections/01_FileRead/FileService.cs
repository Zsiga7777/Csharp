public static class FileService
{
    #region File Read
    public static async Task<List<Student>> ReadFromFileAsyncMethod1(string fileName)
    { 
        List<Student> students = new List<Student>();
        Student student = null;
        string line = string.Empty;
        string[] data = null;

        string path = Path.Combine("source", fileName);

        using FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None, 128);
        using StreamReader sr = new StreamReader(fs, Encoding.UTF7);

        await sr.ReadLineAsync(); // kiolvassa a fejlécet, csak épp nem csinálunk vele semmit sem

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

        string temp =await File.ReadAllTextAsync(path,Encoding.UTF7);

        string[] splitted = temp.Split('\n');
        string[] data = null;
        
        foreach (string line in splitted.Skip(1))
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

        string[] temp = await File.ReadAllLinesAsync(path, Encoding.UTF7);

        string[] data = null;

        foreach (string line in temp.Skip(1)) //.Skip(1) ugord át az első sort(fejléc)
        {
            data = line.Split("\t");

            student = new Student();
            student.Name = data[0];
            student.Average = double.Parse(data[1]);
            students.Add(student);
        }

        return students;
    }

    public static async Task<List<Student>> ReadFromFileAsyncMethod4(string fileName)
    {
        List<Student> students = new List<Student>();
        Student student = null;
        string path = Path.Combine("source", fileName);
        bool isNumber = false;

        IAsyncEnumerable<string> temp =  File.ReadLinesAsync(path, Encoding.UTF7);

        string[] data = null;

        await foreach (string line in temp)
        {
            data = line.Split("\t");

            

            isNumber = double.TryParse(data[1], out double avarage);

            if (!isNumber)
            {
                continue;
             }

            student = new Student();
            student.Name = data[0];
            student.Average = avarage;

            students.Add(student);
            
        }

        return students;
    }

    #endregion

    #region File Write
    public static async Task WriteToFileV1Async(string fileName, ICollection<Student> students)
    {
        Directory.CreateDirectory("output");
        string path = Path.Combine("output", $"{fileName}.txt");

        using FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 128);
        using StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);

        foreach (Student student in students)
        {
            await sw.WriteLineAsync($"{student.Name}\t{student.Average}");
        }
    }

    public static async Task WriteToFileV2Async(string fileName, ICollection<Student> students)
    {
        Directory.CreateDirectory("output");
        string path = Path.Combine("output", $"{fileName}.txt");
        List<string> data = new List<string>();

        foreach (Student student in students)
        {
            data.Add($"{student.Name}\t{student.Average}");
        }

       await File.WriteAllLinesAsync(path, data, Encoding.UTF8);
    }

    public static async Task WriteToFileV3Async(string fileName, ICollection<Student> students)
    {
        Directory.CreateDirectory("output");
        string path = Path.Combine("output", $"{fileName}.txt");
      
        StringBuilder contents = new StringBuilder();

        foreach (Student student in students)
        {
            contents.AppendLine($"{student.Name}\t{student.Average}");
        }

        await File.WriteAllTextAsync(path, contents.ToString(), Encoding.UTF8);
    }
    #endregion

  
}

