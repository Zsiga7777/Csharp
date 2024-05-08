

namespace MessageToDifferentSystems;
    public class Android : BasicSystem
    {
    public override void SendMessage()
    {
        string convertedMessage = this.Message.ToUpper();
        Console.WriteLine(convertedMessage);
    }
}

