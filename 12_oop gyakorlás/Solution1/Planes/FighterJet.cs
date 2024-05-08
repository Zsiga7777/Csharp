
    public class FighterJet : Plane
    {
    public int RocketsCount { get; set; }

    public FighterJet(string model, string type): base(model, type)
    {
        RocketsCount = random.Next(1,10);
    }
    public override void Attack()
    {
        if (RocketsCount == 0)
        {
            Console.WriteLine("kifogyott a rakéta\n");
            return;
        }
        Console.WriteLine("Rakéta kilőve\n");
        RocketsCount--;
    }
}

