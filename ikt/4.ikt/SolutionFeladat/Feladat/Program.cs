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
   
    Console.WriteLine("A rendszer lehetőségei:\n1 - write student data\n2 - list students\n3 - add students\n4 - modify students\n5 - delete students" +
        "\n6 - add subjects\n7 - delete subjects\n8 - modify subjects\n9 - add mark\n10 - delete mark\n11 - modify mark\n12 - save and exit");
    int input = ExtendentConsole.ReadInteger(1,12,"\nKérem válasszon: ");

    switch (input)
    {
        case 1:
            { 
                Console.Clear(); 
                await DataService.WriteStudentDataAsync(joinedStudentsDatas);
                break;
            }
        case 2:
            {

                Console.Clear();
                await DataService.WriteStudentNamesAsync(joinedStudentsDatas);
                break;
            }

        case 3:
            {
                Console.Clear();
                await DataService.AddNewStudentsAsync(joinedStudentsDatas.Count, joinedStudentsDatas);
                break;
            }
        case 4:
            {
                Console.Clear();
                await DataService.ModifyStudentsDataAsync(joinedStudentsDatas);
                break;
            }
        case 5:
            {
                Console.Clear();
                await DataService.DeleteStudentsDataAsync(joinedStudentsDatas);
                break;
            }
        case 6:
            {
                Console.Clear();
                await DataService.AddNewSubjectsToExistingStudentsAsync(joinedStudentsDatas);
                break;
            }
        case 7:
            {
                Console.Clear();
                await DataService.DeleteSubjectsAsync(joinedStudentsDatas);
                break;
            }
        case 8:
            {
                Console.Clear();
                await DataService.ModifySubjectAsync(joinedStudentsDatas);
                break;
            }
        case 9:
            {
                Console.Clear();
                await DataService.AddNewMarkAsnyc(joinedStudentsDatas);
                break;
            }
        case 10:
            {
                Console.Clear();
                await DataService.DeleteMarkAsync(joinedStudentsDatas);
                break;
            }
        case 11:
            {
                Console.Clear();
                await DataService.ModifyMarkAsync(joinedStudentsDatas);
                break;
            }
        case 12:
            {
                endOfWork = true;
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
