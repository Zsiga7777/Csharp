using Custom.Library.ConsoleExtensions;

bool endOfWork = false;
List<Student> students = new List<Student>();
do
{
    Console.WriteLine("A rendszer lehetőségei:\n-liststudents\n-studentadd\n-studentmodify\n-studentdelete\n-subjectadd\n-subjectdelete\n-markadd\n-markdelete\n-markmodify\n-endofwork");
    string input = ExtendentConsole.ReadString("\nKérem válasszon: ");

    switch (input)
    {
        case "liststudents":
            {
                students.WriteCollectionToConsole();
                break;
            }

        case "studentadd":
            {
                students.Add(await DataService.GetNewStudentAsync());
                break;
            }

        case "endofwork":
            {
                endOfWork = true;
                break;
            }
        default :
            {
                Console.WriteLine("Nem adott meg megfelelő parancsot.");
                break;
            }
    }

}
while (!endOfWork);
