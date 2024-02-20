public class Book
    {
       public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Title { get; set; }   

        public string ISBN { get; set; }

        public string Distributor { get; set; }

        public int ReleaseYear { get; set; }

        public int Price { get; set; }

        public string Theme { get; set; }

        public int NumberOfPages { get; set; }
        
        public int Honorary { get; set; }

        public Book() { }

        public Book(string authorFirstName, string authorLastName, DateTime birthdate, string title, string isbn, string distributor, int releasYear, 
            int price, string theme, int numberOfPages, int honorary) 
        { 
            AuthorFirstName = authorFirstName;
            AuthorLastName = authorLastName;
            BirthDate = birthdate;
            Title = title;
            ISBN = isbn;
            Distributor = distributor;
            ReleaseYear = releasYear;
            Price = price;
            Theme = theme;
            NumberOfPages = numberOfPages;
            Honorary = honorary;
        }

    public override string ToString()
    {
        return $"{Title} - {ReleaseYear} : {AuthorFirstName} {BirthDate}";
    }
}

