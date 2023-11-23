using Dominio.Dto;
using Dominio.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Servicios;

namespace WebApi.Controllers
{
    public class EspeciesController : Controller

    {
        private IServicioEcosistema _servicioEcosistema;
        private IServicioAmenaza _servicioAmenaza;
        private IServicioEspecie _servicioEspecie;
        private IServicioEcosistemaEspecie _servicioEcosistemaEspecie;
        private IServicioEstadoDeConservacion _servicioEstado;
        private IWebHostEnvironment _webHostEnvironment;
        private IConfiguration _configuration;
        public EspeciesController(IServicioEcosistema servicioEco, IServicioEspecie servicioEspecie, IServicioAmenaza servicioAmenaza, IServicioEstadoDeConservacion servicioEstado, IWebHostEnvironment webHostEnvironment, IConfiguration configuration, IServicioEcosistemaEspecie servicioEcosistemaEspecie)
        {
            _servicioEspecie = servicioEspecie;
            _servicioEcosistema = servicioEco;
            _servicioAmenaza = servicioAmenaza;
            _servicioEstado = servicioEstado;
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
            _servicioEcosistemaEspecie = servicioEcosistemaEspecie;
        }

        
        [HttpPost("/api/especies/registrarEspecies")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult RegistrarEspecie([FromBody] EspecieDto especieDto)
        {
            try
            {
                EspecieDto newEspecieDto = _servicioEspecie.Add(especieDto);
                return Ok(newEspecieDto);
            }
            catch (ElementoNoValidoException ex)
            {
              return BadRequest(ex);
            }

           
        }

        [HttpGet("/api/especies/listarEspecies")]
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
