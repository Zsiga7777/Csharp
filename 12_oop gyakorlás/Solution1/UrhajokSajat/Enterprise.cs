
public class Enterprise : Spaceship, IHyperDrive
{
    public int FotonTorpedos { get; set; } = Rnd.Next(10, 100);
    public void JumpToHyperSpeed()
    {
        Speed += 10;
    }
    public override bool Attack(Spaceship enemyShip)
    {

        if (this.Speed >= enemyShip.Speed)
        {
            if (FotonTorpedos > enemyShip.Shield)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    public Enterprise(string name, Captain captain) : base(name, captain)
    {

    }
    public override string ToString()
    {
        return $"{base.ToString()}, {FotonTorpedos}";
    }
}

