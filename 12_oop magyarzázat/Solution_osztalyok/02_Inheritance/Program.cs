Processor i7 = new Processor("Intel", "i7", "14700k", 16, 4.2);

Console.WriteLine(i7);

ARMProcessor aRMProcessor = new ARMProcessor();
aRMProcessor.Manufacturer = "arm"; //nem látható

Hardware hardware = new Hardware(); //nem példányosítható az abstract osztály