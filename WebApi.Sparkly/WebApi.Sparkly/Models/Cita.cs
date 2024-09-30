using System;

namespace WebApi.Sparkly.Models;

 
  public class Cita
{
    public int Id { get; set; }

    public int IdUsuario1 { get; set; }  // Usuario que inicia la cita

    public int IdUsuario2 { get; set; }  // Usuario con quien se tiene la cita

    public string  FechaCita { get; set; }

     public string  Estado { get; set; }

}



