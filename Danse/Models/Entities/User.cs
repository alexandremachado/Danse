using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string Status { get; set; }
    }
}