using Microsoft.AspNetCore.Mvc;
using Dominio.Dto;
using Servicios;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Dominio.Exceptions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Dominio.Entidades;
using Microsoft.AspNetCore.Hosting;
using WebApp.Models;
using Microsoft.CodeAnalysis.Differencing;

namespace WebApp.Controllers
{
    public class EspecieController : Controller 
    {
        private IServicioEcosistema _servicioEcosistema;
        private IServicioAmenaza _servicioAmenaza;
        private IServicioEspecie _servicioEspecie;
        private IServicioEcosistemaEspecie _servicioEcosistemaEspecie;
        private IServicioEstadoDeConservacion _servicioEstado;
        private IWebHostEnvironment _webHostEnvironment;
        private IConfiguration _configuration;
        public EspecieController(IServicioEcosistema servicioEco, IServicioEspecie servicioEspecie, IServicioAmenaza servicioAmenaza, IServicioEstadoDeConservacion servicioEstado, IWebHostEnvironment webHostEnvironment, IConfiguration configuration, IServicioEcosistemaEspecie servicioEcosistemaEspecie)
        {
            _servicioEspecie = servicioEspecie;
            _servicioEcosistema = servicioEco;
            _servicioAmenaza = servicioAmenaza;
            _servicioEstado = servicioEstado;
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
            _servicioEcosistemaEspecie = servicioEcosistemaEspecie;
        }

        public IActionResult EspecieMain()
        {
            try
            {
                //ViewBag.Ecosistemas = new SelectList(_servicioEcosistema.GetAll(), "EcNombre", "EcNombre");
                ViewBag.Amenazas = new SelectList(_servicioAmenaza.GetAll(), "AmId", "AmNombre");
                ViewBag.Estados = new SelectList(_servicioEstado.GetAll(), "ConsId", "ConsNombre");
            }
            catch (ElementoNoEncontradoException e)
            {
                TempData["Error"] = e.Message;
            }

            return View();
        }

        private int ExtraerValor(string clave)
        {
            int valor = 0;
            string strValor = _configuration[clave];
            Int32.TryParse(strValor, out valor);
            return valor;
        }

       /* [HttpPost]
        public IActionResult RegistrarEspecie(EspecieDto especieDto)
        {
            try
            {
                /* EspecieDto newEspecieDto = _servicioEspecie.Add(especieDto);
                 TempData["Exito"] = "La especie fue creada correctamente";*/
             }
             catch (ElementoNoValidoException e)
             {
                 TempData["Error"] = e.Message;
             }

