using System.Collections.Generic; // Necesario para List e IEnumerable
using System.Linq; // Necesario para usar Select
using Domain.Entities;

namespace Application.Models
{
    public class ClientDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty;
        public string UserType { get; set; }

        public static ClientDto Create(Client client)
        {
            return new ClientDto
            {
                Id = client.Id,
                Name = client.Name,
                LastName = client.LastName,
                Email = client.Email,
                Username = client.Username,
                Adress = client.Adress,
                UserType = "Client"
            };
        }

        public static List<ClientDto> CreateList(IEnumerable<Client> clients)
        {
            return clients.Select(Create).ToList();
        }
    }
}

