using Dominio.Dto;
using Dominio.Exceptions;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost("/api/ecosistemas/registrarEcosistemas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult RegistrarEcosistema(EcosistemaDto ecosistemaDto)
        {
            try
            {
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
        public IActionResult ListaEspecie([FromQuery] EspecieDto especieDto)
        {
            try
            {
                IEnumerable<EspecieDto> listEspecieDto = _servicioEspecie.GetAll();
                return Ok(listEspecieDto);
            }
            catch (ElementoNoValidoException ex)
            {
                return NotFound(ex);
            }


        }
    }
}
