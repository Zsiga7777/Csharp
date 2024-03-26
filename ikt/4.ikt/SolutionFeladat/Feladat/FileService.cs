
using System.Text;
using System.Text.Json;

public static class FileService
    {
    public static async Task<ICollection<Student>> ReadStudentsFromFileAsync(string studentData, string subjectData)
    { 
        List<Student> students = new List<Student>();
        Student student = null;
        string pathStudent = Path.Combine("data", studentData);
        string pathSubject = Path.Combine("data", subjectData);

        using FileStream fsStu = new FileStream(pathStudent, FileMode.Open, FileAccess.Read, FileShare.None, 128);
        using FileStream fsSub = new FileStream(subjectData, FileMode.Open, FileAccess.Read, FileShare.None, 128);

        using StreamReader srStu = new StreamReader(fsStu, Encoding.UTF8);
        using StreamReader srSub = new StreamReader(fsSub, Encoding.UTF8);

        while (!srStu.EndOfStream)
        { 
            student = new Student();
            student.Name = await JsonSerializer.Deserialize(srStu.ReadLineAsync());
        }

        return students;
    }
    }

