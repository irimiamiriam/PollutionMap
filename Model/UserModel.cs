﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollutionMap.Model
{
    public class UserModel
    {   public int Id { get; set; } 
        public string Nume {  get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime UltimaUtilizare { get; set; }
    }
}
