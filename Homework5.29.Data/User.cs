﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Homework5._29.Data
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }        
        public List<Bookmark> Urls { get; set; }

        [JsonIgnore]
        public string PasswordHash { get; set; }
    }   
}
