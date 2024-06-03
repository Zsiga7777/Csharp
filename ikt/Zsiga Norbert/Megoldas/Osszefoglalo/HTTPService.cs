
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Net.Http.Headers;
using Osszefoglalo.Models;
using System.Net.Mime;
using System.Text;
using System.IO.Compression;

namespace Osszefoglalo
{
    public class HTTPService
    {
        private static HttpClient httpClient;
        private static JsonSerializerOptions options;
        private const string baseURL = "https://localhost:7112";

        static HTTPService()
        {
            httpClient = new HttpClient();
            SetHeaders();

            options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            };
        }

        private static void SetHeaders()
        {
            httpClient.BaseAddress ??= new Uri(baseURL);

            if (!httpClient.DefaultRequestHeaders.Any())
            {
                httpClient.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
                httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");

                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("plain/text"));
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
        }
        public static async Task<Response> SendPostRequestAsync(string route, object body)
        {
            try
            {
                var request = BuildRequestMessage(HttpMethod.Post, route, body);

                var response = await httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var content = await SerializeResponseAsync(response.Content);
                return content;
            }
            catch (Exception ex)
            {
                return default;
            }
        }

        private static HttpRequestMessage BuildRequestMessage(HttpMethod httpMethod, string route, object body)
        {
            return new HttpRequestMessage
            {
                Method = httpMethod,
                RequestUri = BuildUri(route),
                Content = body is not null ?
                          new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, MediaTypeNames.Application.Json) :
                          null
            };
        }

        private static Uri BuildUri(string route) => new Uri($"{baseURL}/{route}");

        public static async Task<Response> SerializeResponseAsync(HttpContent content)
        {
            var encoding = content.Headers.ContentEncoding.FirstOrDefault();
            var responseStream = await content.ReadAsStreamAsync();
            var stream = encoding switch
            {
                "gzip" => new GZipStream(responseStream, CompressionMode.Decompress),
                "deflate" => new DeflateStream(responseStream, CompressionMode.Decompress),
                "br" => new BrotliStream(responseStream, CompressionMode.Decompress),
                _ => responseStream

            };

            var result = JsonSerializer.Deserialize<Response>(stream, options);
            return result;
        }
    }
}
