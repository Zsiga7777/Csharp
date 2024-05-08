
    public class Bomber : Plane
    {
    public int NumberOfBombs { get; set; }

    public Bomber(string model,string type) : base(model,type)
    {
        NumberOfBombs = random.Next(1,200);
    }

    public override void Attack()
    {
        if (NumberOfBombs == 0)
        {
            Console.WriteLine("Nincs bomba\n");
            return;

            
        }
        int droppedBombs = random.Next(1, NumberOfBombs+1);
        Console.WriteLine($"{droppedBombs} bombát dobott le, még maradt {NumberOfBombs - droppedBombs} db\n");
        NumberOfBombs -= droppedBombs;
    }
}

