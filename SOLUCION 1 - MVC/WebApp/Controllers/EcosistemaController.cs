using Dominio.Dto;
using Dominio.Entidades;
using Dominio.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Servicios;

namespace WebApp.Controllers
{
    public class EcosistemaController : Controller
    {
        private IServicioEcosistema _servicioEcosistema;
        private IServicioEspecie _servicioEspecie;
        private IServicioPais _servicioPais;
        private IServicioEstadoDeConservacion _servicioEstado;
        private IServicioAmenaza _servicioAmenaza;
        private IServicioUbicacionGeografica _servicioUbicacionGeografica;

        public EcosistemaController(IServicioEspecie servicioEspecie, IServicioEcosistema servicioEcosistema, IServicioPais servicioPais, IServicioEstadoDeConservacion servicioEstado, IServicioAmenaza servicioAmenaza, IServicioUbicacionGeografica servicioUbicacionGeografica)
        {
            _servicioEspecie = servicioEspecie;
            _servicioEcosistema = servicioEcosistema;
            _servicioPais = servicioPais;
            _servicioEstado = servicioEstado;
            _servicioAmenaza = servicioAmenaza;
            _servicioUbicacionGeografica = servicioUbicacionGeografica;
        }


        public IActionResult RegistroEcosistema()
        {
            try
            {
                ViewBag.Paises = new SelectList(_servicioPais.GetAll(), "PaisIso", "PaisIso");
                ViewBag.Especies = new SelectList(_servicioEspecie.GetAll(), "EsNombreCientifico", "EsNombreCientifico");
                ViewBag.Estados = new SelectList(_servicioEstado.GetAll(), "ConsId", "ConsValoresNumericos");
                ViewBag.Amenazas = new SelectList(_servicioAmenaza.GetAll(), "AmId", "AmNombre");
            }
            catch (ElementoNoValidoException e)
            {
                TempData["Error"] = e.Message;
            }
            return View();
        }

        [HttpPost]
        public IActionResult RegistrarEcosistema(EcosistemaDto ecosistemaDto)
        {
            try
            {
                EcosistemaDto newEcosistemaDto = _servicioEcosistema.Add(ecosistemaDto);
                TempData["Exito"] = "El ecositema se creo correctamente";
            }
            catch (ElementoNoValidoException e)
            {
                TempData["Error"] = e.Message;
            }
            return RedirectToAction("RegistroEcosistema");
        }

        [HttpPost]
        public IActionResult BorrarEcosistema(EcosistemaDto ecosistemaDto)
        {
            try
            {
                /*_servicioEcosistema.EliminarEnCascada(ecosistemaDto);
                TempData["Exito"] = "El ecositema fue eliminado con exito";
                return RedirectToAction("ListaEcosistema");*/
            }
            catch (ElementoNoValidoException e)
            {
                TempData["Error"] = e.Message;
            }
            return View("ListaEcosistema");
        }

        public IActionResult ListaEcosistema()
        {
            try
            {
                /*foreach (EcosistemaDto e in _servicioEcosistema.GetAll())
                {
                    e.EcUbicacionGeografica = new UbicacionGeografica(_servicioUbicacionGeografica.GetById(e.EcUbicacionGeograficaId));

                }
                ViewBag.Ecosistemas = _servicioEcosistema.GetAll();*/

            }
            catch (ElementoNoValidoException e)
            {
                //view bag con el error lindo para mostrar en la vista
            }

            return View();
        }



    }
}





