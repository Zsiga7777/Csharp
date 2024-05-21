
public class MilleniumFalcon : Spaceship, IHyperDrive
{
    public int MilleniumGun { get; set; } = Rnd.Next(10, 100);

    public override bool Attack(Spaceship enemyShip )
    {

        if (this.Speed >= enemyShip.Speed)
        {
            if (MilleniumGun > enemyShip.Shield)
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

    public void JumpToHyperSpeed()
    {
        Speed += 10;
    }

    public MilleniumFalcon(string name, Captain captain) : base(name, captain)
    {

    }

    public override string ToString()
    {
        return $"{base.ToString()}, {MilleniumGun}";
    }
}

