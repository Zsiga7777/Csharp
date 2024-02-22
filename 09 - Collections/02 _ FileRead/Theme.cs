
    public class Theme
    {
     public string ThemeName { get; set; }

    public List<string> ListOfBookTitle { get; set; }

    public Theme() { }

    public Theme(string name, List<string> books) 
    {
        ThemeName = name;
        ListOfBookTitle = books;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(ThemeName);

        foreach (var book in ListOfBookTitle)
        {
            sb.AppendLine($"\t - {book}"); 
        }

        return sb.ToString();
    }
}

