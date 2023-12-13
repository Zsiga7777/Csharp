using Custom.Library.ConsoleExtensions;

DailyExpense[] weeklyExpenses = GetDailyExpenses();
Console.Clear();

Console.WriteLine("A heti kiadások: ");
PrintWeekExpensesToConsole(weeklyExpenses);

int weeklyExpensesSum = weeklyExpenses.Sum(dailyExpense => dailyExpense.Expense);
Console.WriteLine($"\n\nAll weekly expenses: {weeklyExpensesSum}");

DailyExpense DayWithTheLeastExpense = GetDayWithTheLeastExpense(weeklyExpenses);
Console.WriteLine($"\n\nDay with the least expense: {DayWithTheLeastExpense}");

string expenseEqualWith10000 = GetExpensEqualWith(weeklyExpenses);
Console.WriteLine($"\n\n{expenseEqualWith10000} 10000 FT-os kiadási érték");


DailyExpense[] GetDailyExpenses()
{
    DailyExpense[] expenses = new DailyExpense[7];

    string[] weekdays = Enum.GetNames(typeof(Days));

    for (int i = 0; i < 7; i++)
    {
        string day = weekdays[i];
        int expense = ExtendentConsole.ReadInteger(0, int.MaxValue, $"{day}: ");

        expenses[i] = new DailyExpense(Enum.Parse<Days>(day), expense);
    }

    return expenses;
}

void PrintWeekExpensesToConsole(DailyExpense[] expenses)
{ 
foreach (var expense in expenses)
    {
        Console.WriteLine(expense);
    }
}

DailyExpense GetDayWithTheLeastExpense(DailyExpense[] expenses)
{
    

    int leastExpense = expenses.Min(dailyExpense => dailyExpense.Expense);
    DailyExpense DayWithTheLeastExpense = expenses.First(dailyExpense => dailyExpense.Expense == leastExpense);

    return DayWithTheLeastExpense;
}

string GetExpensEqualWith(DailyExpense[] expenses)
{ 
string result = string.Empty;

    foreach (var expense in expenses)
    {
        if (expense.Expense == 10000)
        {
            result = "van";
            break;
        }
        else {
            result = "nincs";
        }
    }
    return result;
}