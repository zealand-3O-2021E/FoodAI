        using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Library
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        [JsonIgnore] public string Password { get; set; }
        public List<History> Histories { get; set; } = new List<History>();
    }
}

