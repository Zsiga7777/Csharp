
public class Memory : Hardware
    {
    public int Capacity { get; set; }

    public int Frequency { get; set; }

    public Memory() : base()
    { }

    public Memory(string manufacturer, string model, string type, int capacity, int frequency)
        : base(manufacturer, model, type)
    {
        Capacity = capacity;
        Frequency = frequency;
    }
}

