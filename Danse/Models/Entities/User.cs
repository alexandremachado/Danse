using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace Danse.Models.Entities
{
    public class User
    {
        [ScaffoldColumn(false)]
        public int UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public bool Gender { get; set; }
        [Required]
        public DateTime BirthDate { get; set;}
        [Required]
        public string Email { get; set; }
        public string Phone { get; set; }
        [Required]
        public string Password { get; set; }
        public string Image { get; set; }

        public User()
        {

        }


        public User(string first, string last, bool Gender, DateTime BirthDate,string email,string phone,string password, string image )
        {
            this.FirstName = first;
            this.LastName = last;
            this.Gender = Gender;
            this.BirthDate = BirthDate;
            this.Email = email;
            this.Phone = phone;
            this.Password = password;
            this.Image = image;
        }
    }
}