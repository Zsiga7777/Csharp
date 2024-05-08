internal class Computer
{
    public string Processor { get; set; }
    public string GraphicsCard { get; set; }
    public int MemorySize { get; set; }
    public int StorageCapacity { get; set; }
    public int DisplaySize { get; set; }

    public override string ToString()
    {
        return $"{this.Processor} {this.MemorySize}GB {this.DisplaySize}inch {this.StorageCapacity}GB {this.GraphicsCard}";
    }

}

