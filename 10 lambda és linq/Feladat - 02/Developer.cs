using System.Collections.Generic;

namespace Feladat___02
{
    internal class Developer
    {
        public string DeveloperName { get; set; }

        public ICollection<string> GamesName { get; set; }

        public Developer() { }

        public Developer(string name, ICollection<string> gamesName) { 
        DeveloperName = name;
            GamesName = gamesName;
        
        }
    }
}
