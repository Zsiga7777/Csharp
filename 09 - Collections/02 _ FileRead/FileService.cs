public static class FileService
    {
    #region import
    public static async Task<List<Book>> ReadFromFileAsyncMethod1(string fileName)
    {
        List<Book> books = new List<Book>();
        Book book = null;
        string line = string.Empty;
        string[] data = null;

        string path = Path.Combine("source", fileName);

        using FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None, 128);
        using StreamReader sr = new StreamReader(fs, Encoding.UTF7);

        while (!sr.EndOfStream)
        {
            line = await sr.ReadLineAsync();
            data = line.Split('\t');

            book = new Book();
            book.AuthorFirstName = data[0];
            book.AuthorLastName = data[1];
            book.BirthDate = DateTime.Parse(data[2]);
            book.Title = data[3];
            book.ISBN = data[4];
            book.Distributor = data[5];
            book.ReleaseYear =int.Parse( data[6]);
            book.Price =int.Parse( data[7]);
            book.Theme = data[8];
            book.NumberOfPages =int.Parse( data[9]);
            book.Honorary = int.Parse(data[10]);
            books.Add(book);
        }
        return books;
    }
    #endregion

    #region write
    public static async Task WriteToFileV1Async(string fileName, ICollection<Book> books)
    {
        Directory.CreateDirectory("output");
        string path = Path.Combine("output", $"{fileName}.txt");

        using FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 128);
        using StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);

        foreach (Book book in books)
        {
            await sw.WriteLineAsync($"{book.Title}");
        }
    }

    public static async Task WriteToFileV1Async(string fileName, ICollection<Theme> themes)
    {
        Directory.CreateDirectory("output");
        string path = Path.Combine("output", $"{fileName}.txt");

        using FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 128);
        using StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);

        foreach (Theme theme in themes)
        {
            await sw.WriteLineAsync($"{theme}");
        }
    }
    #endregion
}

