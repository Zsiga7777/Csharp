
    public class Circle(float radius)
    {
        public float Radius { get; set; } = radius;

    public float Area() => Radius * Radius * MathF.PI;

    public float Perimeter() => 2 * Radius * MathF.PI;


    }

