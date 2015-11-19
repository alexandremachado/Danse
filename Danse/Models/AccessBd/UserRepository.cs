using MySql.Data.MySqlClient;
using Danse.Models.Entities;
using Danse.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;

namespace Danse.Models.AccessBd
{
    public class UserRepository : IUserRepository
    {
        private string connexion = "server=da34191b-e4b4-47a0-8a62-a54e00b8c4d7.mysql.sequelizer.com;database=dbda34191be4b447a08a62a54e00b8c4d7;uid=prphyjdncwgpetdn;pwd=fVbDN7YdpYpoUYH7WQSK4HsXaj3ACfm4gqnkD8FLXGdhg3TosrWCbELEBkCCdxHi";

        /// <summary>
        /// Récupère la liste de tous les utilisateurs
        /// </summary>
        /// <returns>Liste de tous les utilisateurs</returns>
        public IEnumerable<User> GetAll()
        {
            List<User> users = new List<User>();
            string query = "Select id,first_name,last_name,gender,birth_date,email,phone,image from user";
            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(connexion, query))
            {
                // Check if the reader returned any rows
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        User user = new User();
                        user.UserId = reader.GetInt16(0);
                        user.FirstName = reader.GetString(1);
                        user.LastName = reader.GetString(2);
                        user.Gender = reader.GetBoolean(3);
                        user.BirthDate = reader.GetDateTime(4);
                        user.Email = reader.GetString(5);
                        user.Phone = reader.GetString(6);
                        user.Image = reader.GetString(7);
                        users.Add(user);
                    }
                }

            }

            return users;
        }

        /// <summary>
        /// Récupère le profil public d'un utilisateur
        /// </summary>
        /// <param name="id">id de l'utilisateur</param>
        /// <returns>Profil public de l'utilisateur</returns>
        public User GetPublic(int id)
        {
            User user = new User();
            string query = "Select first_name,last_name,gender,phone,image from user where id ="+id;

            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(connexion, query))
            {
                // Check if the reader returned any rows
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        user.FirstName = reader.GetString(0);
                        user.LastName = reader.GetString(1);
                        user.Gender = reader.GetBoolean(2);
                        user.Phone = reader.GetString(3);
                        user.Image = reader.GetString(4);
                    }
                }
            }

            return user;
        }

        /// <summary>
        /// Récupère le profil privé de l'utilisateur
        /// </summary>
        /// <param name="id">id de l'utilisateur</param>
        /// <returns>Profil privé de l'utilisateur</returns>
        public User GetPrivate(int id)
        {
            User user = new User();
            string query = "Select first_name,last_name,email,gender,phone,image from user where id =" + id;

            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(connexion, query))
            {
                // Check if the reader returned any rows
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        user.FirstName = reader.GetString(0);
                        user.LastName = reader.GetString(1);
                        user.Email = reader.GetString(2);
                        user.Gender = reader.GetBoolean(3);
                        user.Phone = reader.GetString(4);
                        user.Image = reader.GetString(5);
                    }
                }
            }

            return user;
        }

        /// <summary>
        /// Ajout d'un utilisateur
        /// </summary>
        /// <param name="user">Utilisateur à ajouter</param>
        /// <returns>Vrai si tous c'est bien passé faux sinon</returns>
        public bool Add(User user)
        {
            if(user == null)
            {
                return false;
            }
            string query = "INSERT INTO user (first_name,last_name,gender,birth_date,email,phone,pwd,image) VALUES (@first_name,@last_name,@gender,@birth,@email,@phone,@pwd,@image)";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("first_name", user.FirstName));
            parms.Add(new MySqlParameter("last_name", user.LastName));
            parms.Add(new MySqlParameter("gender", user.Gender));
            parms.Add(new MySqlParameter("birth", user.BirthDate));
            parms.Add(new MySqlParameter("email", user.Email));
            parms.Add(new MySqlParameter("phone", user.Phone));
            parms.Add(new MySqlParameter("pwd", user.Password));
            parms.Add(new MySqlParameter("image", user.Image));
            

            MySqlHelper.ExecuteNonQuery(connexion, query, parms.ToArray());


            return true;
        }

        /// <summary>
        /// Supprime un utiisateur
        /// </summary>
        /// <param name="id">Id de l'utilisateur à supprimer</param>
        /// <returns>Vrai si tous ce passe bien faux sinon</returns>
        public bool Remove(int id)
        {
            if(this.GetPublic(id).LastName != null)
            {
                string query = "DELETE FROM user WHERE id =" + id;
                MySqlHelper.ExecuteNonQuery(connexion, query);
                return true;
            }

            return false;

        }

        /// <summary>
        /// Mets à jour l'utilisateur
        /// </summary>
        /// <param name="user">Utilisateur à mettre à jour</param>
        /// <returns>Vrai si tous ce passe bien faux sinon</returns>
        public bool Update(User user)
        {
            if(user == null)
            {
                return false;
            }

            string query = "UPDATE user SET first_name=@firstname, last_name=@lastname,gender=@gender,birth_date=@birth,email=@email,phone=@phone,pwd=@pwd,image=@image WHERE id=@userid";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("firstname", user.FirstName));
            parms.Add(new MySqlParameter("lastname", user.LastName));
            parms.Add(new MySqlParameter("gender", user.Gender));
            parms.Add(new MySqlParameter("birth", user.BirthDate));
            parms.Add(new MySqlParameter("email", user.Email));
            parms.Add(new MySqlParameter("phone", user.Phone));
            parms.Add(new MySqlParameter("pwd", user.Password));
            parms.Add(new MySqlParameter("image", user.Image));
            parms.Add(new MySqlParameter("userid", user.UserId));

            MySqlHelper.ExecuteNonQuery(connexion, query, parms.ToArray());

            return true;
        }
    }
}