

namespace Osszefoglalo.Models
{
    public class MessageToSend
    {
        public string Content { get; set; }
        public int System {  get; set; }


        public MessageToSend()
        {
            
        }

        public MessageToSend(string letter, int system)
        {
            Content = letter;
            System = system;
        }
    }


}
