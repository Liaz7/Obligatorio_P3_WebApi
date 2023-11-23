using Dominio.Dto;
using Dominio.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Servicios;

namespace WebApi.Controllers
{
    public class EcosistemasController : Controller
    {
        private IServicioEcosistema _servicioEcosistema;
        private IServicioEspecie _servicioEspecie;
        private IServicioPais _servicioPais;
        private IServicioEstadoDeConservacion _servicioEstado;
        private IServicioAmenaza _servicioAmenaza;
        private IServicioUbicacionGeografica _servicioUbicacionGeografica;

        public EcosistemasController(IServicioEspecie servicioEspecie, IServicioEcosistema servicioEcosistema, IServicioPais servicioPais, IServicioEstadoDeConservacion servicioEstado, IServicioAmenaza servicioAmenaza, IServicioUbicacionGeografica servicioUbicacionGeografica)
        {
            _servicioEspecie = servicioEspecie;
            _servicioEcosistema = servicioEcosistema;
            _servicioPais = servicioPais;
            _servicioEstado = servicioEstado;
            _servicioAmenaza = servicioAmenaza;
            _servicioUbicacionGeografica = servicioUbicacionGeografica;
        }

        [HttpGet("/api/ecosistemas/listarPaises")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarPaises()
        {
            try
            {
                IEnumerable<PaisDto> newpaisDto = _servicioPais.GetAll();
                return Ok(newpaisDto);
            }
            catch (ElementoNoValidoException ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpGet("/api/ecosistemas/listarEspecies")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarEspecies()
        {
            try
            {
                //ViewBag.Paises = new SelectList(_servicioPais.GetAll(), "PaisIso", "PaisIso");
                IEnumerable<EspecieDto> newEspecieDto = _servicioEspecie.GetAll();
                return Ok(newEspecieDto);
            }
            catch (ElementoNoValidoException ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpGet("/api/ecosistemas/listarEstados")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarEstados()
        {
            try
            {
                //ViewBag.Paises = new SelectList(_servicioPais.GetAll(), "PaisIso", "PaisIso");
                IEnumerable<EstadoDeConservacionDto> newEstadoDto = _servicioEstado.GetAll();
                return Ok(newEstadoDto);
            }
            catch (ElementoNoValidoException ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpGet("/api/ecosistemas/listarAmenazas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult ListarAmenazas()
        {
            try
            {
                //ViewBag.Paises = new SelectList(_servicioPais.GetAll(), "PaisIso", "PaisIso");
                IEnumerable<AmenazaDto> newAmenazaDto = _servicioAmenaza.GetAll();
                return Ok(newAmenazaDto);
            }
            catch (ElementoNoValidoException ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpPost("/api/ecosistemas/registrarEcosistemas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult RegistrarEcosistema([FromBody] EcosistemaDto ecosistemaDto)
        {
            try
            {
                ListarPaises();
                ListarEspecies();
                ListarEstados();
                ListarAmenazas();
                EcosistemaDto newEcosistemaDto = _servicioEcosistema.Add(ecosistemaDto);
                return Ok(newEcosistemaDto);
            }
            catch (ElementoNoValidoException ex)
            {
                return BadRequest(ex);
            }
           
        }

        [HttpDelete("/api/ecosistemas/borrarEcosistemas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult BorrarEcosistema(EcosistemaDto ecosistemaDto)
        {
            try
            {
                _servicioEcosistema.EliminarEnCascada(ecosistemaDto);
                return Ok("Eliminado con exito!");
                
            }
            catch (ElementoNoEncontradoException exception)
            {
                return NotFound(exception);
            }
            
        }

        [HttpGet("/api/ecosistemas/listarEcosistemas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult ListarEcosistemas([FromQuery] EcosistemaDto ecoDto)
        {
            try
            {
                IEnumerable<EcosistemaDto> listEcosistemaDto = _servicioEcosistema.GetAll();
                return Ok(listEcosistemaDto);
            }
            catch (ElementoNoValidoException ex)
            {
                return NotFound(ex);
            }


        }
    }
}
