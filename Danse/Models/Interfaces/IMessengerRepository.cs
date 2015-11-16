using Danse.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danse.Models.Interfaces
{
    interface IMessengerRepository
    {
        IEnumerable<Messenger> GetAllByLesson(int lessonId);
        bool Add(Messenger message);
        Messenger Get(int id);
        bool Remove(int id);
        bool Update(Messenger message);
    }
}
