﻿namespace CodigoFacilito.JwtSerilog.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public string Rol { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }
}
