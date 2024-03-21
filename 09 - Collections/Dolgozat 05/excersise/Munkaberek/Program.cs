List<Employee> employees = await FileService.ReadEmployeesAsync("munkaber.txt");


//2-es feladat

int sumOfEmployeesWeeklyPayment = employees.Sum(x => x.Payment) ;

//3-as feladat
Employee mostWorkedEmployee = employees.MaxBy(x => x.SumOfHours);

//4-es feladat
string fileName = $"fizetes_{DateTime.Now:yyyy-MM}.txt";
await FileService.WriteWeeklySalaryAsync(fileName, employees);

//5-ös feladat
Dictionary<Rating, IEnumerable<string>> ratedEmployees = employees.GroupBy(x => x.Rating)
                                                        .ToDictionary(x => x.Key,
                                                        v => v.Select(s => $"{s.Name} ({s.SumOfHours})")) ;
WriteRatedEmployeesToConsole(ratedEmployees);

//6-os feladat
string mostResourcesNeededProject = employees.GroupBy(x => x.Project)
    .OrderByDescending(x => x.Sum(s => s.Payment))
    .Select(x => x.Key)
    .First();

//Bónusz feladat
int maxWorkedHours = employees.Max(x => x.MostWorkedHours);
List<Employee> mostHoursWorkedEmployees = employees.Where(x => x.MostWorkedHours == maxWorkedHours).ToList();

void WriteRatedEmployeesToConsole(Dictionary<Rating, IEnumerable<string>> ratedEmployees)
{

    foreach (KeyValuePair<Rating, IEnumerable<string>> ratedEmployee in ratedEmployees)
    {
        Console.WriteLine($"{ratedEmployee.Key}:");

        foreach (string employeeName in ratedEmployee.Value)
        {
            Console.WriteLine($"\t- {employeeName}");
        }
    }
}

int GetWeekNumberOfMonth(DateTime date)
{
    date = date.Date;
    DateTime firstMonthDay = new DateTime(date.Year, date.Month, 1);
    DateTime firstMonthMonday = firstMonthDay.AddDays((DayOfWeek.Monday + 7 - firstMonthDay.DayOfWeek) % 7);
    if (firstMonthMonday > date)
    {
        firstMonthDay = firstMonthDay.AddMonths(-1);
        firstMonthMonday = firstMonthDay.AddDays((DayOfWeek.Monday + 7 - firstMonthDay.DayOfWeek) % 7);
    }
    return (date - firstMonthMonday).Days / 7 + 1;
}



