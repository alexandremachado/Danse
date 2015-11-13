﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Danse.Models.Entities
{
    public class Categorie
    {
        [ScaffoldColumn(false)]
        public int CategorieId { get; set; }
        [Required]
        public string name { get; set; }
    }
}