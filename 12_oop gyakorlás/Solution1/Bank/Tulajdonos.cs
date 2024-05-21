
public class Tulajdonos
    {
    public int Id { get; set; }
    public string Name { get; set; }

    public Lakcim Lakcim { get; set; }

    public Tulajdonos() { }

    public Tulajdonos(int id, string name, Lakcim lakcim)
    {
        Id = id;
        Name = name;
        Lakcim = lakcim;
    }

    public override string ToString()
    {
        return $"{Id},{Name},\n {Lakcim} ";
    }
}

