
public class Mage : Champion, ICast
{
    public Enum Caste = CasteEnum.mage;

    public string Guild {  get; set; }
    public Mage(string name, string guild) : base(name)
    {
        Guild = guild;
        SetStats();
    }

    public override void GetChill() => SetStats();

    private void SetStats()
    {
        HP = Rnd.Next(450, 550);
        Mana = Rnd.Next(600, 800);
        Armor = Rnd.Next(10, 20);
        MagicResistance = Rnd.Next(60, 90);
        Power = Rnd.Next(70, 250);
    }

    public void HokusPokus()
    {
        Power *= 2;
        Armor += 20;
        MagicResistance += 20;
    }
}

