using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Danse.Models.Entities
{
    public class Booking
    {
        public int user_id;
        public int lesson_id;
        
        public Booking()
        {

        } 

        public Booking(int iduser, int idlesson)
        {
            this.user_id = iduser;
            this.lesson_id = idlesson;
        }
    }
}