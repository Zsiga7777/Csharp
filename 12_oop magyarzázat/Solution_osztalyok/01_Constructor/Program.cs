using _01_Constructor;

//paraméter nélküli konstruktor használata példányosításkor
Fruit apple = new Fruit();
apple.Name = "apple";
apple.Calories = 60;
apple.Price = 450;
apple.Importers.Add("abcd");
apple.Importers = new List<string>(); //private set miatt
apple.HasImporters = true; //csak olvasható tulajdonság

Fruit orange = new Fruit
{
    Name = "orange",
    Calories = 90,
    Price = 380
};

//példányosítás paraméteres konstruktorral
Fruit banana = new Fruit("banana", 89, 600);

Fruit gala = new Fruit(apple);