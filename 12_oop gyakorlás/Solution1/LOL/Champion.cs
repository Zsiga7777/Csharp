
    public abstract class Champion : IChill
    {
    public Random Rnd {  get; } = new Random();
    public string Name { get; set; }

    public int Power { get;  set; }

    public int HP { get;  set; }

    public int Mana { get;  set; }

    public int Armor { get;  set; }

    public int MagicResistance { get;   set; }

    public bool Attack(Champion enemy) => this.Power > (enemy.MagicResistance + enemy.Armor);

    public abstract void GetChill();
   

    protected Champion(string name)
    {
        Name = name;
       
    }
}

