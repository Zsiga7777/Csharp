
using System.Transactions;

namespace Custom.Library.MathExtensions;

public static partial class MathExtensions
{
    public  static double CelsiusToKelvin(double celsius) => celsius + 273.15;
    

    public static double CelsiusToFahrenheit(double celsius) => (9 / 5 * celsius) + 32;

    public static double PythagoreanTheorem(double a, double b) => Math.Sqrt(Math.Pow((double)(a), 2) + Math.Pow((double)(b), 2));

    public static double BmiIndex(double weight, double height) => weight / (height * height);
    
}
