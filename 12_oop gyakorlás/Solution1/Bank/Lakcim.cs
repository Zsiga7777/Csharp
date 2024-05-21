
public class Lakcim
    {
    public int Id { get; set; }
    public string Orszag { get; set; }

    public int IranyitoSzam { get; set; }

    public string TelepulesNeve { get; set; }

    public string KozteruletNeve { get; set; }

    public string Hazszam {  get; set; }

    public Lakcim()
    {
        
    }

    public Lakcim(int id, string orszag, int iranyitoSzam, string telepulesNeve, string kozteruletNeve, string hazszam)
    {
        Id = id;
        Orszag = orszag;
        IranyitoSzam = iranyitoSzam;
        TelepulesNeve = telepulesNeve;
        KozteruletNeve = kozteruletNeve;
        Hazszam = hazszam;
    }

    public override string ToString()
    {
        return $"{Id}, {Orszag}, {IranyitoSzam}, \n{TelepulesNeve}, {KozteruletNeve}, {Hazszam}";
    }
}

