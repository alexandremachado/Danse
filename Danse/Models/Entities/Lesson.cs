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
        public DateTime DateStart { get; set; }
        [Required]
        public DateTime DateEnd { get; set; }
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

        public virtual User Author {get; set;}
        public virtual Collection<Messenger> Message { get; set; } 
        public virtual Categorie Categorie { get; set; }

        public Lesson()
        {

        }

        public Lesson(string description, DateTime start,DateTime end, int free,int booked, float price, string title,string adresse, string code,float latitude, float longitude, User author,Collection<Messenger> messages, Categorie cat)
        {
            this.description = description;
            this.DateEnd = end;
            this.DateStart = start;
            this.NumberFree = free;
            this.NumberBooked = booked;
            this.Price = price;
            this.Title = title;
            this.Adresse = adresse;
            this.ZipCode = code;
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Author = author;
            this.Message = messages;
            this.Categorie = cat;
        }
    }
}