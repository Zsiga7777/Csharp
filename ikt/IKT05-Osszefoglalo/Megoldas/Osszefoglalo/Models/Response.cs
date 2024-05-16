

using System.Text.Json.Serialization;

namespace Osszefoglalo.Models
{
    public class Response
    {
        [JsonPropertyName("success")]
        public bool IsSucces { get; set; }

        [JsonPropertyName("errorMessage")]
        public string ErrorMessage { get; set; }

        [JsonPropertyName("dateTime")]
        public DateTime DateTime { get; set; }

        public override string ToString()
        {
            return $"{IsSucces};{ErrorMessage};{DateTime}";
        }
    }

    
}
