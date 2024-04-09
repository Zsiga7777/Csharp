namespace BeerApp
{
    public static class Menu
    {
        public static async void Main()
        {
            int id = ExtendentConsole.ReadInteger("Adja meg a sör azonososítóját: ");

            Beer beer = await BeerService.GetByIdAsync(id);

            beer.WriteToConsole();
        }
    }


}
