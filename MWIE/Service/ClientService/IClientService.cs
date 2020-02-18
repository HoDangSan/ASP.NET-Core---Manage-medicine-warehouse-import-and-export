using System.Collections.Generic;
using MWIE.Models.Entity;

namespace MWIE.Service.ClientService
{
    public interface IClientService
    {
        Client GetById(int? id);
        IEnumerable<Client> GetAll();
        void Add(Client client);
        void Delete(int id);
        void Update(Client client);
        void Save();
    }
}
