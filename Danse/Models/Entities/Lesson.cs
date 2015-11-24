using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Danse.Models.Entities
{
    public class Lesson
    {
        [ScaffoldColumn(false)]
        public int LessonId { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public string DateStart { get; set; }
        [Required]
        public string DateEnd { get; set; }
        [Required]
        public int NumberFree{get; set;}
        public int NumberBooked { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Adresse { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        public float Latitude { get; set; }
        [Required]
        public float Longitude { get; set; }

        public int userid { get; set; }

        public int idcat { get; set; }

        public virtual User Author {get; set;}
        public virtual Collection<Messenger> Message { get; set; } 
        public virtual Categorie Categorie { get; set; }

        public Lesson()
        {

        }

        public Lesson(string description, DateTime start,DateTime end, int free,int booked, float price, string title,string adresse, string code, int userid, int  idcat)
        {
            this.description = description;
            this.DateEnd = end.ToString("MM/dd/yyyy HH:mm"); ;
            this.DateStart = start.ToString("MM/dd/yyyy HH:mm"); ;
            this.NumberFree = free;
            this.NumberBooked = booked;
            this.Price = price;
            this.Title = title;
            this.Adresse = adresse;
            this.ZipCode = code;
            this.userid = userid;
            this.idcat = idcat;
        }
    }
}