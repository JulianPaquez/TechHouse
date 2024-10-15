using System.ComponentModel.DataAnnotations;

namespace Application.Models
{
    public class CredentialsForAuthenticate
    {
    public string UserName {get; set;} = string.Empty;
  
    public string Password {get; set;} = string.Empty;
    }
}