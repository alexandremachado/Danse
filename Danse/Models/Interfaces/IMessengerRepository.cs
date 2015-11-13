using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Danse.Models.Entities;

namespace Danse.Models.Interfaces
{
    public interface IMessengerRepository
    {
        IEnumerable<Messenger> GetAll();
        Messenger Get(int id);
        bool Remove(int id);
        bool Update(Messenger user);
        bool Add(Messenger user);
    }
}