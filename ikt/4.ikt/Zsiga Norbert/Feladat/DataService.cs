using Custom.Library.ConsoleExtensions;
using Feladat;

public static class DataService
{
    #region student
    public static List<JoinedStudentData> AddNewStudents(int newID, List<JoinedStudentData> joinedStudentDatas)
    {
        bool nomore = false;
        do
        {
            Console.Clear();
            string input = ExtendentConsole.ReadString("Kérem a tanuló nevét vagy a feladat végeztével a 'e' gomb lenyomását: ");
            if (input.ToLower() == "e") { break; }

            int counter = 0;
            while (joinedStudentDatas.Any(x => x.Name == input))
            {
                counter++;
                input = input + $"{counter}";
            }
            while (joinedStudentDatas.Any(x => x.Id == newID)) 
            {
                newID++;
            }
            joinedStudentDatas.Add(new JoinedStudentData
            {
                Name = input,
                Class = ExtendentConsole.ReadString("Kérem a tanuló osztályát: "),
                Address = ExtendentConsole.ReadString("Kérem a tanuló lakcímét: "),
                Subjects =  AddNewSubjects(new Dictionary<string, ICollection<int>>()),
                Id = newID
            });
        }while(!nomore);

        return joinedStudentDatas;
    }

    

    public static List<JoinedStudentData> ModifyStudentsData(List<JoinedStudentData> joinedStudentDatas, int indexOfStudent)
    {
        do
        {
            Console.Clear();

            int modificationType = Menus.ReusableMenu(["Név módosítás", "Osztály módosítás", "Lakcím módosítás"]);
            if (modificationType == -1) return joinedStudentDatas;
            string newData = ExtendentConsole.ReadString("Kérem az új adatot: ");
            switch (modificationType)
            {

                case 0:
                    {
                        if (joinedStudentDatas.Any(x => x.Name == newData))
                        {
                            int counter = 0;
                            while (joinedStudentDatas.Any(x => x.Name == newData))
                            {
                                counter++;
                                newData = newData + $"{counter}";
                            }
                        }
                        joinedStudentDatas[indexOfStudent].Name = newData; break;
                    }
                case 1:
                    {
                        joinedStudentDatas[indexOfStudent].Class = newData; break;
                    }
                case 2:
                    {
                        joinedStudentDatas[indexOfStudent].Address = newData; break;
                    }
            }
        } while (true);

    }

    
    public static List<JoinedStudentData> DeleteStudentsData(List<JoinedStudentData> joinedStudentDatas)
    { 
        do
        {
            Console.Clear();

            int studentNeedsDeleteIndex = ConsoleFunctions.GetStudentIndex(joinedStudentDatas);
            if (studentNeedsDeleteIndex == -1)
            {
                return joinedStudentDatas;
            }
            string studentNeedsDelete = joinedStudentDatas[studentNeedsDeleteIndex].Name;

            joinedStudentDatas = joinedStudentDatas.Except(joinedStudentDatas.Where(x => x.Name == studentNeedsDelete)).ToList();

        } while (true);
    }
    #endregion

    #region subject
    public static Dictionary<string, ICollection<int>> AddNewSubjects(Dictionary<string, ICollection<int>> subjects)
    {

        bool moreSubject = false;
        string input = null;
        do
        {  
            input = ExtendentConsole.ReadString("Kérem a tantárgy nevét vagy a feladat végesztével a 'e' gomb lenyomása: ").ToLower();
            if (input.ToLower() != "e")
            {
                if (!subjects.ContainsKey(input))
                {
                    subjects.Add(input, AddNewMark());
                }
            }
            else
            {
                moreSubject = true;
            }
        }
        while (!moreSubject);

        return subjects;
    }

    public static List<JoinedStudentData> AddNewSubjectsToExistingStudents(List<JoinedStudentData> joinedStudentDatas, int indexOfStudent)
    {
        int iterationCounter = 0;
        do
        {

            if (iterationCounter > 0)
            {
                if(ConsoleFunctions.AskIfWantTocontinue())
                 { break; }
            }        

            joinedStudentDatas[indexOfStudent].Subjects = AddNewSubjects(joinedStudentDatas[indexOfStudent].Subjects);

            iterationCounter++;
        }while (true);
        return joinedStudentDatas;

    }

