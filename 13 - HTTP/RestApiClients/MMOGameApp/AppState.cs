namespace MMOGameApp;
    public static class AppState
    {
        private static Game SelectedGame;

    public static void SetGame(Game game)
    { 
        SelectedGame = game;
    }

    public static void Clear() => SelectedGame = null;

    public static Game GetGame() => SelectedGame;

    public static void Update(Game game)
    {
        SelectedGame.Game_url = string.IsNullOrEmpty(game.Game_url) ? SelectedGame.Game_url : game.Game_url;
        SelectedGame.Release_date = string.IsNullOrEmpty(game.Release_date) ? SelectedGame.Release_date : game.Release_date;
        SelectedGame.Publisher = string.IsNullOrEmpty(game.Publisher) ? SelectedGame.Publisher : game.Publisher;
        SelectedGame.Thumbnail = string.IsNullOrEmpty(game.Thumbnail) ? SelectedGame.Thumbnail : game.Thumbnail;
        SelectedGame.Title = string.IsNullOrEmpty(game.Title) ? SelectedGame.Title : game.Title;
        SelectedGame.short_Description = string.IsNullOrEmpty(game.short_Description) ? SelectedGame.short_Description : game.short_Description;
        SelectedGame.Genre = string.IsNullOrEmpty(game.Genre) ? SelectedGame.Genre : game.Genre;
        SelectedGame.Platform = string.IsNullOrEmpty(game.Platform) ? SelectedGame.Platform : game.Platform;
        SelectedGame.Developer = string.IsNullOrEmpty(game.Developer) ? SelectedGame.Developer : game.Developer;
        SelectedGame.Profile_url = string.IsNullOrEmpty(game.Profile_url) ? SelectedGame.Profile_url : game.Profile_url;
    }

    public static int GetId() => SelectedGame.Id;
}

