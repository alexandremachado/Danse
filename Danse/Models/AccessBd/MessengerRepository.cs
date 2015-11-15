using Danse.Models.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Danse.Models.AccessBd
{
    public class MessengerRepository
    {
        private string connexion = "server=da34191b-e4b4-47a0-8a62-a54e00b8c4d7.mysql.sequelizer.com;database=dbda34191be4b447a08a62a54e00b8c4d7;uid=prphyjdncwgpetdn;pwd=fVbDN7YdpYpoUYH7WQSK4HsXaj3ACfm4gqnkD8FLXGdhg3TosrWCbELEBkCCdxHi";

        /// <summary>
        /// Réupère un message
        /// </summary>
        /// <param name="id">Id du message à récupérer</param>
        /// <returns>Message</returns>
        public Messenger Get(int id)
        {
            string query = "select id,subject,message,status,lesson_id,u.id,last_name,first_name,image FROM messenger as m JOIN user as u ON u.id = m.user_id WHERE m.id = "+id;
            Messenger message = new Messenger();
            User author = new User();
         
            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(connexion, query))
            {
                // Check if the reader returned any rows
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        message.MessengerId = reader.GetInt16(0);
                        message.Subject = reader.GetString(1);
                        message.Message = reader.GetString(2);
                        message.Status = reader.GetBoolean(3);
                        message.lessonid = reader.GetInt16(4);
                        author.UserId = reader.GetInt16(5);
                        author.LastName = reader.GetString(6);
                        author.FirstName = reader.GetString(7);
                        author.Image = reader.GetString(8);

                        message.Author = author;
                    }
                }
            }

            return message;
        }

        /// <summary>
        /// Retourne tous les messages des lessons
        /// </summary>
        /// <param name="lessonId">L'id de la lesson</param>
        /// <returns>Liste des messages</returns>
        public IEnumerable<Messenger> GetAllByLesson(int lessonId)
        {
            List<Messenger> messages = new List<Messenger>();
            string query = "Select id,subject,message,status,u.id,first_name,last_name,image from messenger as m JOIN user as u ON u.id = m.user_id WHERE lesson_id ="+lessonId;
            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(connexion, query))
            {
                // Check if the reader returned any rows
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Messenger message = new Messenger();
                        User author = new User();
                        message.MessengerId = reader.GetInt16(0);
                        message.Subject = reader.GetString(1);
                        message.Message = reader.GetString(2);
                        message.Status = reader.GetBoolean(3);

                        author.UserId = reader.GetInt16(4);
                        author.LastName = reader.GetString(5);
                        author.FirstName = reader.GetString(6);
                        author.Image = reader.GetString(7);
                       
                        messages.Add(message);
                    }
                }

            }

            return messages;
        }

        /// <summary>
        /// Ajoute un message
        /// </summary>
        /// <param name="message">Message à ajouter</param>
        /// <returns>Vrai si ajouté, faux sinon</returns>
        public bool Add(Messenger message)
        {
            if (message == null)
            {
                return false;
            }
            string query = "INSERT INTO messenger (subject,message,status,user_id,lesson_id) VALUES (@subject,@message,@status,@user,@lesson)";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("subject", message.Subject));
            parms.Add(new MySqlParameter("message", message.Message));
            parms.Add(new MySqlParameter("status", message.Status));
            parms.Add(new MySqlParameter("user_id", message.Author.UserId));
            parms.Add(new MySqlParameter("lesson_id", message.lessonid));

            MySqlHelper.ExecuteNonQuery(connexion, query, parms.ToArray());


            return true;
        }

        /// <summary>
        /// Supprime un message
        /// </summary>
        /// <param name="id">id du message</param>
        /// <returns>Vrai si supprimé, faux sinon</returns>
        public bool Remove(int id)
        {
            if (this.Get(id).Subject != null)
            {
                string query = "DELETE FROM messenger WHERE id =" + id;
                MySqlHelper.ExecuteNonQuery(connexion, query);
                return true;
            }

            return false;

        }

        /// <summary>
        /// Mets à jour un message
        /// </summary>
        /// <param name="user">Message à mettre à jour</param>
        /// <returns>Vrai si réussi, faux sinon</returns>
        public bool Update(Messenger message)
        {
            if (message == null)
            {
                return false;
            }

            string query = "UPDATE messenger SET subject=@subject,message=@message,status=@status WHERE id=@messageid";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("subject", message.Subject));
            parms.Add(new MySqlParameter("message", message.Message));
            parms.Add(new MySqlParameter("status", message.Status));
            parms.Add(new MySqlParameter("messageid", message.MessengerId));

            MySqlHelper.ExecuteNonQuery(connexion, query, parms.ToArray());

            return true;
        }
    }
}