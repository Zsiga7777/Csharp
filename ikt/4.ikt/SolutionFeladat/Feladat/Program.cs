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
   
    Console.WriteLine("A rendszer lehetőségei:");
    int input = DataService.ReusableMenu(["Tanuló adat kiírása", "Tanulók neveinek kiírása", "Tanulók hozzáadása", "Tanulók módosítása",
        "Tanulók törlése","Jegyek hozzáadása", "Jegyek törlése", 
        "Jegyek módosítása","Mentés és kilépés"]);

    switch (input)
    {
        case 0:
            { 
                Console.Clear(); 
                DataService.WriteStudentData(joinedStudentsDatas);
                break;
            }
        case 1:
            {

                Console.Clear();
                DataService.WriteStudentNames(joinedStudentsDatas);
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
                DataService.ModifyStudentsData(joinedStudentsDatas);
                break;
            }
        case 4:
            {
                Console.Clear();
                DataService.DeleteStudentsData(joinedStudentsDatas);
                break;
            }
        case 5:
            {
                Console.Clear();
                DataService.AddNewSubjectsToExistingStudents(joinedStudentsDatas);
                break;
            }
        case 6:
            {
                Console.Clear();
                DataService.DeleteSubjects(joinedStudentsDatas);
                break;
            }
        case 7:
            {
                Console.Clear();
                DataService.ModifySubject(joinedStudentsDatas);
                break;
            }
        case 8:
            {
                Console.Clear();
                DataService.AddNewMark(joinedStudentsDatas);
                break;
            }
        case 9:
            {
                Console.Clear();
                DataService.DeleteMark(joinedStudentsDatas);
                break;
            }
        case 10:
            {
                Console.Clear();
                DataService.ModifyMark(joinedStudentsDatas);
                break;
            }
        case 11:
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
