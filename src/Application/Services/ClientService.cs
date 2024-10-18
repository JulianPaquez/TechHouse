using Application.Models;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;

namespace Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public Client Create(ClientCreateRequest request)
        {
            var newClient = new Client(
            request.Name,
            request.LastName,
            request.UserName,
            request.Email,
            request.Password,
            request.Address
            );
            _clientRepository.Create(newClient);
            return newClient;
        }

        public bool Update(int id, ClientUpdateRequest request)
        {
            var updClient = _clientRepository.GetById(id);
            if (updClient == null)
            {
                return false; 
            }

            updClient.Name = request.Name;
            updClient.LastName = request.LastName;
            updClient.Username = request.UserName;
            updClient.Email = request.Email;
            updClient.Adress = request.Adress;

            _clientRepository.Update(updClient);

            return true; 
        }

        public ClientDto GetById(int id)
        {
            var client = _clientRepository.GetById(id);
            if (client == null)
            {
                return null;
            }
            return new ClientDto
                {
                    Id = client.Id,
                    Name = client.Name,
                    LastName = client.LastName,
                    Username = client.Username,
                    Email = client.Email,
                    Adress = client.Adress,
                    UserType = UserType.Client,
                };
        }

        public List<ClientDto> GetAll()
        {
            var list = _clientRepository.GetAll();
            return ClientDto.CreateList(list);
        }

        public void Delete(int id)
        {
            var client = _clientRepository.GetById(id);
            if (client == null)
            {
                throw new KeyNotFoundException($"Client with Id {id} not found.");
            }

            _clientRepository.Delete(client);
        }
    }

}

