using Microsoft.AspNetCore.Mvc;
using Dominio.Entidades;
using Dominio.Dto;
using Servicios;
using Dominio.Exceptions;


namespace WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {



        private IServicioUsuario _service;
        public UsuariosController(IServicioUsuario service)
        {
            _service = service;
        }

        [HttpPost]      
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Login([FromBody] UsuarioDto loginDto)
        {
            try
            {
                UsuarioDto usuario = _service.Login(loginDto);
                return Ok(usuario);
            }
            catch (Exception le)
            {
                return Unauthorized(le.Message);
            }
        }

        [HttpPost("/api/Usuarios/register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult RegistrarUsuario([FromBody]UsuarioDto registerDto)
        {
            try
            {
                UsuarioDto registerDtoCreated = _service.Add(registerDto);
                return Ok(registerDto);
            }
            /*catch (YaExisteElementoException exception)
            {
                return StatusCode(StatusCodes.Status409Conflict, exception.Message);
            }*/
            catch (ElementoNoValidoException exception)
            {
                return BadRequest(exception.Message);
            }
        }

    }

}
