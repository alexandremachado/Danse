﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Danse.Models.Entities;

namespace Danse.Models.Interfaces
{
    public interface ICategorieRepository
    {
        IEnumerable<Categorie> GetAll();

    }
}