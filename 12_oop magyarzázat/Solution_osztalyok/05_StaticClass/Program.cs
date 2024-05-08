Student geza = new Student
{
    Name = "Géza"
    //School = ""
    //nem fugg az osztálypéldánytól ezért az objektum nem is állítható az értéke
};

Student bela = new Student
{
    Name = "Béla"
    //School = ""
    //nem fugg az osztálypéldánytól ezért az objektum nem is állítható az értéke
};
Student.School = "Vasvári Pál Szeged";

Console.WriteLine($"{geza.Name} a {Student.School}-ba jár");
Console.WriteLine($"{bela.Name} a {Student.School}-ba jár");

//statikus osztály nem példányosítható
//Teacher teacher = new Teacher();
Teacher.Name = "Hapci Vidor";
Console.WriteLine($"{Teacher.Name} tanít a {Teacher.School} iskolában");

Teacher.School = "Valahol";
Console.WriteLine($"{Teacher.Name} tanít a {Teacher.School} iskolában");