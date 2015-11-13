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
        public UserRepository()
        {

        }

        public IEnumerable<User> GetAll()
        {
            List<User> users = new List<User>();
            string query = "Select id,first_name,last_name,gender,birth_date,email,phone,image,status from user";
            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(connexion, query))
            {
                // Check if the reader returned any rows
                if (reader.HasRows)
                {
                    // While the reader has rows we loop through them,
                    // create new users, and insert them into our list
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
                        user.Status = reader.GetString(8);
                        users.Add(user);
                    }
                }

            }

            return users;
        }

        public User GetPublic(int id)
        {
            User user = new User();
            string query = "Select first_name,last_name,gender,phone,image,status from user where id ="+id;

            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(connexion, query))
            {
                // Check if the reader returned any rows
                if (reader.HasRows)
                {
                    // While the reader has rows we loop through them,
                    // create new users, and insert them into our list
                    while (reader.Read())
                    {
                        user.FirstName = reader.GetString(0);
                        user.LastName = reader.GetString(1);
                        user.Gender = reader.GetBoolean(2);
                        user.Phone = reader.GetString(3);
                        user.Image = reader.GetString(4);
                        user.Status = reader.GetString(5);
                    }
                }
            }

            return user;
        }

        public User GetPrivate(int id)
        {
            User user = new User();
            string query = "Select first_name,last_name,email,gender,phone,image,status from user where id =" + id;

            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(connexion, query))
            {
                // Check if the reader returned any rows
                if (reader.HasRows)
                {
                    // While the reader has rows we loop through them,
                    // create new users, and insert them into our list
                    while (reader.Read())
                    {
                        user.FirstName = reader.GetString(0);
                        user.LastName = reader.GetString(1);
                        user.Email = reader.GetString(2);
                        user.Gender = reader.GetBoolean(3);
                        user.Phone = reader.GetString(4);
                        user.Image = reader.GetString(5);
                        user.Status = reader.GetString(6);
                    }
                }
            }

            return user;
        }

        public bool Add(User user)
        {
            if(user == null)
            {
                return false;
            }
            string query = "INSERT INTO user (first_name,last_name,gender,birth_date,email,phone,pwd,image,status) VALUES (@first_name,@last_name,@gender,@birth,@email,@phone,@pwd,@image,@status)";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("email", user.Email));
            parms.Add(new MySqlParameter("pwd", user.Password));
            parms.Add(new MySqlParameter("gender", user.Gender));
            parms.Add(new MySqlParameter("birth", user.BirthDate));
            parms.Add(new MySqlParameter("phone", user.Phone));
            parms.Add(new MySqlParameter("image", user.Image));
            parms.Add(new MySqlParameter("firstName", user.FirstName));
            parms.Add(new MySqlParameter("lastName", user.LastName));
            parms.Add(new MySqlParameter("status", user.Status));

            MySqlHelper.ExecuteNonQuery(connexion, query, parms.ToArray());


            return true;
        }

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

        public bool Update(User user)
        {
            if(user == null)
            {
                return false;
            }

            string query = "UPDATE user SET first_name=@firstname, last_name=@lastname,gender=@gender,birth_date=@birth,email=@email,phone=@phone,pwd=@pwd,image=@image,status=@status WHERE id=@userid";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("firstname", user.FirstName));
            parms.Add(new MySqlParameter("lastname", user.LastName));
            parms.Add(new MySqlParameter("gender", user.Gender));
            parms.Add(new MySqlParameter("birth", user.BirthDate));
            parms.Add(new MySqlParameter("email", user.Email));
            parms.Add(new MySqlParameter("phone", user.Phone));
            parms.Add(new MySqlParameter("pwd", user.Password));
            parms.Add(new MySqlParameter("image", user.Image));
            parms.Add(new MySqlParameter("status", user.Status));
            parms.Add(new MySqlParameter("userid", user.UserId));

            MySqlHelper.ExecuteNonQuery(connexion, query, parms.ToArray());

            return true;
        }
    }
}