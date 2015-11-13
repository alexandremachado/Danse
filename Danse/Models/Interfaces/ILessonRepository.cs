using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Danse.Models.Entities;

namespace Danse.Models.Interfaces
{
    public interface ILessonRepository
    {
        IEnumerable<Lesson> GetAll();
        Lesson Get(int id);
        bool Remove(int id);
        bool Update(Lesson user);
        bool Add(Lesson user);
    }
}