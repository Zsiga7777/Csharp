using Custom.Library.ConsoleExtensions;

const int NUMBEROFSTUDENTS = 3;

Student[] students = GetStudent();

Console.Clear();

int sumOfSavings = students.Sum(s => s.Saving);
Console.WriteLine($"A diákok által összesen megtakarított pénz: {sumOfSavings} Ft");

double averageSaving = students.Average(s => s.Saving);
Console.WriteLine($"\nA diákok által átlagosan megtakarított pénz: {averageSaving:F2} Ft");

int maxSaving = students.Max(s => s.Saving);
Student[] studentsWithLargestSaving = students.Where(s => s.Saving == maxSaving).ToArray();
Console.WriteLine("\nA legtöbb megtakarítással rendelkező tanulók: ");
WriteStudent(studentsWithLargestSaving);

int minSaving = students.Min(s => s.Saving);
Student[] studentsWithLessSaving = students.Where(s => s.Saving == minSaving).ToArray();
Console.WriteLine("\nA legkevesebb megtakarítással rendelkező tanulók: ");
WriteStudent(studentsWithLessSaving);

int numberOfSavingOver2000 = students.Count(s => s.Saving > 2000);
Console.WriteLine($"\nÖsszesen {numberOfSavingOver2000} tanulónak van 2000 Ft feletti megtakarítása: ");

bool studentWithoutSaving = students.Any(s => s.Saving == 0);
Console.WriteLine($"\nVan-e olyan tanuló, akinek nincs megtakarítása: {(studentWithoutSaving ? "igen":"nem")}");

Student[] studentsBelowAverage = students.Where(s => s.Saving < averageSaving).ToArray();
Console.WriteLine("\nAz átlagos megtakarítás alatti diákok: ");
WriteStudent(studentsBelowAverage);

Student[] GetStudent()
{
    Student[] students = new Student[NUMBEROFSTUDENTS];
    int saving = 0;
    string name = "";

    for (int i = 0; i < NUMBEROFSTUDENTS; i++)
    {
        name = ExtendentConsole.ReadString("Kérem a tanuló nevét: ");
        saving = ExtendentConsole.ReadInteger(0, "Kérem a tanuló megtakarításait: ");
        students[i] = new Student(name, saving);
    }

    return students;
}

void WriteStudent(Student[] students)
{
    foreach (var student in students)
    {
        Console.WriteLine(student);
    }
}