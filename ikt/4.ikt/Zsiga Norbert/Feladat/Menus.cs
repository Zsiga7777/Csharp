

namespace Feladat
{
    public class Menus
    {
        public static async Task<List<JoinedStudentData>> MainMenu(List<JoinedStudentData> joinedStudentsDatas)
        {
            bool endOfWork = false;
            do
            {

                Console.WriteLine("A rendszer lehetőségei:");
                int input = ReusableMenu(["Tanuló adat kiírása",
                    "Tanulók neveinek kiírása",
                    "Tanulók hozzáadása",
                    "Tanulók módosítása",
                    "Tanulók törlése"]);

                switch (input)
                {
                    case -1:
                        {
                            endOfWork = true;
                            break;
                        }
                    case 0:
                        {
                            Console.Clear();
                            await ConsoleFunctions.WriteStudentData(joinedStudentsDatas);
                            break;
                        }
                    case 1:
                        {

                            Console.Clear();
                            ReusableMenu(joinedStudentsDatas.Select(x => x.Name).ToList());
                            break;
                        }

                    case 2:
                        {
                            Console.Clear();
                            DataService.AddNewStudents(joinedStudentsDatas.Count, joinedStudentsDatas);
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            ModifyStudents(joinedStudentsDatas);
                            break;
                        }
                    case 4:
                        {
                            Console.Clear();
                            joinedStudentsDatas = DataService.DeleteStudentsData(joinedStudentsDatas);
                            break;
                        }
                }

            }
            while (!endOfWork);
            return joinedStudentsDatas;
        }
        public static List<JoinedStudentData> ModifyStudentsSubjects(List<JoinedStudentData> joinedStudentDatas, int indexOfStudent)
        {
            do
            {
                Console.Clear();

                int modificationType = ReusableMenu(["Tantárgyak hozzáadása", "Tantárgyak Törlése", "Tantárgyak módosítása"]);
                switch (modificationType)
                {
                    case -1:
                        {
                            return joinedStudentDatas;
                        }
                    case 0:
                        {
                            DataService.AddNewSubjectsToExistingStudents(joinedStudentDatas, indexOfStudent);
                            break;
                        }
                    case 1:
                        {
                            DataService.DeleteSubjects(joinedStudentDatas, indexOfStudent);
                            break;
                        }
                    case 2:
                        {
                            ModifySubject(joinedStudentDatas, indexOfStudent);
                            break;
                        }
                }

            } while (true);
        }
        public static List<JoinedStudentData> ModifyStudents(List<JoinedStudentData> joinedStudentDatas)
        {
            do
            {
                Console.Clear();

                int studentNeedsModifyIndex = ConsoleFunctions.GetStudentIndex(joinedStudentDatas);
                if (studentNeedsModifyIndex == -1) return joinedStudentDatas;

                int modificationType = ReusableMenu(["Tanuló adatainak módosítása", "Tanuló tantárgyainak módosítása"]);
                switch (modificationType)
                {
                    case -1:
                        {
                            return joinedStudentDatas;
                        }
                    case 0:
                        {
                            DataService.ModifyStudentsData(joinedStudentDatas, studentNeedsModifyIndex); break;
                        }
                    case 1:
                        {
                            ModifyStudentsSubjects(joinedStudentDatas, studentNeedsModifyIndex); break;
                        }
                }
            } while (true);

        }
        public static List<JoinedStudentData> ModifySubject(List<JoinedStudentData> joinedStudentDatas, int indexOfStudent)
        {
            do
            {
                Console.Clear();

                int selectedOption = ReusableMenu(["Tantárgy nevének módosítása", "Tantárgy jegyeinek módosítása"]);

                switch (selectedOption)
                {
                    case -1:
                        {
                            return joinedStudentDatas;
                        }
                    case 0:
                        {
                            DataService.ModifySubjectName(joinedStudentDatas, indexOfStudent);
                            break;
                        }
                    case 1:
                        {
                            MarksMenu(joinedStudentDatas, indexOfStudent);
                            break;
                        }
                }
            } while (true);
        }
        public static List<JoinedStudentData> MarksMenu(List<JoinedStudentData> joinedStudentDatas, int indexOfStudent)
        {
            do
            {
                string selectedSubjectName = ConsoleFunctions.GetSubjectName(joinedStudentDatas[indexOfStudent].Subjects);

                if (selectedSubjectName == "")
                {
                    return joinedStudentDatas;
                }

                List<int> temp = joinedStudentDatas[indexOfStudent].Subjects[selectedSubjectName].ToList();

                int selectedOption = ReusableMenu(["Jegy hozzáadása", "Jegy törlése", "Jegy módosítása"]);

                switch (selectedOption)
                {
                    case -1:
                        {
                            return joinedStudentDatas;
                        }
                    case 0:
                        {
                            temp = DataService.AddNewMark(temp);
                            break;
                        }
                    case 1:
                        {
                            temp = DataService.DeleteMark(temp);
                            break;
                        }
                    case 2:
                        {
                            temp = DataService.ModifyMark(temp);
                            break;
                        }
                }

                joinedStudentDatas[indexOfStudent].Subjects[selectedSubjectName] = temp;

            }
            while (true);
        }

        public static int ReusableMenu<T>(List<T> options)
        {
            int index = 0;
            int pageNumber = 0;
            ConsoleKeyInfo keyinfo;
            do
            {
                List<T> currentPage = options.Skip((pageNumber) * 10).Take(10).ToList();
                ConsoleFunctions.WriteMenu(currentPage, index);
                Console.WriteLine("\nfelfele lépéshez felfelenyíl, lefele lépéhez lefelenyíl, kiválasztáshoz enter, kilépéshez e");
                Console.WriteLine("előző oldal balranyíl, követkető oldal jobbranyíl");
                keyinfo = Console.ReadKey();
                if (keyinfo.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 < 0)
                    {
                        index = 0;
                    }
                    else
                    {
                        index--;
                    }
                }
                else if (keyinfo.Key == ConsoleKey.DownArrow)
                {
                    if (index + 1 + pageNumber * 10 >= options.Count)
                    {
                        index = 0;
                    }
                    else if (index == 9)
                    {
                        index = 0;
                    }
                    else
                    {
                        index++;
                    }
                }
                else if (keyinfo.Key == ConsoleKey.LeftArrow)
                {
                    if (pageNumber - 1 < 0 && options.Count > 10)
                    {
                        pageNumber = options.Count / 10;
                        index = 0;
                    }
                    else if (pageNumber - 1 < 0)
                    {
                        pageNumber = 0;
                        index = 0;
                    }
                    else
                    {
                        pageNumber--;
                        index = 0;
                    }
                }
                else if (keyinfo.Key == ConsoleKey.RightArrow)
                {
                    if (pageNumber + 1 >= options.Count / (double)10)
                    {
                        pageNumber = 0;
                        index = 0;
                    }
                    else
                    {
                        pageNumber++;
                        index = 0;
                    }
                }
                else if (keyinfo.Key == ConsoleKey.Enter)
                {
                    return index + pageNumber * 10;
                }
                else if (keyinfo.Key == ConsoleKey.E)
                {
                    return -1;
                }
            } while (true);
        }
    }
}
