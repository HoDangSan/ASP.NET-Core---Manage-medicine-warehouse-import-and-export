using MWIE.Models;
using MWIE.Models.Entity;
using MWIE.Repository.GenericRepository;

namespace MWIE.Repository.UserRepository
{
    public class UserRepository : GenericRepository<UserProfile>, IUserRepository
    {
        public UserRepository(MWIEDbContext context) : base(context)
        {
        }
    }
}