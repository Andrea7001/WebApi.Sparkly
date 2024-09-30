using WebApi.Sparkly.Models;

public interface ICitaService
{
    Task<IEnumerable<Cita>> GetCitas();

    Task<Cita> GetCitaById(int id);

    Task<IEnumerable<Cita>> GetCitasByUsuario(int idUsuario);

    Task CrearCitaAsync(int idUsuario1, int idUsuario2, string fechaCita, string Estado);

      Task UpdateCita(Cita cita); // Método para actualizar una cita
    Task DeleteCita(int id);
}
