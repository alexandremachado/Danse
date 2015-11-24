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
        bool Book(int userId, int lessonId);
        IEnumerable<Lesson> GetFilter(DateTime start, DateTime end, string zip);
        IEnumerable<Lesson> GetLessonByUser(int userid);
        IEnumerable<Lesson> GetLessonByUserInFewTime(int userId);
        IEnumerable<User> GetAllBookByLesson(int id);
        IEnumerable<Lesson> GetLessonByCat(int idcat);
        IEnumerable<Lesson> GetFilterByCat(DateTime start, DateTime end, int idcat);
    }
}