
using System.Text;

public class Report
    {
    public List<Error> Errors { get; set; } = new List<Error>();

    public int Success {  get; set; }

    public DateTime Date { get; set; }

    public Report() { }

    public Report(List<Error> errors ,int success, DateTime date) 
    {
        Errors = errors;
        Success = success;
        Date = date;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        foreach (var error in Errors)
        {
            sb.AppendLine(error.ToString());
        }
        sb.AppendLine($"Sikeres küldések száma: {Success}");
        sb.AppendLine($"Dátum: {Date}");

        return sb.ToString();
    }
}

