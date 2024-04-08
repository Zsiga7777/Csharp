
using Custom.Library.ConsoleExtensions;
using System.Collections.Generic;
using System.Xml.Linq;

public static class DataService
{
    public static async Task<List<JoinedStudentData>> AddNewStudentsAsync(int newID, List<JoinedStudentData> joinedStudentDatas)
    {
        bool nomore = false;
        do
        {
            Console.Clear();
            string input = ExtendentConsole.ReadString("Kérem a tanuló nevét vagy a feladat végeztével a nomore utasítást: ").Trim();
            if (input == "nomore") { break; }

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
                Subjects = await AddNewSubjectsAsync(new Dictionary<string, ICollection<int>>()),
                Id = newID
            });
        }while(!nomore);

        return joinedStudentDatas;
    }

    public static async Task<List<JoinedStudentData>> ModifyStudentsDataAsync(List<JoinedStudentData> joinedStudentDatas)
    {
        bool nomore = false;
        string temp = "";
        int iterationCounter = 0;
        do
        {
            Console.Clear();
            
            if (iterationCounter > 0)
            {
                temp = ExtendentConsole.ReadString("Kívánja folytatni? Amennyiben nem, írja be a nomore parancsot, ellenkező esetben nyomjon entert: ");
                if (temp.ToLower() == "nomore") { break; }
            }
            Console.WriteLine("\nA tanulók nevei: ");
            await WriteStudentNamesAsync(joinedStudentDatas);
            string studentNeedsModify = null;

            do
            {
                studentNeedsModify = ExtendentConsole.ReadString("Kérem a módosítani kívánt tanuló nevét: ").Trim();
            }
            while (!joinedStudentDatas.Any(x => x.Name == studentNeedsModify));

            Console.WriteLine("1:Név módosítás\n2:Osztály módosítás\n3:lakcím módosítás");
            int modificítionType = ExtendentConsole.ReadInteger(1, 3, "Kérem a módosítandó adat számát:");
            string newData = ExtendentConsole.ReadString("Kérem az új adatot: ").Trim();
            switch (modificítionType)
            {
                case 1:
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
                        joinedStudentDatas.First(x => x.Name == studentNeedsModify).Name = newData; break;
                    }
                case 2:
                    {
                        joinedStudentDatas.First(x => x.Name == studentNeedsModify).Class = newData; break;
                    }
                case 3:
                    {
                        joinedStudentDatas.First(x => x.Name == studentNeedsModify).Address = newData; break;
                    }
            }
        } while (!nomore);
        iterationCounter++;
        return joinedStudentDatas;
    }
    public static async Task<List<JoinedStudentData>> DeleteStudentsDataAsync(List<JoinedStudentData> joinedStudentDatas)
    {
        bool nomore = false;
        string temp = "";
        int iterationCounter = 0;
        do
        {
            Console.Clear();
            if (iterationCounter > 0)
            {
                temp = ExtendentConsole.ReadString("Kívánja folytatni? Amennyiben nem, írja be a nomore parancsot, ellenkező esetben nyomjon entert: ");
                if (temp.ToLower() == "nomore") { break; }
            }
            Console.WriteLine("\nA tanulók nevei: ");
            await WriteStudentNamesAsync(joinedStudentDatas);
            string studentNeedsDelete = null;

            do
            {
                studentNeedsDelete = ExtendentConsole.ReadString("Kérem a törölni kívánt tanuló nevét: ").Trim();
            }
            while (!joinedStudentDatas.Any(x => x.Name == studentNeedsDelete));

            joinedStudentDatas = joinedStudentDatas.Except(joinedStudentDatas.Where(x => x.Name == studentNeedsDelete)).ToList();
            iterationCounter++;
        } while (!nomore);
        return joinedStudentDatas;
    }

    public static async Task<Dictionary<string, ICollection<int>>> AddNewSubjectsAsync(Dictionary<string, ICollection<int>> subjects)
    {

        bool moreSubject = false;
        bool moreMark = false;
        string input = null;
        int markInput = 0;
        do
        {
            input = ExtendentConsole.ReadString("Kérem a tantárgy nevét vagy a feladat végesztével a 'nomore' utasítást: ").ToLower().Trim();
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

        return subjects;
    }

    public static async Task<List<JoinedStudentData>> AddNewSubjectsToExistingStudentsAsync(List<JoinedStudentData> joinedStudentDatas)
    {
        bool nomore = false;
        string iterationTemp = "";
        int iterationCounter = 0;
        do
        {

            if (iterationCounter > 0)
            {
                iterationTemp = ExtendentConsole.ReadString("Kívánja folytatni? Amennyiben nem, írja be a nomore parancsot, ellenkező esetben nyomjon entert: ");
                if (iterationTemp.ToLower() == "nomore") { break; }
            }

            Console.WriteLine("\n tanulók nevei: ");
            joinedStudentDatas.WriteCollectionToConsole();
            string studentNeedsToAddSubject = null;

            do
            {
                studentNeedsToAddSubject = ExtendentConsole.ReadString("Kérem a tanuló nevét, akinek új tantárgyat kell hozzáadni: ").Trim();
            }
            while (!joinedStudentDatas.Any(x => x.Name == studentNeedsToAddSubject));

            Dictionary<string, ICollection<int>> temp = await AddNewSubjectsAsync(joinedStudentDatas.First(x => x.Name == studentNeedsToAddSubject).Subjects);

            joinedStudentDatas.First(x => x.Name == studentNeedsToAddSubject).Subjects = temp;
            iterationCounter++;
        }while (!nomore);
        return joinedStudentDatas;

    }

    public static async Task<List<SubjectFolder>> DeleteSubjectAsync(List<Student> students, List<SubjectFolder> subjectFolders)
    {
        Console.WriteLine("\n tanulók nevei: ");
        students.WriteCollectionToConsole();
        string studentNeedsToAddSubject = null;

        do
        {
            studentNeedsToAddSubject = ExtendentConsole.ReadString("Kérem a tanuló nevét, akinek új tantárgyat kell hozzáadni: ").Trim();
        }
        while (!students.Any(x => x.Name == studentNeedsToAddSubject));

        int studentId = students.First(x => x.Name == studentNeedsToAddSubject).StudentId;

        SubjectFolder subjectFolder = subjectFolders.First(x => x.StudentId == studentId);

        int indexOfThisFolder = subjectFolders.IndexOf(subjectFolder);

        bool moreMark = false;
        string input = null;
        int markInput = 0;

        do
        {
            input = ExtendentConsole.ReadString("Kérem a törlendő tantárgy nevét: ").ToLower().Trim();
            if (subjectFolder.Subjects.ContainsKey(input))
            {
                subjectFolder.Subjects.Remove(input);
               
                break;
            }


        }
        while (!subjectFolder.Subjects.ContainsKey(input));

        subjectFolders[indexOfThisFolder] = subjectFolder;

        return subjectFolders;
    }

    public static async Task<List<SubjectFolder>> ModifySubjectAsync(List<Student> students, List<SubjectFolder> subjectFolders)
    {
        Console.WriteLine("\n tanulók nevei: ");
        students.WriteCollectionToConsole();
        string studentNeedsToAddSubject = null;

        do
        {
            studentNeedsToAddSubject = ExtendentConsole.ReadString("Kérem a tanuló nevét, akinek módosítani kella  tantárgyát: ").Trim();
        }
        while (!students.Any(x => x.Name == studentNeedsToAddSubject));

        int studentId = students.First(x => x.Name == studentNeedsToAddSubject).StudentId;

        SubjectFolder subjectFolder = subjectFolders.First(x => x.StudentId == studentId);

        int indexOfThisFolder = subjectFolders.IndexOf(subjectFolder);

        string input = null;

        do
        {
            input = ExtendentConsole.ReadString("Kérem a módosítandó tantárgy nevét: ").ToLower().Trim();
            if (subjectFolder.Subjects.ContainsKey(input))
            {
                List<int> temp = subjectFolder.Subjects[input].ToList();
               subjectFolder.Subjects.Remove(input);
                subjectFolder.Subjects.Add(ExtendentConsole.ReadString("Kérem a tantárgy módosított nevét: ").ToLower().Trim(), temp);
                break;
            }


        }
        while (!subjectFolder.Subjects.ContainsKey(input));

        subjectFolders[indexOfThisFolder] = subjectFolder;

        return subjectFolders;
    }

    public static async Task WriteStudentNamesAsync(IEnumerable<JoinedStudentData> joinedStudentDatas)
    {
        foreach (var joinedStudentData in joinedStudentDatas)
        {
            Console.WriteLine($"-{joinedStudentData.Name}");
        }
    }
}

