using Custom.Library.ConsoleExtensions;

public static class DataService
{
    #region student
    public static async Task<List<JoinedStudentData>> AddNewStudentsAsync(int newID, List<JoinedStudentData> joinedStudentDatas)
    {
        bool nomore = false;
        do
        {
            Console.Clear();
            string input = ExtendentConsole.ReadString("Kérem a tanuló nevét vagy a feladat végeztével a nomore utasítást: ");
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
        int iterationCounter = 0;
        do
        {
            Console.Clear();
            
            if (iterationCounter > 0)
            {
                if(await AskIfWantTocontinueAsync()) { break; }
            }

            string studentNeedsModify = await GetStudentNameAsync(joinedStudentDatas, "Kérem a módosítani kívánt tanuló nevét: ");
            
            Console.WriteLine("1:Név módosítás\n2:Osztály módosítás\n3:lakcím módosítás");
            int modificítionType = ExtendentConsole.ReadInteger(1, 3, "Kérem a módosítandó adat számát:");
            string newData = ExtendentConsole.ReadString("Kérem az új adatot: ");
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
            iterationCounter++;
        } while (true);
        
        return joinedStudentDatas;
    }
    public static async Task<List<JoinedStudentData>> DeleteStudentsDataAsync(List<JoinedStudentData> joinedStudentDatas)
    {
        int iterationCounter = 0;
        do
        {
            Console.Clear();
            if (iterationCounter > 0)
            {
                if( await AskIfWantTocontinueAsync()) { break; }
            }
            string studentNeedsDelete = await GetStudentNameAsync(joinedStudentDatas, "Kérem a törölni kívánt tanuló nevét: ");

            joinedStudentDatas = joinedStudentDatas.Except(joinedStudentDatas.Where(x => x.Name == studentNeedsDelete)).ToList();
            iterationCounter++;
        } while (true);
        return joinedStudentDatas;
    }
    #endregion

    #region subject
    public static async Task<Dictionary<string, ICollection<int>>> AddNewSubjectsAsync(Dictionary<string, ICollection<int>> subjects)
    {

        bool moreSubject = false;
        bool moreMark = false;
        string input = null;
        int markInput = 0;
        do
        {
            await WriteExistingSubjectNamesAsync(subjects);
            input = ExtendentConsole.ReadString("Kérem a tantárgy nevét vagy a feladat végesztével a 'nomore' utasítást: ").ToLower();
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
        int iterationCounter = 0;
        do
        {

            if (iterationCounter > 0)
            {
                if( await AskIfWantTocontinueAsync())
                 { break; }
            }

           string studentNeedsToAddSubject = await GetStudentNameAsync(joinedStudentDatas, "Kérem a tanuló nevét, akinek új tantárgyat kell hozzáadni: ");         

            joinedStudentDatas.First(x => x.Name == studentNeedsToAddSubject).Subjects = await AddNewSubjectsAsync(joinedStudentDatas.First(x => x.Name == studentNeedsToAddSubject).Subjects);

            iterationCounter++;
        }while (true);
        return joinedStudentDatas;

    }

    public static async Task<List<JoinedStudentData>> DeleteSubjectsAsync(List<JoinedStudentData> joinedStudentDatas)
    {
        int iterationCounter = 0;
        do
        {
            Console.Clear();
            if (iterationCounter > 0)
            {
                if (await AskIfWantTocontinueAsync())
                { break; }
            }
           string studentNeedsToDeleteSubject = await GetStudentNameAsync(joinedStudentDatas,"Kérem a tanuló nevét, akinek tantárgyat kell törölni: ");

            Dictionary<string, ICollection<int>> subjectFolder = joinedStudentDatas.First(x => x.Name == studentNeedsToDeleteSubject).Subjects;
            string input = null;
            do
            {
                await WriteExistingSubjectNamesAsync(subjectFolder);
                input = ExtendentConsole.ReadString("Kérem a törlendő tantárgy nevét: ").ToLower();
                if (subjectFolder.ContainsKey(input))
                {
                    subjectFolder.Remove(input);
                    break;
                }


            }
            while (!subjectFolder.ContainsKey(input));

            joinedStudentDatas.First(x => x.Name == studentNeedsToDeleteSubject).Subjects = subjectFolder;
            iterationCounter++;
        } while (true);

        return joinedStudentDatas;
    }

    public static async Task<List<JoinedStudentData>> ModifySubjectAsync(List<JoinedStudentData> joinedStudentDatas)
    {
        int counter = 0;

        do
        {
            Console.Clear();

            if (counter > 0)
            {
                if (await AskIfWantTocontinueAsync())
                { break; }
            }

            string studentNeedsToModifySubject =await GetStudentNameAsync(joinedStudentDatas, "Kérem a tanuló nevét, akinek módosítani kell a tantárgyát: ");

            Dictionary<string, ICollection<int>> subjectFolder = joinedStudentDatas.First(x => x.Name == studentNeedsToModifySubject).Subjects;

            string input = null;

            do
            {
                await WriteExistingSubjectNamesAsync(subjectFolder);
                input = ExtendentConsole.ReadString("Kérem a módosítandó tantárgy nevét: ").ToLower();
                if (subjectFolder.ContainsKey(input))
                {
                    List<int> temp = subjectFolder[input].ToList();
                    subjectFolder.Remove(input);
                    subjectFolder.Add(ExtendentConsole.ReadString("Kérem a tantárgy módosított nevét: ").ToLower(), temp);
                    break;
                }
            }
            while (!subjectFolder.ContainsKey(input));

            joinedStudentDatas.First(x => x.Name == studentNeedsToModifySubject).Subjects = subjectFolder;
        } while (true);
        return joinedStudentDatas;
    }
    #endregion

    #region mark
    public static async Task<List<JoinedStudentData>> AddNewMarkAsnyc(List<JoinedStudentData> joinedStudentDatas)
    {
        int counterStudent = 0;
        int counterSubject = 0;
        int input = 0;
        do
        {
            Console.Clear();

            if (counterStudent > 0)
            {
                if (await AskIfWantTocontinueAsync())
                { break; }
            }

           string studentNeedsToAddMark = await GetStudentNameAsync(joinedStudentDatas,"Kérem a tanuló nevét, akinek jegyet kell hozzáadni: ");

            Dictionary<string, ICollection<int>> subjectFolder = joinedStudentDatas.First(x => x.Name == studentNeedsToAddMark).Subjects;
            counterSubject = 0;
            do
            {
                if (counterSubject > 0)
                {
                    if (await AskIfWantTocontinueAsync())
                    { break; }
                }
                string subject = await GetSubjectNameAsync(subjectFolder, "Kérem a tantárgy nevét, ahova jegyet kell hozzáadni: ");

                do
                {
                    input = ExtendentConsole.ReadInteger(0, 5, "Kérem a beírandó jegyet, vagy a kilépshez a 0-át: ");
                    if (input == 0)
                    {
                        break;
                    }
                    subjectFolder[subject].Add(input);
                }
                while (true);

                joinedStudentDatas.First(x => x.Name == studentNeedsToAddMark).Subjects = subjectFolder;
                counterSubject++;

            } while (true);

            counterStudent++;

        } while (true);

        return joinedStudentDatas;
    }

    public static async Task<List<JoinedStudentData>> DeleteMarkAsync(List<JoinedStudentData> joinedStudentDatas)
    {
        int counterStudent = 0;
        int counterSubject = 0;
        int input = 0;
        List<int> marks = new List<int>();
        do
        {
            Console.Clear();

            if (counterStudent > 0)
            {
                if (await AskIfWantTocontinueAsync())
                { break; }
            }

            string studentNeedsToDeleteMark = await GetStudentNameAsync(joinedStudentDatas, "Kérem a tanuló nevét, akinek jegyet kell törölni: ");

            Dictionary<string, ICollection<int>> subjectFolder = joinedStudentDatas.First(x => x.Name == studentNeedsToDeleteMark).Subjects;
            counterSubject = 0;
            do
            {
                if (counterSubject > 0)
                {
                    if (await AskIfWantTocontinueAsync())
                    { break; }
                }
                string subject = await GetSubjectNameAsync(subjectFolder, "Kérem a tantárgy nevét, ahonnan jegyet kell törölni: ");

                do
                {
                    await WriteMarksAsync(subjectFolder[subject]);
                    input = ExtendentConsole.ReadInteger(0, subjectFolder[subject].Count, "Kérem a kitörlendő jegy sorszámát, vagy a kilépshez a 0-át: ");
                    if (input == 0)
                    {
                        break;
                    }
                    marks = subjectFolder[subject].ToList();
                    marks.RemoveAt(input-1);
                    subjectFolder[subject].Clear();
                    subjectFolder[subject] = marks;
                }
                while (true);

                joinedStudentDatas.First(x => x.Name == studentNeedsToDeleteMark).Subjects = subjectFolder;
                counterSubject++;

            } while (true);

            counterStudent++;

        } while (true);

        return joinedStudentDatas;
    }

    public static async Task<List<JoinedStudentData>> ModifyMarkAsync(List<JoinedStudentData> joinedStudentDatas)
    { 
            int counterStudent = 0;
            int counterSubject = 0;
            int inputIndex = 0;
        int inputNewMark = 0;
        List<int> marks = new List<int>();
                do
                {
                    Console.Clear();

                    if (counterStudent > 0)
                    {
                        if (await AskIfWantTocontinueAsync())
                        { break; }
                    }

        string studentNeedsToModifyMark = await GetStudentNameAsync(joinedStudentDatas, "Kérem a tanuló nevét, akinek jegyet kell törölni: ");

        Dictionary<string, ICollection<int>> subjectFolder = joinedStudentDatas.First(x => x.Name == studentNeedsToModifyMark).Subjects;
        counterSubject = 0;
        do
        {
            if (counterSubject > 0)
            {
                if (await AskIfWantTocontinueAsync())
                { break; }
            }
            string subject = await GetSubjectNameAsync(subjectFolder, "Kérem a tantárgy nevét, ahonnan jegyet kell törölni: ");

            do
            {
                await WriteMarksAsync(subjectFolder[subject]);
                inputIndex = ExtendentConsole.ReadInteger(0, subjectFolder[subject].Count, "Kérem a módosítandó jegy sorszámát, vagy a kilépshez a 0-át: ");
                if (inputIndex == 0)
                {
                    break;
                }
                    inputNewMark = ExtendentConsole.ReadInteger(1, 5, "Kérem az új jegyet: ");
                marks = subjectFolder[subject].ToList();
                marks.RemoveAt(inputIndex - 1);
                    marks.Insert(inputIndex - 1, inputNewMark);
                    subjectFolder[subject].Clear();
                    subjectFolder[subject] = marks;
            }
            while (true);

            joinedStudentDatas.First(x => x.Name == studentNeedsToModifyMark).Subjects = subjectFolder;
            counterSubject++;

        } while (true);

        counterStudent++;

                } while (true) ;

        return joinedStudentDatas;
    }
    #endregion

    #region anythingElse
    public static async Task WriteStudentNamesAsync(IEnumerable<JoinedStudentData> joinedStudentDatas)
    {
        foreach (var joinedStudentData in joinedStudentDatas)
        {
            Console.WriteLine($"-{joinedStudentData.Name}");
        }
    }

    public static async Task WriteStudentDataAsync(List<JoinedStudentData> joinedStudentDatas)
    {
        string studentName = await GetStudentNameAsync(joinedStudentDatas, "Kérem a kiirandó tanuló nevét: ");
        Console.WriteLine(joinedStudentDatas.First(x => x.Name == studentName));
    }

    public static async Task WriteExistingSubjectNamesAsync(Dictionary<string, ICollection<int>> subjects)
    {
        foreach (var subject in subjects)
        {
            Console.WriteLine($"- {subject.Key}");
        }
    }

    public static async Task<bool> AskIfWantTocontinueAsync()
    {
        bool nomore = false;
        string iterationTemp = "";
        Console.WriteLine("Kívánja folytatni? Amennyiben nem, írja be a nomore parancsot, ellenkező esetben nyomjon entert: ");
        iterationTemp = Console.ReadLine();
        if (iterationTemp.ToLower() == "nomore")
        { 
            nomore = true;
        }
        return nomore;
    }

    public static async Task<string> GetStudentNameAsync(List<JoinedStudentData> joinedStudentDatas, string prompt)
    {
        Console.WriteLine("\nA tanulók nevei: ");
        await WriteStudentNamesAsync(joinedStudentDatas);
        string studentName = null;

        do
        {
            studentName = ExtendentConsole.ReadString($"{prompt}");
        }
        while (!joinedStudentDatas.Any(x => x.Name == studentName));
        return studentName;
    }

    public static async Task<string> GetSubjectNameAsync(Dictionary<string, ICollection<int>> subjecFolder, string prompt)
    {
        Console.WriteLine("\nA tantárgyak: ");
        await WriteExistingSubjectNamesAsync(subjecFolder);
        string subjectName = null;

        do
        {
            subjectName = ExtendentConsole.ReadString($"{prompt}").ToLower();
        }
        while (!subjecFolder.ContainsKey(subjectName));
        return subjectName;
    }

    public static async Task WriteMarksAsync(ICollection<int> marks)
    {
        Console.WriteLine("Az aktuális jegyek: ");
        for (int i = 0; i < marks.Count; i++)
        {
            Console.WriteLine($"{i + 1}. - {marks.ToList()[i]}");
        }
    }
    #endregion
}