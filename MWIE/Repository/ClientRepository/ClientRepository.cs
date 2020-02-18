using MWIE.Models;
using MWIE.Models.Entity;
using MWIE.Repository.GenericRepository;

namespace MWIE.Repository.ClientRepository
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        public ClientRepository(MWIEDbContext context) : base(context)
        {
        }
    }
}
