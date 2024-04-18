
    public class Truck : Vehicle
    {
    public override void Horn()
    {
        Console.Beep(500, 1000);
    }
    public override void Error()
    {
        for (int i = 0; i < 2; i++)
        {
            Console.Beep(400, 300);

        }
    }
}

