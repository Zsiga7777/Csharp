internal class Movie
{
    public string Name { get; set; }

    public string Director { get; set; }

    public int ReleaseDate { get; set; }

    public string LeadActor { get; set; }

    public int Lenght { get; set; }

    public override string ToString()
    {
        return $"{this.Name} film {this.Director} rendezésében {this.ReleaseDate} jelent meg. {this.LeadActor} a főszereplője és {this.Lenght} perc hosszú";
    }
}

