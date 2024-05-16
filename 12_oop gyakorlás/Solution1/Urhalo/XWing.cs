
public class XWing : LazadoGep, IHiperhajtomu
{
    public XWing(double sebesseg = 150, bool meghibasodhatE = true):base(sebesseg,meghibasodhatE) { }
    public override bool ElkapjaAVonosugar()
    {
        if (MeghibasodhatE && Sebesseg < 10000)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void HiperUgras()
    {
        Random rnd = new Random();
        Sebesseg += rnd.Next(0,100) + rnd.NextDouble();
    }

    public override string ToString()
    {
        return $"X-Wing{base.ToString()}";
    }
}

