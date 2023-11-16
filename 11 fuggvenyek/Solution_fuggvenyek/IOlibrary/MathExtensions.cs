
using System.Transactions;

namespace IOlibrary;

public static partial class MathExtensions
{
    public  static double CelsiusToKelvin(double celsius) => celsius + 273.15;
    

    public static double CelsiusToFahrenheit(double celsius) => (9 / 5 * celsius) + 32;
    
}
