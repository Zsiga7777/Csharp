
namespace HttpServices
{
    public class MMOGamesService : BaseService
    {
        public static async Task<Dictionary<int, List<Game>>> GetFiveGamesAsnyc(int pageNumber)
        {
            Dictionary<int, List<Game>> games = await SendGetRequestAsync<Dictionary<int, List<Game>>>("api/game/get-five",pageNumber);
            return games;
        }
        public static async Task<Game> GetByIdAsnyc(int id)
        {
            Game game = await SendGetRequestAsync<Game>("api/game/get", id);
            return game;
        }
        public static async Task<ICollection<Game>> GetAllAsnyc()
        {
            List<Game> games = await SendGetRequestAsync<List<Game>>("api/game/get-all");
            return games;
        }

        public static async Task<bool> DeleteByIdAsnyc(int id)
        {
            bool result = await SendDeleteRequestAsync("api/game/delete", id);
            return result;
        }
        public static async Task UpdateAsnyc(Game game)
        {
            await SendPutRequestAsync("api/game/update", game);
            
        }
        public static async Task<Game> PostNewAsnyc(Game game)
        {
            Game result = await SendPostRequestAsync<Game>("api/game/create", game);
            return result;
        }
    }
}
