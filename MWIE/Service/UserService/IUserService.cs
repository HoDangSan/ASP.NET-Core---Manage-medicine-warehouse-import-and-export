using System.Collections.Generic;
using MWIE.Models.Entity;

namespace MWIE.Service.UserService
{
    public interface IUserService
    {
        UserProfile GetById(int? id);
        IEnumerable<UserProfile> GetAll();
        void Add(UserProfile user);
        void Delete(int id);
        void Update(UserProfile user);
        void Save();
    }
}