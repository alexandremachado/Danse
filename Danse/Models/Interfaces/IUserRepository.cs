using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Danse.Models.Entities;

namespace Danse.Models.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetPublic(int id);
        User GetPrivate(int id);
        bool Remove(int id);
        bool Update(User user);
        bool Add(User user);
        int GetId(string mail, string pwd);
    }
}