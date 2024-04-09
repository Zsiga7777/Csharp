namespace Models
{
    public class Beer
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("price")]
        public int Price { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("image")]
        public string Image {  get; set; }

        [JsonPropertyName("rating")]
        public Rating Rating { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Id: {Id}");
            sb.AppendLine($"Name: {Name}");
            sb.AppendLine($"Price: {Price}");
            sb.AppendLine($"Image: {Image}");
            sb.AppendLine($"Rating:");
            sb.AppendLine($"\tAverage: {Rating?.Average}");
            sb.AppendLine($"\tReviews: {Rating?.Reviews}");

            return sb.ToString();
        }
    }
}
