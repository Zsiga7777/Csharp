


public class Square(float a) : Shape
{
    public  float A { get; set; } = a;

    public override float Area() => A * A;


    public override float Perimeter() => 4 * A;
}
