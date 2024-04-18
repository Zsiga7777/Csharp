
    public class ARMProcessor : Processor 
    {
          public int NumberOfPowerCores { get; set; }

    public int NumberOfEfficientCores { get; set; }

    public ARMProcessor() : base()
    { }

    public ARMProcessor( int numberOfPowerCores, int numberOfEfficientCores) : base()
    {
        NumberOfPowerCores = numberOfPowerCores;
        NumberOfEfficientCores = numberOfEfficientCores;
    }
    public ARMProcessor(int numberOfPowerCores, int numberOfEfficientCores,
        int numberOfCores, double frequency): base(numberOfCores, frequency)
    {
        NumberOfPowerCores = numberOfPowerCores;
        NumberOfEfficientCores = numberOfEfficientCores;
    }
}

