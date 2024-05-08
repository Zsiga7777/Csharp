
namespace MessageToDifferentSystems
{
    
    public abstract class BasicSystem
    {
        public string Message { get; set; }
        public abstract void SendMessage();
        
    }
}
