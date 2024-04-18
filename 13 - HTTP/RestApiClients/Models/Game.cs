
namespace Models
{
    public class Game
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("thumbnail")]
        public string Thumbnail {  get; set; }

        [JsonPropertyName("short_description")]
        public string short_Description { get; set; }

        [JsonPropertyName("game_url")]
        public string Game_url { get; set; }

        [JsonPropertyName("genre")]
        public string Genre { get; set; }

        [JsonPropertyName("platform")]
        public string Platform { get; set; }

        [JsonPropertyName("publisher")]
        public string Publisher { get; set; }

        [JsonPropertyName("developer")]
        public string Developer { get; set; }

        [JsonPropertyName("release_date")]
        public string Release_date { get; set; }

        [JsonPropertyName("profile_url")]
        public string Profile_url { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"id: {Id}");
            sb.AppendLine($"title: {Title}");
            sb.AppendLine($"thumbnail: {Thumbnail}");
            sb.AppendLine($"short description: {short_Description}");
            sb.AppendLine($"game url: {Game_url}");
            sb.AppendLine($"genre: {Genre}");
            sb.AppendLine($"platform: {Platform}");
            sb.AppendLine($"publisher: {Publisher}");
            sb.AppendLine($"developer: {Developer}");
            sb.AppendLine($"release date: {Release_date}");
            sb.AppendLine($"profile url: {Profile_url}");
            return sb.ToString();
        }
    }
}
