using Custom.Library.ConsoleExtensions;

bool endOfWork = false;
List<Student> students = await FileService.ReadFromFileAsync<Student>("diakok.json");
List<SubjectFolder> subjects = await FileService.ReadFromFileAsync<SubjectFolder>("tantargyak.json");

if (students != null && subjects != null)
{
    var valami = from student in students
                 join subject in subjects on student.StudentId equals subject.StudentId
                 select new { Name = student.Name, Class = student.Class, Address = student.Address, Subjects = subject.Subjects, Id = student.StudentId };
}


do
{
   
    Console.WriteLine("A rendszer lehetőségei:\n-liststudents\n-studentadd\n-studentmodify\n-studentdelete\n-subjectadd\n-subjectdelete\nsubjectmodify\n-markadd\n-markdelete\n-markmodify\n-endofwork");
    string input = ExtendentConsole.ReadString("\nKérem válasszon: ");

    switch (input)
    {
        case "liststudents":
            {
                Console.WriteLine();
                students.WriteCollectionToConsole();
                break;
            }

        case "studentadd":
            {   
                Console.WriteLine();
                students.Add(await DataService.AddNewStudentAsync(students.Count, students));
                subjects.Add(await DataService.AddNewSubjectFolderAsync(students));
                break;
            }
        case "studentmodify":
            {
                Console.WriteLine();
                students = await DataService.ModifyStudentData(students);
                break;
            }
        case "studentdelete":
            {
                Console.WriteLine();
                await DataService.DeleteStudentData(students, subjects);
                break;
            }
        case "endofwork":
            {
                endOfWork = true;
                break;
            }
        default:
            {
                Console.WriteLine();
                Console.WriteLine("Nem adott meg megfelelő parancsot.");
                break;
            }
    }

}
while (!endOfWork);
await FileService.WriteToJsonFile(students,"diakok.json");
await FileService.WriteToJsonFile(subjects, "tantargyak.json");
