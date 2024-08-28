using ProjectModelDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModelDDD.Application.Interface
{
    public interface IClientAppService: IAppServiceBase<Client>
    {
        IEnumerable<Client> GetSpecialClients();
    }
}
