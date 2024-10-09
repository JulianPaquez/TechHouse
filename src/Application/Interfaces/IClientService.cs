using Application.Models;
using Domain.Entities;

namespace Application.Services
{
    public interface IClientService
    {
        List<ClientDto> GetAll();
        ClientDto GetById(int id);
        Client Create(ClientCreateRequest request);
        bool Update(int id, ClientUpdateRequest request);
        void Delete(int id);
    }
}