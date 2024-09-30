using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Sparkly.Models;


namespace MyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitaController : ControllerBase
    {
        private readonly ICitaService _citaService;

        public CitaController(ICitaService citaService)
        {
            _citaService = citaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cita>>> GetCitas()
        {
            var citas = await _citaService.GetCitas();
            return Ok(citas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cita>> GetCitaById(int id)
        {
            var cita = await _citaService.GetCitaById(id);
            if (cita == null)
            {
                return NotFound();
            }
            return Ok(cita);
        }

        [HttpGet("usuario/{idUsuario}")]
        public async Task<ActionResult<IEnumerable<Cita>>> GetCitasByUsuario(int idUsuario)
        {
            var citas = await _citaService.GetCitasByUsuario(idUsuario);
            return Ok(citas);
        }

        [HttpPost("crear/{idUsuario1}/{idUsuario2}")]
        public async Task<ActionResult> CrearCita(int idUsuario1, int idUsuario2, string fechaCita, string Estado)
        {
            try
            {
                await _citaService.CrearCitaAsync(idUsuario1, idUsuario2, fechaCita,Estado);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
         [HttpPut]
        public async Task<ActionResult> UpdateCita([FromBody] Cita cita)
        {
            try
            {
                await _citaService.UpdateCita(cita);
                return NoContent(); // Retorna 204 No Content en caso de éxito
            }
            catch (KeyNotFoundException)
            {
                return NotFound(); // Retorna 404 si la cita no fue encontrada
            }
            catch (Exception)
            {
                return BadRequest(); // Retorna 400 si hay algún error en la solicitud
            }
        }

        // Método para eliminar una cita
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCita(int id)
        {
            try
            {
                await _citaService.DeleteCita(id);
                return NoContent(); // Retorna 204 No Content en caso de éxito
            }
            catch (KeyNotFoundException)
            {
                return NotFound(); // Retorna 404 si la cita no fue encontrada
            }
            catch (Exception)
            {
                return BadRequest(); // Retorna 400 si hay algún error en la solicitud
            }
        }
    }
}
