
    public class Theme
    {
     public string ThemeName { get; set; }

    public List<string> ListOfBook { get; set; }

    public Theme() { }

    public Theme(string name, List<string> books) 
    {
        ThemeName = name;
        ListOfBook = books;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(ThemeName);

        foreach (var book in ListOfBook)
        {
            sb.AppendLine($"\t - {book}"); 
        }

        return sb.ToString();
    }
}

