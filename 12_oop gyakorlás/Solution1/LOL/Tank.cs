
public class Tank : Champion, IRage
{
    public Enum Caste = CasteEnum.tank;


    public string Clan {  get; set; }
    public Tank(string name, string clan) : base(name)
    {
        Clan = clan;
        SetStats();
    }

    public override void GetChill() => SetStats();
    private void SetStats()
    {
        HP = Rnd.Next(600, 800);
        Mana = Rnd.Next(300, 400);
        Armor = Rnd.Next(50, 80);
        MagicResistance = Rnd.Next(20, 50);
        Power = Rnd.Next(100, 300);
    }

    public void GoneMad()
    {
        Armor +=50;
        MagicResistance +=50;
    }

    
}

