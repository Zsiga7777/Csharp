namespace Osszefoglalo.Models
{
    public class StoredMessage
    {
        public string System { get;  set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string Message { get; set; }

        public StoredMessage() { }

        public StoredMessage(string system, string firstname, string lastname, string mobileNumber, string message) 
        { 
            System = system;
            FirstName = firstname;
            LastName = lastname;
            MobileNumber = mobileNumber;
            Message = message;
        }

        public override string ToString()
        {
            return $"{MobileNumber} - {FirstName} {LastName} ";
        }
    }
}
