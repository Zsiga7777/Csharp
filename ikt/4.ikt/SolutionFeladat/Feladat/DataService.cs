
using Custom.Library.ConsoleExtensions;

public static class DataService
{
    public static async Task<Student> GetNewStudentAsync()
    { 
        Student student = new Student();
        student.Name = ExtendentConsole.ReadString("Kérem a tanuló nevét: ");
        student.Class = ExtendentConsole.ReadString("Kérem a tanuló osztályát: ");
        student.Address = ExtendentConsole.ReadString("Kérem a tanuló lakcímét: ");
        student.Subjects = await GetSubjectsAsync();
        return student;
    }

    public static async Task<ICollection<Subject>> GetSubjectsAsync()
    { 
        List<Subject> subjects = new List<Subject>();
        Subject subject = null;
        List<int> temp = null;
        bool moreSubject = false;
        bool moreMark = false;
        string input = null;
        int markInput = 0;
        do
        {
            input = ExtendentConsole.ReadString("Kérem a tantárgy nevét vagy a feladat végesztével a 'nomore' utasítást: ");
            if (input != "nomore")
            {
                subject = new Subject();
                subject.Name = input;
                temp = new List<int>();
                do
                {
                    markInput = ExtendentConsole.ReadInteger(0,5,"Kérem a jegyet, a jegyek beírásának végét a 0 lenyomásával jelezze: ");
                    if (markInput != 0)
                    {
                        temp.Add(markInput);
                    }
                    else
                    { 
                        moreMark = true;
                     }

                } while (!moreMark);
                subject.Marks = temp;
                subjects.Add(subject);
            }
            else
            { 
                moreSubject = true;
            }
        }
        while (!moreSubject);

        return subjects;
    }
}

