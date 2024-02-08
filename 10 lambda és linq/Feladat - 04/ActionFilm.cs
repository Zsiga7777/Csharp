using System;
using System.Collections.Generic;

internal class ActionFilm
    {
    public string Director { get; set; } 

    public List<DateTime> ReleaseYears { get; set; }

    public ActionFilm() { }

    public ActionFilm(string director, List<DateTime> releaseYear)
    {
        Director = director;
        ReleaseYears = releaseYear;
    }
    }

