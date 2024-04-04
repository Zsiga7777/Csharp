using Custom.Library.ConsoleExtensions;

bool endOfWork = false;
List<Student> students = await FileService.ReadFromFileAsync<Student>("diakok.json");
List<SubjectFolder> subjects = await FileService.ReadFromFileAsync<SubjectFolder>("tantargyak.json");


var joinedStudentsDatas = from student in students
    join subject in subjects on student.StudentId equals subject.StudentId
    select new JoinedStudentData
    {   Name = student.Name,
        Address = student.Address,
        Class = student.Class,
        Id = student.StudentId ,
        Subjects = subject.Subjects
        
    };

joinedStudentsDatas.Append(new JoinedStudentData { Name = "Béla", Address = "Orosháza", Class = "11.b", Id = 1, Subjects = new Dictionary<string, ICollection<int>> {
    {"irodalom", new List<int> {1,2,3 } }
} });
do
{
   
    Console.WriteLine("A rendszer lehetőségei:\n-liststudents\n-studentadd\n-studentmodify\n-studentdelete\n-subjectadd\n-subjectdelete\n-subjectmodify\n-markadd\n-markdelete\n-markmodify\n-endofwork");
    string input = ExtendentConsole.ReadString("\nKérem válasszon: ");

    switch (input)
    {
        case "liststudents":
            {
                Console.WriteLine();
                await DataService.WriteStudentNamesAsync(joinedStudentsDatas);
                break;
            }

        case "studentadd":
            {   
                Console.WriteLine();
                joinedStudentsDatas = await DataService.AddNewStudentAsync(students.Count, joinedStudentsDatas);
                break;
            }
        case "studentmodify":
            {
                Console.WriteLine();
                await DataService.ModifyStudentDataAsync(joinedStudentsDatas);
                break;
            }
        case "studentdelete":
            {
                Console.WriteLine();
                await DataService.DeleteStudentDataAsync(joinedStudentsDatas);
                break;
            }
        case "subjectadd":
            {
                Console.WriteLine();
                await DataService.AddNewSubjectAsync(students, subjects);
                break;
            }
        case "subjectdelete":
            {
                Console.WriteLine();
                await DataService.DeleteSubjectAsync(students, subjects);
                break;
            }
        case "subjectmodify":
            {
                Console.WriteLine() ;
                await DataService.ModifySubjectAsync(students, subjects);
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

students.Clear();
students = joinedStudentsDatas.Select(x => new Student 
{
    Name = x.Name,
    Class = x.Class,
    Address = x.Address,
    StudentId = x.Id
}).ToList();

subjects.Clear();
subjects = joinedStudentsDatas.Select(x => new SubjectFolder 
{
    StudentId=x.Id,
    Subjects = x.Subjects
}).ToList();
await FileService.WriteToJsonFile(students,"diakok.json");
await FileService.WriteToJsonFile(subjects, "tantargyak.json");
