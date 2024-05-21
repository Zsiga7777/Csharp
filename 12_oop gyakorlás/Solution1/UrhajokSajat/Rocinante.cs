
public class Rocinante : Spaceship, IIonDrive
{
    public int LightKeelMountedRailgun { get; set; } = Rnd.Next(10, 100);
    public void JumpToIonSpeed()
    {
        Speed +=5;
    }

    public override bool Attack(Spaceship enemyShip)
    {

        if (this.Speed >= enemyShip.Speed)
        {
            if (LightKeelMountedRailgun > enemyShip.Shield)
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

    public Rocinante(string name, Captain captain) : base(name,captain)
    {
        
    }

    public override string ToString()
    {
        return $"{base.ToString()}, {LightKeelMountedRailgun}";
    }
}

