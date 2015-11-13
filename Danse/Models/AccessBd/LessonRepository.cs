using Danse.Models.Entities;
using Danse.Models.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace Danse.Models.AccessBd
{
    public class LessonRepository : ILessonRepository
    {
        private string connexion = "server=da34191b-e4b4-47a0-8a62-a54e00b8c4d7.mysql.sequelizer.com;database=dbda34191be4b447a08a62a54e00b8c4d7;uid=prphyjdncwgpetdn;pwd=fVbDN7YdpYpoUYH7WQSK4HsXaj3ACfm4gqnkD8FLXGdhg3TosrWCbELEBkCCdxHi";

        public LessonRepository()
        {

        }

        public IEnumerable<Lesson> GetAll()
        {
            string query = "select l.id as id_lesson, description,nb_free,nb_booked,price,title,zip_code,adresse,lat,long,start_date,end_date,u.id as user_id, first_name,last_name,gender,birth_date,email,phone,pwd,image,status,c.name FROM lesson as l JOIN user as u ON u.id = l.user_id JOIN category as c ON c.id = l.category_id";
            List<Lesson> lessons = new List<Lesson>();
            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(connexion, query))
            {
                // Check if the reader returned any rows
                if (reader.HasRows)
                {
                    // While the reader has rows we loop through them,
                    // create new users, and insert them into our list
                    while (reader.Read())
                    {
                        Lesson lesson = new Lesson();
                        User author = new User();
                        Categorie cat = new Categorie();

                        lesson.LessonId = reader.GetInt16(0);
                        lesson.description = reader.GetString(1);
                        lesson.NumberFree = reader.GetInt16(2);
                        lesson.NumberBooked = reader.GetInt16(3);
                        lesson.Price = reader.GetFloat(4);
                        lesson.Title = reader.GetString(5);
                        lesson.ZipCode = reader.GetString(6);
                        lesson.Adresse = reader.GetString(7);
                        lesson.Latitude = reader.GetFloat(8);
                        lesson.Longitude = reader.GetFloat(9);
                        lesson.DateStart = reader.GetDateTime(10);
                        lesson.DateEnd = reader.GetDateTime(11);

                        author.UserId = reader.GetInt16(12);
                        author.FirstName = reader.GetString(13);
                        author.LastName = reader.GetString(14);
                        author.Gender = reader.GetBoolean(15);
                        author.BirthDate = reader.GetDateTime(16);
                        author.Email = reader.GetString(17);
                        author.Phone = reader.GetString(18);
                        author.Password = reader.GetString(19);
                        author.Image = reader.GetString(20);
                        author.Status = reader.GetString(21);

                        cat.name = reader.GetString(22);

                        lesson.Author = author;
                        lesson.Categorie = cat;
                        lessons.Add(lesson);
                    }
                }
            }

            return lessons;
        }

        public Lesson Get(int id)
        {
            
        }

        public Lesson Add(Lesson lesson)
        {
            if (lesson == null)
            {
                throw new ArgumentNullException();
            }

            _store.Lesson.Add(lesson);
            _store.SaveChanges();
            return lesson;
        }

        public void Remove(int id)
        {
            Lesson lesson = new Lesson();
            lesson = _store.Lesson.Where(c => c.LessonId.Equals(id)).FirstOrDefault();
            _store.Lesson.Remove(lesson);
            _store.SaveChanges();
        }

        public bool Update(Lesson lesson)
        {
            if (lesson == null)
            {
                throw new ArgumentNullException();
            }

            Lesson currentLesson = _store.Lesson.Where(c => c.LessonId.Equals(lesson.LessonId)).FirstOrDefault();
            if (currentLesson == null)
            {
                return false;
            }
            _store.Entry(currentLesson).State = System.Data.Entity.EntityState.Modified;
            _store.SaveChanges();
            return true;
        }
    }
}