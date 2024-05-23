
public class Archer : Champion, IHide
{
    public Enum Caste = CasteEnum.archer;

public string Dervish {  get; set; }
    public Archer(string name, string dervish) : base(name)
    {
        Dervish = dervish;
        SetStats();
    }


    public override void GetChill() => SetStats();
    private void SetStats()
    {
        HP = Rnd.Next(500, 650);
        Mana = Rnd.Next(400, 500);
        Armor = Rnd.Next(30, 50);
        MagicResistance = Rnd.Next(30, 50);
        Power = Rnd.Next(120, 280);
    }

    public void Hides()
    {
       Power +=70;
    }
}

