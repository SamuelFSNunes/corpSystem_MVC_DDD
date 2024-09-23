using ProjectModelDDD.Application.Interface;
using ProjectModelDDD.Domain.Entities;
using ProjectModelDDD.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModelDDD.Application.Services
{
    public class ClientAppService : AppServiceBase<Client>, IClientAppService
    {
        private readonly IClientService _clientService;

        public ClientAppService(IClientService clientService) 
            : base(clientService)
        {
            _clientService = clientService;
        }

        public IEnumerable<Client> GetSpecialClients()
        {
            return _clientService.GetSpecialClients(_clientService.GetAll());
        }
    }
}
