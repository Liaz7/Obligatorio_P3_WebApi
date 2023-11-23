using Dominio.Dto;
using Dominio.Entidades;
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




        [HttpPost("/api/especies/EnviarregistrarEspecies")]
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

        [HttpGet("/api/especies/listarEspeciesEnUnRango")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult BuscarEnUnRango(decimal esPesoMinimo, decimal esPesoMaximo)
        {
            try
            {
                IEnumerable<EspecieDto> especieDtos = _servicioEspecie.GetByRango(esPesoMinimo, esPesoMaximo);
                return Ok(especieDtos);
            }
            catch (ElementoNoValidoException ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("/api/especies/listarEspeciesQueHabitanEcositema")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult EspeciesQueHabitanEseEcosistema(string nombreEcosistema)
        {
            try
            {
                IEnumerable<EspecieDto> especieDtos = _servicioEspecie.GetByNombreEcosistema(nombreEcosistema);
                return Ok(especieDtos);
            }
            catch (ElementoNoValidoException ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("/api/especies/registrarEcosistemaEspecie")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult CrearEcosistemaEspecie([FromBody] EcosistemaEspecie ecosistemaEspecie)
        {
            try
            {
                EcosistemaEspecie newEcosistemaEspecie = _servicioEcosistemaEspecie.AddEcosistemaEspecie(ecosistemaEspecie.EsNombreCientifico, ecosistemaEspecie.EcNombre);
                return Ok(newEcosistemaEspecie);
            }
            catch (ElementoNoValidoException ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("/api/especies/listarEspecies")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult ListaEspecie(EspecieDto especieDto)
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

        [HttpGet("/api/especies/listarEspeciesEnPeligro")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult BuscarPorEspeciesEnPeligroDeExtincion()
        {
            try
            {
                IEnumerable<EspecieDto> especieDtos = _servicioEspecie.GetEspeciesEnPeligroDeExtincion();
               return Ok(especieDtos);
            }
            catch (ElementoNoValidoException ex)
            {
               return BadRequest(ex);
            }

            
        }

        [HttpGet("/api/especies/listarEspeciesPorNombreCientifico")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult BuscarPorNombreCientifico(string nombreCientifico)
        {
            try
            {
                IEnumerable<EspecieDto> especieDtos = _servicioEspecie.GetByNombreCientifico(nombreCientifico);
                return Ok(especieDtos);
            }
            catch (ElementoNoValidoException ex)
            {
                return NotFound(ex);
            }


        }

        [HttpGet("/api/especies/listarEspeciesPorRango")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult BuscarPorRango(decimal pesoMinimo, decimal pesoMaximo)
        {
            try
            {
                IEnumerable<EspecieDto> especieDtos = _servicioEspecie.GetByRango(pesoMinimo, pesoMaximo);
                return Ok(especieDtos);
            }
            catch (ElementoNoValidoException ex)
            {
                return NotFound(ex);
            }


        }

        [HttpGet("/api/especies/listarEcosistemasEnLosQueNoHabitanUnaEspecie")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult EcosistemasQueNoHabitanUnaEspecie(string nombreEspecie)
        {
            try
            {
                IEnumerable<EcosistemaDto> ecosistemaDtos = _servicioEcosistema.GetByNombreEspecie(nombreEspecie);
                return Ok(ecosistemaDtos);
            }
            catch (ElementoNoValidoException ex)
            {
                return BadRequest(ex);
            }

           
        }


    }
}
