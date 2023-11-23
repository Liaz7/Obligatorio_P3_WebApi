using Dominio.Dto;
using Dominio.Entidades;
using Dominio.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicios;

namespace WebApp.Controllers
{
    public class UsuarioController : Controller
    {
        private IServicioUsuario _servicioUsuario;

        public UsuarioController(IServicioUsuario servicioUsuario)
        {
            _servicioUsuario = servicioUsuario;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UsuarioDto usuarioDto)
        {
            try
            {
                UsuarioDto newUsuarioDto = _servicioUsuario.Login(usuarioDto);

                HttpContext.Session.SetString("user", usuarioDto.UsuarioAlias);


                return RedirectToAction("NewIndex", "Home");
            }
            catch (ElementoNoValidoException ex)
            {
                TempData["Error"] = ex.Message;
                return View("Login");
            }
        }


        [HttpGet]
        public IActionResult RegistrarUsuario()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegistrarUsuario(UsuarioDto usuarioDto)
        {
            try
            {
                UsuarioDto newUsuarioDto = _servicioUsuario.Add(usuarioDto);
                return RedirectToAction("Index", "Home");
            }
            catch (ElementoNoValidoException e)
            {
                //view bag con el error lindo para mostrar en la vista
            }
            return View();

        }


         public IActionResult Logout()
         {
             HttpContext.Session.Clear();
             return View("Login");
         }

    } 
}
