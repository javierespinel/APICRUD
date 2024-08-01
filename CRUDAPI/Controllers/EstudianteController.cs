using CRUDAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {
        public readonly APICRUDContext _dbcontext;

        public EstudianteController(APICRUDContext _context)
        {
            _dbcontext = _context;
        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            List<Estudiante> lista = new List<Estudiante>();
            try
            {
                lista = _dbcontext.Estudiantes.Include(c => c.oIdCurso).ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", Response = lista });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, Response = lista });
            }

        }

        [HttpGet]
        [Route("Obtener/{idEstudiante:int}")]
        public IActionResult Obtener(int idEstudiante)
        {
            Estudiante oEstudiante = _dbcontext.Estudiantes.Find(idEstudiante);

            if (oEstudiante == null)
            {
                return BadRequest("Estudiante no encontrado");
            }

            try
            {
                oEstudiante = _dbcontext.Estudiantes.Include(p => p.oIdCurso).Where(c => c.Id == idEstudiante).FirstOrDefault();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", Response = oEstudiante });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, Response = oEstudiante });
            }

        }

        [HttpPost]
        [Route("Guardar")]

        public IActionResult Guardar([FromBody] Estudiante estudiante)
        {
            try
            {
                _dbcontext.Estudiantes.Add(estudiante);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }

        [HttpPut]
        [Route("Editar")]

        public IActionResult Editar([FromBody] Estudiante objecto)
        {
            Estudiante oEstudiante = _dbcontext.Estudiantes.Find(objecto.NumeroIdentificacion);

            if (oEstudiante == null)
            {
                return BadRequest("Estudiante no encontrado");
            }


            try
            {
                oEstudiante.NumeroIdentificacion = objecto.NumeroIdentificacion is null ? oEstudiante.NumeroIdentificacion : objecto.NumeroIdentificacion;
                oEstudiante.Nombre = objecto.Nombre is null ? oEstudiante.Nombre : objecto.Nombre;
                oEstudiante.Apellido = objecto.Apellido is null ? oEstudiante.Apellido : objecto.Apellido;
                oEstudiante.IdCalificacion = objecto.IdCalificacion is null ? oEstudiante.IdCalificacion : objecto.IdCalificacion;
                oEstudiante.IdCurso = objecto.IdCurso is null ? oEstudiante.IdCurso : objecto.IdCurso;

                _dbcontext.Estudiantes.Update(oEstudiante);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }

        [HttpDelete]
        [Route("Eliminar/{idEstudiante:int}")]
        public IActionResult Eliminar(int idEstudiante)
        {
            Estudiante oEstudiante = _dbcontext.Estudiantes.Find(idEstudiante);

            if (oEstudiante == null)
            {
                return BadRequest("Estudiante no encontrado");
            }

            try
            {
                _dbcontext.Estudiantes.Remove(oEstudiante);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", Response = oEstudiante });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, Response = oEstudiante });
            }

        }
    }
}
