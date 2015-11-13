using MySql.Data.MySqlClient;
using Danse.Models.Entities;
using Danse.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Danse.Models.AccessBd
{
    public class CategorieRepository : ICategorieRepository
    {
        private string connexion = "server=da34191b-e4b4-47a0-8a62-a54e00b8c4d7.mysql.sequelizer.com;database=dbda34191be4b447a08a62a54e00b8c4d7;uid=prphyjdncwgpetdn;pwd=fVbDN7YdpYpoUYH7WQSK4HsXaj3ACfm4gqnkD8FLXGdhg3TosrWCbELEBkCCdxHi";
        public CategorieRepository()
        {

        }

        public IEnumerable<Categorie> GetAll()
        {
            string query = "SELECT id,name FROM category";
            List<Categorie> cats = new List<Categorie>();
            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(connexion, query))
            {
                // Check if the reader returned any rows
                if (reader.HasRows)
                {
                    // While the reader has rows we loop through them,
                    // create new users, and insert them into our list
                    while (reader.Read())
                    {
                        Categorie cat = new Categorie();
                        cat.CategorieId = reader.GetInt16(0);
                        cat.Name = reader.GetString(1);
                        cats.Add(cat);
                    }
                }
            }

            return cats;

        }

        public Categorie Get(int id)
        {
            string query = "SELECT id,name FROM category WHERE id="+id;
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
                        cat.CategorieId = reader.GetInt16(0);
                        cat.Name = reader.GetString(1);
                    }
                }
            }

            return cat;
        }

        public bool Add(Categorie cat)
        {
            if (cat == null)
            {
                return false;
            }

            string query = "INSERT INTO category (name) VALUES(@name)";
            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("name", cat.Name));
           

            MySqlHelper.ExecuteNonQuery(connexion, query, parms.ToArray());

            return true;
        }

        public bool Remove(int id)
        {
            if (this.Get(id).Name != null)
            {
                string query = "DELETE FROM category WHERE id =" + id;
                MySqlHelper.ExecuteNonQuery(connexion, query);
                return true;
            }
            return false;
        }
    }