using System;
using System.Collections.Generic;

namespace MyApp.DataAccess.DataAccess
{
    public partial class Users
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ClientId { get; set; }
    }
}
