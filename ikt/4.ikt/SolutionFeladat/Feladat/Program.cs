using Custom.Library.ConsoleExtensions;

bool endOfWork = false;
List<Student> students = await FileService.ReadFromFileAsync<Student>("diakok.json");
List<SubjectFolder> subjects = await FileService.ReadFromFileAsync<SubjectFolder>("tantargyak.json");


var temp = from student in students
    join subject in subjects on student.StudentId equals subject.StudentId
    select new JoinedStudentData
    {   Name = student.Name,
        Address = student.Address,
        Class = student.Class,
        Id = student.StudentId ,
        Subjects = subject.Subjects
        
    };

List<JoinedStudentData> joinedStudentsDatas = temp.ToList();

do
{
   
    Console.WriteLine("A rendszer lehetőségei:\n-list.students\n-students.add\n-students.modify\n-students.delete\n-subjects.add\n-subjectdelete\n-subjectmodify\n-markadd\n-markdelete\n-markmodify\n-endofwork");
    string input = ExtendentConsole.ReadString("\nKérem válasszon: ");

    switch (input)
    {
        case "list.students":
            {

                Console.Clear();
                await DataService.WriteStudentNamesAsync(joinedStudentsDatas);
                break;
            }

        case "students.add":
            {
                Console.Clear();
                joinedStudentsDatas = await DataService.AddNewStudentsAsync(joinedStudentsDatas.Count, joinedStudentsDatas);
                break;
            }
        case "students.modify":
            {
                Console.Clear();
                joinedStudentsDatas = await DataService.ModifyStudentsDataAsync(joinedStudentsDatas);
                break;
            }
        case "students.delete":
            {
                Console.Clear();
                joinedStudentsDatas = await DataService.DeleteStudentsDataAsync(joinedStudentsDatas);
                break;
            }
        case "subjects.add":
            {
                Console.Clear();
                joinedStudentsDatas = await DataService.AddNewSubjectsToExistingStudentsAsync(joinedStudentsDatas);
                break;
            }
        case "subjectdelete":
            {
                Console.Clear();
                await DataService.DeleteSubjectAsync(students, subjects);
                break;
            }
        case "subjectmodify":
            {
                Console.Clear();
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
