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

        /// <summary>
        /// Récupération de toutes les lessons
        /// </summary>
        /// <returns>Toutes les lessons</returns>
        public IEnumerable<Lesson> GetAll()
        {
            string query = "select l.id as id_lesson, description,nb_free,nb_booked,price,title,zip_code,adresse,lat,long,start_date,end_date,u.id as user_id, first_name,last_name,gender,birth_date,email,phone,pwd,image,status,c.name FROM lesson as l JOIN user as u ON u.id = l.user_id JOIN category as c ON c.id = l.category_id";
            List<Lesson> lessons = new List<Lesson>();
            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(connexion, query))
            {
                // Check if the reader returned any rows
                if (reader.HasRows)
                {
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

        /// <summary>
        /// Récupération d'une lesson
        /// </summary>
        /// <param name="id">Id de la lesson</param>
        /// <returns>Une lesson</returns>
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

        /// <summary>
        /// Ajout d'une lesson
        /// </summary>
        /// <param name="lesson">la lesson à ajouter</param>
        /// <returns>Vrai si tout ce passe bien faux sinon</returns>
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

        /// <summary>
        /// Supprime une lesson
        /// </summary>
        /// <param name="id">id de la lesson à supprimer</param>
        /// <returns>Vrai si tout ce passe bien faux sinon</returns>
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

        /// <summary>
        /// Retourne toute les lessons du même endroit compris entre une date de début et une date de fin
        /// </summary>
        /// <param name="start">Date de début</param>
        /// <param name="end">Date de fin</param>
        /// <param name="zip">Code postal de l'endroit</param>
        /// <returns>Une liste de lesson</returns>
        public IEnumerable<Lesson> GetFilter(DateTime start,DateTime end, int zip)
        {
            string query = "select l.id as id_lesson, description,nb_free,nb_booked,price,title,zip_code,adresse,lat,long,start_date,end_date,u.id as user_id, first_name,last_name,gender,birth_date,email,phone,image,status,c.name FROM lesson as l JOIN user as u ON u.id = l.user_id JOIN category as c ON c.id = l.category_id WHERE start_date >= "+start+" end_date <= "+end+" AND zip_code = "+zip;
            List<Lesson> lessons = new List<Lesson>();
            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(connexion, query))
            {
                // Check if the reader returned any rows
                if (reader.HasRows)
                {
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

        /// <summary>
        /// Retourne la liste d'utilisateur inscrit à la lesson
        /// </summary>
        /// <param name="id">id lesson</param>
        /// <returns>Liste d'utilisateur</returns>
        public IEnumerable<User> GetAllBookByLesson(int id)
        {
            string query = "SELECT u.id,email,image,last_name,first_name from user as u JOIN booking as b ON b.user_id = u.id JOIN lesson as l ON b.lesson_id = l.id WHERE l.id = "+id;

            List<User> users = new List<User>();
            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(connexion, query))
            {
                // Check if the reader returned any rows
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        User user = new User();

                        user.UserId = reader.GetInt16(0);
                        user.Email = reader.GetString(1);
                        user.Image = reader.GetString(2);
                        user.LastName = reader.GetString(3);
                        user.FirstName = reader.GetString(4);
                       
                        users.Add(user);
                    }
                }
            }

            return users;

        }

        /// <summary>
        /// Retourne l'historique des lessons de l'utilisateur
        /// </summary>
        /// <param name="userid">Id utilisateur</param>
        /// <returns>Liste de lesson</returns>
        public IEnumerable<Lesson> GetLessonByUser(int userId)
        {
            UserRepository _repositoryUser = new UserRepository();
            List<Lesson> lessons = new List<Lesson>();
            if (_repositoryUser.GetPublic(userId).FirstName != "")
            {
                string query = "SELECT id,description,price,title,c.name,start_date,end_date,u.id as userid,first_name,last_name,image FROM lesson as l JOIN category as c ON c.id = l.category_id JOIN user as u ON u.id = l.user_id WHERE user_id=" + userId;

                using (MySqlDataReader reader = MySqlHelper.ExecuteReader(connexion, query))
                {
                    // Check if the reader returned any rows
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Lesson lesson = new Lesson();
                            User author = new User();
                            Categorie cat = new Categorie();

                            lesson.LessonId = reader.GetInt16(0);
                            lesson.description = reader.GetString(1);
                            lesson.Price = reader.GetFloat(2);
                            lesson.Title = reader.GetString(3);
                            cat.Name = reader.GetString(4);
                            lesson.DateStart = reader.GetDateTime(5);
                            lesson.DateEnd = reader.GetDateTime(6);

                            author.UserId = reader.GetInt16(7);
                            author.FirstName = reader.GetString(8);
                            author.LastName = reader.GetString(9);
                            author.Image = reader.GetString(10);

                            lesson.Author = author;
                            lesson.Categorie = cat;
                            lessons.Add(lesson);
                        }
                    }
                }
            }
            return lessons;
        }

        /// <summary>
        /// Ajoute un utilisateur à la lesson
        /// </summary>
        /// <param name="userId">Id utilisateur</param>
        /// <param name="lessonId">Id de la lesson</param>
        /// <returns>Vrai si tout c'est bien passer, fauw sinon</returns>
        public bool Book(int userId, int lessonId)
        {
            UserRepository _repositoryUser = new UserRepository();
            if(_repositoryUser.GetPublic(userId).FirstName != "" && this.Get(lessonId).Title != "")
            {
                //We add the user in the lesson
                string query = "INSERT INTO booking (user_id,lesson_id) VALUES (@user,@lesson)";

                List<MySqlParameter> parms = new List<MySqlParameter>();
                parms.Add(new MySqlParameter("user", userId));
                parms.Add(new MySqlParameter("lesson", lessonId));

                MySqlHelper.ExecuteNonQuery(connexion, query, parms.ToArray());

                //We update the nb_free and nb_booked
                string queryIncrementeLesson = "UPDATE lesson SET nb_free-=1, nb_booked+=1 WHERE id=@lessonid";
                List<MySqlParameter> parmsIncre = new List<MySqlParameter>();
                parmsIncre.Add(new MySqlParameter("lessonid", lessonId));

                MySqlHelper.ExecuteNonQuery(connexion, queryIncrementeLesson, parmsIncre.ToArray());


                return true;
            }
            return false;
        }

        /// <summary>
        /// Mets à jour une lesson (le prix ne peut pas être mis à jour
        /// </summary>
        /// <param name="lesson">Lesson à modifier</param>
        /// <returns>Vrai si la modification c'est bien passé, faux sinon</returns>
        public bool Update(Lesson lesson)
        {
            if (lesson == null)
            {
                throw new ArgumentNullException();
            }

            string query = "UPDATE lesson SET description = @desc, nb_free=@free,nb_booked=@booked,user_id@userid,title=@title,category_id=@categoryid,zip_code=@zip,address=@address,lat=@lat,long=@long,start_date=@start,end_date=@end WHERE id=@idlesson";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("desc", lesson.description));
            parms.Add(new MySqlParameter("free", lesson.NumberFree));
            parms.Add(new MySqlParameter("booked", lesson.NumberBooked));
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

        /// <summary>
        /// Récupère toutes les lessons à venir d'un utilisateur
        /// </summary>
        /// <param name="userId">l'id de l'utilisateur</param>
        /// <returns>Les lessons à venir de l'utilisateur</returns>
        public IEnumerable<Lesson> GetLessonByUserInFewTime(int userId)
        {
            UserRepository _repositoryUser = new UserRepository();
            List<Lesson> lessons = new List<Lesson>();
            if (_repositoryUser.GetPublic(userId).FirstName != "")
            {
                string query = "SELECT id,description,price,title,c.name,start_date,end_date,u.id as userid,first_name,last_name,image FROM lesson as l JOIN category as c ON c.id = l.category_id JOIN user as u ON u.id = l.user_id WHERE user_id=" + userId+" start_date>="+DateTime.Now;

                using (MySqlDataReader reader = MySqlHelper.ExecuteReader(connexion, query))
                {
                    // Check if the reader returned any rows
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Lesson lesson = new Lesson();
                            User author = new User();
                            Categorie cat = new Categorie();

                            lesson.LessonId = reader.GetInt16(0);
                            lesson.description = reader.GetString(1);
                            lesson.Price = reader.GetFloat(2);
                            lesson.Title = reader.GetString(3);
                            cat.Name = reader.GetString(4);
                            lesson.DateStart = reader.GetDateTime(5);
                            lesson.DateEnd = reader.GetDateTime(6);

                            author.UserId = reader.GetInt16(7);
                            author.FirstName = reader.GetString(8);
                            author.LastName = reader.GetString(9);
                            author.Image = reader.GetString(10);

                            lesson.Author = author;
                            lesson.Categorie = cat;
                            lessons.Add(lesson);
                        }
                    }
                }
            }
            return lessons;
        }
    }
}