using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class DailyExpense
    {
    public Days Day { get; set; }

    public int Expense { get; set; }

    public DailyExpense() { }

    public DailyExpense(Days day, int expense) {
    
        this.Day = day;
        this.Expense = expense;
    
    }

    public override string ToString()
    {
        return $"{this.Day} => {this.Expense}";
    }
}

