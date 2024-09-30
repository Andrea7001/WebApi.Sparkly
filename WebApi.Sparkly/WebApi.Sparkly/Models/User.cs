using System;

namespace WebApi.Sparkly.Models;

public class User
{
     public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime FechaCumpleanos { get; set; }
        public string Genero { get; set; }
}
