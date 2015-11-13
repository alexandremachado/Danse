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
                        lesson.ZipCode = reader.GetInt16(6);
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

                        cat.Name = reader.GetString(22);

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
            string query = "select l.id as id_lesson, description,nb_free,nb_booked,price,title,zip_code,adresse,lat,long,start_date,end_date,u.id as user_id, first_name,last_name,gender,birth_date,email,phone,pwd,image,status,c.name FROM lesson as l JOIN user as u ON u.id = l.user_id JOIN category as c ON c.id = l.category_id WHERE l.id = "+id;
            Lesson lesson = new Lesson();
            User author = new User();
            Categorie cat = new Categorie();
            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(connexion, query))
            {
                // Check if the reader returned any rows
                if (reader.HasRows)
                {
                    // While the reader has rows we loop through them,
                    // create new users, and insert them into our list
                    while (reader.Read())
                    {


                        lesson.LessonId = reader.GetInt16(0);
                        lesson.description = reader.GetString(1);
                        lesson.NumberFree = reader.GetInt16(2);
                        lesson.NumberBooked = reader.GetInt16(3);
                        lesson.Price = reader.GetFloat(4);
                        lesson.Title = reader.GetString(5);
                        lesson.ZipCode = reader.GetInt16(6);
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

                        cat.Name = reader.GetString(22);

                        lesson.Author = author;
                        lesson.Categorie = cat;
                    }
                }
            }

            return lesson;
        }

        public bool Add(Lesson lesson)
        {
            if (lesson == null)
            {
                return false;
            }
            
            string query = "INSERT INTO lesson (description,nb_free,nb_booked,price,user_id,title,category_id,zip_code,address,lat,long,start_date,end_date) VALUES (@description,@free,@booked,@price,@userid,@title,@categoryid,@zipCode,@address,@lat,@long,@startdate,@enddate)";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("description", lesson.description));
            parms.Add(new MySqlParameter("free", lesson.NumberFree));
            parms.Add(new MySqlParameter("booked", lesson.NumberBooked));
            parms.Add(new MySqlParameter("price", lesson.Price));
            parms.Add(new MySqlParameter("userid", lesson.Author.UserId));
            parms.Add(new MySqlParameter("title", lesson.Title));
            parms.Add(new MySqlParameter("categoryid", lesson.Categorie.CategorieId));
            parms.Add(new MySqlParameter("zipCode", lesson.ZipCode));
            parms.Add(new MySqlParameter("address", lesson.Adresse));
            parms.Add(new MySqlParameter("lat", lesson.Latitude));
            parms.Add(new MySqlParameter("long", lesson.Longitude));
            parms.Add(new MySqlParameter("startdate", lesson.DateStart));
            parms.Add(new MySqlParameter("enddate", lesson.DateEnd));

            MySqlHelper.ExecuteNonQuery(connexion, query, parms.ToArray());


            return true;
        }

        public bool Remove(int id)
        {
            
            if (this.Get(id).Title != null)
            {
                string query = "DELETE FROM lesson WHERE id =" + id;
                MySqlHelper.ExecuteNonQuery(connexion, query);
                return true;
            }


            return false;

        }

        public IEnumerable<Lesson> GetFilter(DateTime start,DateTime end, int zip)
        {
            string query = "select l.id as id_lesson, description,nb_free,nb_booked,price,title,zip_code,adresse,lat,long,start_date,end_date,u.id as user_id, first_name,last_name,gender,birth_date,email,phone,image,status,c.name FROM lesson as l JOIN user as u ON u.id = l.user_id JOIN category as c ON c.id = l.category_id WHERE start_date >= "+start+" end_date <= "+end+" AND zip_code = "+zip;
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
                        lesson.ZipCode = reader.GetInt16(6);
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
                        author.Image = reader.GetString(19);
                        author.Status = reader.GetString(20);

                        cat.Name = reader.GetString(21);

                        lesson.Author = author;
                        lesson.Categorie = cat;
                        lessons.Add(lesson);
                    }
                }
            }

            return lessons;
        }

        public bool Update(Lesson lesson)
        {
            if (lesson == null)
            {
                throw new ArgumentNullException();
            }

            string query = "UPDATE lesson SET description = @desc, nb_free=@free,nb_booked=@booked,price=@price,user_id@userid,title=@title,category_id=@categoryid,zip_code=@zip,address=@address,lat=@lat,long=@long,start_date=@start,end_date=@end WHERE id=@idlesson";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("desc", lesson.description));
            parms.Add(new MySqlParameter("free", lesson.NumberFree));
            parms.Add(new MySqlParameter("booked", lesson.NumberBooked));
            parms.Add(new MySqlParameter("price", lesson.Price));
            parms.Add(new MySqlParameter("userid", lesson.Author.UserId));
            parms.Add(new MySqlParameter("title", lesson.Title));
            parms.Add(new MySqlParameter("categoryid", lesson.Categorie));
            parms.Add(new MySqlParameter("zip", lesson.ZipCode));
            parms.Add(new MySqlParameter("address", lesson.Adresse));
            parms.Add(new MySqlParameter("lat", lesson.Latitude));
            parms.Add(new MySqlParameter("long", lesson.Longitude));
            parms.Add(new MySqlParameter("start", lesson.DateStart));
            parms.Add(new MySqlParameter("end", lesson.DateEnd));
            parms.Add(new MySqlParameter("idlesson", lesson.LessonId));

            MySqlHelper.ExecuteNonQuery(connexion, query, parms.ToArray());

            return true;
        }
    }
}