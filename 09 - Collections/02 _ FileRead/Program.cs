List<Book> books =await FileService.ReadFromFileAsyncMethod1("adatok.txt");

// Írjuk ki a képernyőre az össz adatot
books.WriteCollectionToConsole();

// Keressük ki az informatika témajú könyveket és mentsük el őket az informatika.txt állömányba
List<Book> itThemedBooks = books.Where(b => b.Theme.ToLower() == "informatika").ToList();
FileService.WriteToFileV1Async("informatika", itThemedBooks);


//Az 1900.txt állományba mentsük el azokat a könyveket amelyek az 1900-as években íródtak
List<Book> booksFrom1900 = books.Where(b => b.ReleaseYear >= 1900 && b.ReleaseYear < 2000).ToList();
FileService.WriteToFileV1Async("1900", booksFrom1900);

//Rendezzük az adatokat a könyvek oldalainak száma szerint csökkenő sorrendbe és a sorbarakott.txt állományba mentsük el.
List<Book> orderedList = books.OrderByDescending(b => b.NumberOfPages).ToList();
FileService.WriteToFileV1Async("sorbarakott", orderedList);

//„kategoriak.txt” állományba mentse el a könyveket téma szerint. Például:
//Thriller:
//-könnyv1
//- könnyv2
//Krimi:
//-könnyv1
//- könnyv2

List<Theme> booksOrderedByThemes = books.GroupBy(b => b.Theme)
    .Select(b => new Theme
    {
        ThemeName = b.Key,
        ListOfBook = b.Select(b => b.Title).ToList()
    })
    .ToList();
FileService.WriteToFileV1Async("kategoriak", booksOrderedByThemes);