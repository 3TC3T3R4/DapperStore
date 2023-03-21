using Domain.Entities.Entities;
using Domain.UseCases.Gateway.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.UseCases
{
   public class ClientUseCase
    {

        private readonly IClientRepository _clientRepository;

        public ClientUseCase(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Client> AgregarDirector(Client client)
        {
            return await _clientRepository.InsertClientAsync(client);
        }

        public async Task<Client> InsertarDirectorConKata(Client client)
        {
            return await _clientRepository.InsertClientAsync(client);
        }

        public async Task<Client> ObtenerDirectorPorId(int id)
        {
            return await _clientRepository.GetClientByIdAsync(id);
        }

        public async Task<List<Client>> ObtenerListaDirectores()
        {
            return await _clientRepository.GetAllClientsAsync();
        }






    }
}
