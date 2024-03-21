public static class FileService
    {
    public static async Task<List<Employee>> ReadEmployeesAsync(string fileName)
    { 
        List<Employee> employees = new List<Employee>();

        string path = Path.Combine("Source", fileName);

        Employee employee = null;

        using FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None, 128);
        using StreamReader sr = new StreamReader(fs, Encoding.UTF8);

        while (!sr.EndOfStream)
        { 
            employee = new Employee();
            employee.Name = await sr.ReadLineAsync();
            employee.Project = await sr.ReadLineAsync();
            employee.WeeklyWorkedHours = (await sr.ReadLineAsync()).Split(",").Select(x => int.Parse(x)).ToList();

            employees.Add(employee);

            await sr.ReadLineAsync();
        }

        return employees;
    }

    public static async Task WriteWeeklySalaryAsync(string fileName, List<Employee> employees)
    {
        Directory.CreateDirectory("output");
        string path = Path.Combine("output", fileName);

        using FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 128);
        using StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);

        foreach( Employee employee in employees)
        {
            await sw.WriteLineAsync($"{employee.Name}\t{employee.Payment}HUF");
        }
    }
    }

