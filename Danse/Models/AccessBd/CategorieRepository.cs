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

        /// <summary>
        /// Récupère toutes les catégories
        /// </summary>
        /// <returns>Retourne toutes les catégories</returns>
        public IEnumerable<Categorie> GetAll()
        {
            string query = "SELECT id,name FROM category";
            List<Categorie> cats = new List<Categorie>();
            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(connexion, query))
            {
                // Check if the reader returned any rows
                if (reader.HasRows)
                {
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

        /// <summary>
        /// Récupère une catégorie
        /// </summary>
        /// <param name="id">id de la catégorie</param>
        /// <returns>La catégorie</returns>
        public Categorie Get(int id)
        {
            string query = "SELECT id,name FROM category WHERE id=" + id;
            Categorie cat = new Categorie();
            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(connexion, query))
            {
                // Check if the reader returned any rows
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        cat.CategorieId = reader.GetInt16(0);
                        cat.Name = reader.GetString(1);
                    }
                }
            }

            return cat;
        }

        /// <summary>
        /// Ajoute une catégorie
        /// </summary>
        /// <param name="cat">Catégorie à ajouter</param>
        /// <returns>Vrai si tous ce passe bien faux sinon</returns>
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

        /// <summary>
        /// Supprime une catégorie
        /// </summary>
        /// <param name="id">Id de la categorie a supprimer</param>
        /// <returns>Vrai si tous ce passe bien faux sinon</returns>
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
}