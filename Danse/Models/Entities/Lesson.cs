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
        public int ZipCode { get; set; }
        [Required]
        public float Latitude { get; set; }
        [Required]
        public float Longitude { get; set; }

        public virtual Collection<User> Participant { get; set; }
        public virtual User Author {get; set;}
        public virtual Collection<Messenger> Message { get; set; } 
        public virtual Categorie Categorie { get; set; }

    }
}