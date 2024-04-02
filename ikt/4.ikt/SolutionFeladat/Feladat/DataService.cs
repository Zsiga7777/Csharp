
using Custom.Library.ConsoleExtensions;

public static class DataService
{
    public static async Task<Student> AddNewStudentAsync(int newID, List<Student> students)
    {
        Student student = new Student();
        string name = ExtendentConsole.ReadString("Kérem a tanuló nevét: ");
        int counter = 0;
        while (students.Any(x => x.Name == name))
        { 
            counter++;
            name = name + $"{counter}";
        }
        student.Name = name;
        student.Class = ExtendentConsole.ReadString("Kérem a tanuló osztályát: ");
        student.Address = ExtendentConsole.ReadString("Kérem a tanuló lakcímét: ");
        student.StudentId = newID;
        return student;
    }

    public static async Task<List<Student>> ModifyStudentData(List<Student> students)
    {
        Console.WriteLine("A tanulók nevei: ");
        students.WriteCollectionToConsole();
        string studentNeedsModify = null;

        do
        {
            studentNeedsModify = ExtendentConsole.ReadString("Kérem a módosítani kívánt tanuló nevét: ");
        }
        while (students.Any(x => x.Name != studentNeedsModify));

        int indexOfStudent = students.IndexOf( students.First(x => x.Name == studentNeedsModify));

        Console.WriteLine("1:Név módosítás\n2:Osztály módosítás\n3:lakcím módosítás");
        int modificítionType = ExtendentConsole.ReadInteger(1, 3, "Kérem a módosítandó adat számát:");
        string newData = ExtendentConsole.ReadString("Kérem az új adatot: ");
        switch (modificítionType)
        {
            case 1:
                {
                    students[indexOfStudent].Name = newData; break;
                }
            case 2:
                {
                    students[indexOfStudent].Class = newData; break;
                }
            case 3:
                {
                    students[indexOfStudent].Address = newData; break;
                }
        }

        return students;
    }
    public static async Task DeleteStudentData(List<Student> students, List<SubjectFolder> subjects)
    {
        Console.WriteLine("A tanulók nevei: ");
        students.WriteCollectionToConsole();
        string studentNeedsDelete = null;

        do
        {
            studentNeedsDelete = ExtendentConsole.ReadString("Kérem a törölni kívánt tanuló nevét: ");
        }
        while (students.Any(x => x.Name != studentNeedsDelete));

        int indexOfStudent = students.IndexOf(students.First(x => x.Name == studentNeedsDelete));
        int idOfStudent = students.First(x => x.Name == studentNeedsDelete).StudentId;

        students.RemoveAt(indexOfStudent);
        subjects.RemoveAll(x => x.StudentId == idOfStudent);
        
    }



    public static async Task<SubjectFolder> AddNewSubjectFolderAsync(List<Student> students)
    {
        Console.WriteLine("A tanulók nevei: ");
        students.WriteCollectionToConsole();
        string studentNeedsToAddSubject = null;

        do
        {
            studentNeedsToAddSubject = ExtendentConsole.ReadString("Kérem a tanuló nevét, akinek új tantárgyat kell hozzáadni: ");
        }
        while (students.Any(x => x.Name != studentNeedsToAddSubject));

        SubjectFolder subject = new SubjectFolder();
        subject.StudentId = students.First(x => x.Name == studentNeedsToAddSubject).StudentId;

        Dictionary<string, ICollection<int>> subjects = new Dictionary<string, ICollection<int>>();

        bool moreSubject = false;
        bool moreMark = false;
        string input = null;
        int markInput = 0;
        do
        {
            input = ExtendentConsole.ReadString("Kérem a tantárgy nevét vagy a feladat végesztével a 'nomore' utasítást: ");
            if (input != "nomore")
            {
                if (!subjects.ContainsKey(input))
                {
                    subjects.Add(input, new List<int>());
                    moreMark = false;
                    do
                    {
                        markInput = ExtendentConsole.ReadInteger(0, 5, "Kérem a jegyet, a jegyek beírásának végét a 0 lenyomásával jelezze: ");
                        if (markInput != 0)
                        {
                            subjects[input].Add(markInput);
                        }
                        else
                        {
                            moreMark = true;
                        }

                    } while (!moreMark);
                   
                }
            }
            else
            {
                moreSubject = true;
            }
        }
        while (!moreSubject);

        subject.Subjects = subjects;

        return subject;
    }
}

