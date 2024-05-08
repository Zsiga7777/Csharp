
namespace MessageToDifferentSystems
{
    public class Ios : BasicSystem
    {
        public override void SendMessage()
        {
            string convertedMessage = this.Message + " almásítva";
            Console.WriteLine(convertedMessage);
        }
    }
}
