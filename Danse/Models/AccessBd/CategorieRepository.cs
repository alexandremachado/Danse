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
        public CategorieRepository()
        {

        }

        public IEnumerable<Categorie> GetAll()
        {
            return _store.Categorie;
        }

        public Categorie Get(int id)
        {
            return _store.Categorie.Where(u => u.CategorieId.Equals(id)).FirstOrDefault();
        }

        public Categorie Add(Categorie cat)
        {
            if (cat == null)
            {
                throw new ArgumentNullException();
            }

            _store.Categorie.Add(cat);
            _store.SaveChanges();
            return cat;
        }

        public void Remove(int id)
        {
            Categorie cat = new Categorie();
            cat = _store.Categorie.Where(c => c.CategorieId.Equals(id)).FirstOrDefault();
            _store.Categorie.Remove(cat);
            _store.SaveChanges();
        }

    }
}