             return RedirectToAction("EspecieMain");
         }*/
         //A partir de aca es todo para LISTAR-CONSULTAR
         public IActionResult ListaEspecie()
         {
             try
             {
                 ViewBag.Especies = _servicioEspecie.GetAll();
                 ViewBag.Ecosistemas = null;
             }
             catch (ElementoNoValidoException e)
             {
                 //view bag con el error lindo para mostrar en la vista
             }

             return View();
         }

         [HttpGet]
         public IActionResult BuscarPorNombreCientifico(string filtroNombre)
         {
             try
             {
                 /*IEnumerable<EspecieDto> especieDtos = _servicioEspecie.GetByNombreCientifico(filtroNombre);
                 ViewBag.Especies = especieDtos.Count() == 0 ? null : especieDtos;
                 ViewBag.Ecosistemas = null;*/
            }
            catch (ElementoNoValidoException e)
            {
                //view bag con el error lindo para mostrar en la vista
            }

            return View("ListaEspecie");
        }
        /*
        [HttpGet]
        public IActionResult BuscarPorEspeciesEnPeligroDeExtincion()
        {
            try
            {
                /*IEnumerable<EspecieDto> especieDtos = _servicioEspecie.GetEspeciesEnPeligroDeExtincion();
                ViewBag.Especies = especieDtos.Count() == 0 ? null : especieDtos;
                ViewBag.Ecosistemas = null;*/
            }
            catch (ElementoNoValidoException e)
            {
                //view bag con el error lindo para mostrar en la vista
            }

            return View("ListaEspecie");
        }

        [HttpGet]
        public ActionResult FotoEspecie(string EsNombreCientifico)
        {
            return View(new MyModel());
        }*/


       /* [HttpPost]
        public ActionResult FotoDEspecie(string EsNombreCientifico, MyModel model)
        {
            string nombreCientifico = ViewBag.NombreCientifico;

            if (model.ImageFile != null && model.ImageFile.Length > 0)
            {
                //extraer nombre y extension
                string fileNameConExtension = Path.GetFileName(model.ImageFile.FileName);
                string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                string fileExt = Path.GetExtension(fileNameConExtension);

                //validar extension
                if (fileExt.ToLower() != ".jpg" && fileExt.ToLower() != ".jpeg")
                {
                    ModelState.AddModelError("ImageFile", "Solo se permiten archivos JPG.");
                    return View(model);
                }
                //armar path de archivo a escribir
                string rutaRaizApp = _webHostEnvironment.WebRootPath;
                rutaRaizApp = Path.Combine(rutaRaizApp, "imagenes");

                string fileNameModificado = fileName + "_001" + fileExt;
                string rutaCompleta = Path.Combine(rutaRaizApp, fileNameModificado);

                //preparar FileStream para Create en el path anterior
                FileStream stream = new FileStream(rutaCompleta, FileMode.Create);

                //grabar el archivo en disco
                model.ImageFile.CopyTo(stream);

                //
                /*EspecieDto especie = _servicioEspecie.GetOneByNombreCientifico(EsNombreCientifico);
                especie.Foto = fileNameModificado;
                _servicioEspecie.Update(EsNombreCientifico, especie);*/

            }


            return RedirectToAction("EspecieMain");

            // redirigir a otra acción o volver a la vista
        }*/


        [HttpGet]
        public IActionResult BuscarEnUnRango(decimal presoMinimo, decimal pesoMaximo)
        {
            try
            {
                /*IEnumerable<EspecieDto> especieDtos = _servicioEspecie.GetByRango(presoMinimo, pesoMaximo);
                ViewBag.Especies = especieDtos.Count() == 0 ? null : especieDtos;
                ViewBag.Ecosistemas = null;*/
            }
            catch (ElementoNoValidoException e)
            {
                //view bag con el error lindo para mostrar en la vista
            }

            return View("ListaEspecie");
        }

        /*  [HttpGet]
        public IActionResult EspeciesQueHabitanEseEcosistema(string filtroNombre)
        {
            try
            {
                /*IEnumerable<EspecieDto> especieDtos = _servicioEspecie.GetByNombreEcosistema(filtroNombre);
                ViewBag.Especies = especieDtos.Count() == 0 ? null : especieDtos;
                ViewBag.Ecosistemas = null;*/
            }
            catch (ElementoNoValidoException e)
            {
                //view bag con el error lindo para mostrar en la vista
            }

            return View("ListaEspecie");
        }*/

        [HttpGet]
        public IActionResult EcosistemasQueNoHabitanUnaEspecie(string filtroNombre)
        {
            try
            {
                /*IEnumerable<EcosistemaDto> ecosistemaDtos = _servicioEcosistema.GetByNombreEspecie(filtroNombre);
                ViewBag.Ecosistemas = ecosistemaDtos.Count() == 0 ? null : ecosistemaDtos;
                ViewBag.Especies = null*/
            }
            catch (ElementoNoValidoException e)
            {
                //view bag con el error lindo para mostrar en la vista
            }

            return View("ListaEspecie");
        }

        public IActionResult AsignaEspecieAEcosistema()
        {
            try
            {
                /*ViewBag.Ecosistemas = new SelectList(_servicioEcosistema.GetAll(), "EcNombre", "EcNombre");
                ViewBag.Especies = new SelectList(_servicioEspecie.GetAll(), "EsNombreCientifico", "EsNombreVulgar");*/
            }
            catch (ElementoNoValidoException e)
            {
                //view bag con el error lindo para mostrar en la vista 
            }

            return View("AsignarEspecieAEcosistema");
        }

        [HttpPost]
        public IActionResult CrearEcosistemaEspecie(EcosistemaEspecie ecosistemaEspecie)
        {
            try
            {
               /* EcosistemaEspecie newEcosistemaEspecie = _servicioEcosistemaEspecie.AddEcosistemaEspecie(ecosistemaEspecie.EsNombreCientifico, ecosistemaEspecie.EcNombre);
                TempData["Exito"] = "La Especie fue asignada correctamente";*/
            }
            catch (ElementoNoValidoException ex)
            {
                TempData["Error"] = ex.Message;
            }

            return RedirectToAction("AsignaEspecieAEcosistema");
        }*/
    }
}
