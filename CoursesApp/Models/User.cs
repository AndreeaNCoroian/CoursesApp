using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CoursesApp.Models
{
    public class User
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }

        [JsonIgnore]  //these fields will be ignored when the json file will be build --> the password won't be sent in clear
        public string Password { get; set; }

        public string Token { get; set; }
    }
}
