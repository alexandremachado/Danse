using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Danse.Models.Entities
{
    public class Messenger
    {
        [ScaffoldColumn(false)]
        public int MessengerId { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public bool Status { get; set; }

        [Required]
        public int lessonid { get; set; }

        public virtual User Author { get; set; }

        public Messenger()
        {

        }

        public Messenger(string subject, string message,bool status,int lessonid,User author)
        {
            this.Subject = subject;
            this.Message = message;
            this.Status = status;
            this.lessonid = lessonid;
            this.Author = author;
        }
    }
}