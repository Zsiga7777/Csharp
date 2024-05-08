

namespace MessageToDifferentSystems
{
    public class Windows : BasicSystem
    {
        public override void SendMessage()
        {
            string convertedMessage = this.Message.ToUpperInvariant();
            Console.WriteLine(convertedMessage);
        }
    }
}
