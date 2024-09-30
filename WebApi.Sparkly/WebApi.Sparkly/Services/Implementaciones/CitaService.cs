using System;
using Microsoft.EntityFrameworkCore;

using WebApi.Sparkly.Context;
using WebApi.Sparkly.Models;

namespace MyApp.Services.Implementaciones
{
    public class CitaService : ICitaService
    {
        private readonly AppDbContext _context;

        public CitaService( AppDbContext context)
        {
            _context = context;
        }

        public async Task<Cita> GetCitaById(int id)
        {
            return await _context.Citas.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Cita>> GetCitas()
        {
            return await _context.Citas.ToListAsync();
        }

        public async Task<IEnumerable<Cita>> GetCitasByUsuario(int idUsuario)
        {
            return await _context.Citas
                                 .Where(c => c.IdUsuario1 == idUsuario || c.IdUsuario2 == idUsuario)
                                 .ToListAsync();
        }

        public async Task CrearCitaAsync(int idUsuario1, int idUsuario2, string fechaCita, string Estado)
        {
            if (idUsuario1 == idUsuario2)
            {
                throw new ArgumentException("Los usuarios no pueden ser el mismo.");
            }

            var nuevaCita = new Cita
            {
                IdUsuario1 = idUsuario1,
                IdUsuario2 = idUsuario2,
                FechaCita = fechaCita,
                Estado = Estado
            };

            _context.Add(nuevaCita);
            await _context.SaveChangesAsync();
        }
         public async Task UpdateCita(Cita cita)
        {
            var existingCita = await _context.Citas.FindAsync(cita.Id);
            if (existingCita == null)
            {
                throw new KeyNotFoundException("Cita no encontrada.");
            }

            // Actualiza los campos de la cita existente
            existingCita.IdUsuario1 = cita.IdUsuario1;
            existingCita.IdUsuario2 = cita.IdUsuario2;
            existingCita.FechaCita = cita.FechaCita; // Asegúrate de que sea un string válido
             existingCita.Estado = cita.Estado;

            _context.Citas.Update(existingCita);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCita(int id)
        {
            var cita = await _context.Citas.FindAsync(id);
            if (cita == null)
            {
                throw new KeyNotFoundException("Cita no encontrada.");
            }

            _context.Citas.Remove(cita);
            await _context.SaveChangesAsync();
        }
    }
}