    public static List<JoinedStudentData> DeleteSubjects(List<JoinedStudentData> joinedStudentDatas, int indexOfStudent)
    {
        do
        {
            Console.Clear();

            string subject = ConsoleFunctions.GetSubjectName(joinedStudentDatas[indexOfStudent].Subjects);
            if (subject == "")
            { 
                return joinedStudentDatas; 
            }

            joinedStudentDatas[indexOfStudent].Subjects.Remove(subject);

        } while (true);
    }

    

    public static List<JoinedStudentData> ModifySubjectName(List<JoinedStudentData> joinedStudentDatas, int indexOfStudent)
    {
        Dictionary<string, ICollection<int>> subjectFolder = joinedStudentDatas[indexOfStudent].Subjects;

        string subject = ConsoleFunctions.GetSubjectName(subjectFolder);

        if (subject == "")
        { return joinedStudentDatas;
        }

        string newName = "";
        do
        {
           newName = ExtendentConsole.ReadString("Kérem a tantárgy módosított nevét: ").ToLower();
        } while (subjectFolder.ContainsKey(newName));


        List<int> temp = subjectFolder[subject].ToList();
         subjectFolder.Remove(subject);
         subjectFolder.Add(newName, temp);

         joinedStudentDatas[indexOfStudent].Subjects = subjectFolder;
        return joinedStudentDatas;
    }
    #endregion

    #region mark
    public static  List<int> AddNewMark(List<int> markList = null)
    {
        if (markList == null)
        { 
            markList = new List<int>(); 
        }

        int input = 0;
        do
        {
            Console.Clear();
 
             input = ExtendentConsole.ReadInteger(0, 5, "Kérem a beírandó jegyet, vagy a kilépshez a 0-át: ");
             if (input == 0)
                    {
                        break;
                    }
             markList.Add(input);
         }while (true);
        return markList;
    }

    public static List<int> DeleteMark(List<int> markList)
    {
        int indexOfMark = 0;
        do
        {
            Console.Clear();

            indexOfMark = ConsoleFunctions.GetMarkIndex(markList);

            if (indexOfMark == -1)
            {
                break;
            }
            markList.RemoveAt(indexOfMark);

        } while (true);

        return markList;
    }

    public static List<int> ModifyMark(List<int> markList)
    {
        int selectedMarkIndex = 0;
        int inputNewMark = 0;
        do
        {
            selectedMarkIndex = ConsoleFunctions.GetMarkIndex(markList);
            if (selectedMarkIndex == -1)
            {
                break;
            }
            inputNewMark = ExtendentConsole.ReadInteger(1, 5, "Kérem az új jegyet: ");
            markList.RemoveAt(selectedMarkIndex );
            markList.Insert(selectedMarkIndex , inputNewMark);
        } while (true) ;

        return markList;
    }
    #endregion

    #region managingSaving
    public static async Task<List<JoinedStudentData>> GetExistingData()
    {
        List<Student> students = await FileService.ReadFromFileAsync<Student>("diakok.json");
        List<SubjectFolder> subjects = await FileService.ReadFromFileAsync<SubjectFolder>("tantargyak.json");


        var temp = from student in students
                   join subject in subjects on student.StudentId equals subject.StudentId
                   select new JoinedStudentData
                   {
                       Name = student.Name,
                       Address = student.Address,
                       Class = student.Class,
                       Id = student.StudentId,
                       Subjects = subject.Subjects

                   };

        List<JoinedStudentData> joinedStudentsDatas = temp.ToList();

        return joinedStudentsDatas;
    }

    public static async Task WriteData(List<JoinedStudentData> joinedStudentsDatas)
    {
        List<Student> students = joinedStudentsDatas.Select(x => new Student
        {
            Name = x.Name,
            Class = x.Class,
            Address = x.Address,
            StudentId = x.Id
        }).ToList();

        List<SubjectFolder> subjects = joinedStudentsDatas.Select(x => new SubjectFolder
        {
            StudentId = x.Id,
            Subjects = x.Subjects
        }).ToList();
        await FileService.WriteToJsonFile(students, "diakok.json");
        await FileService.WriteToJsonFile(subjects, "tantargyak.json");

    }
    #endregion
}