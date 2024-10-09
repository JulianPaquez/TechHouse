namespace Application.Models
{
    public class ClientUpdateRequest
    {
        public string  Name {get; set;} = string.Empty;
        public string  LastName {get; set;} = string.Empty;
        public string  UserName {get; set;} = string.Empty;
        public string  Email {get; set;} = string.Empty;
        public string  Adress {get; set;} = string.Empty;
    }
}