using Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Obligatorio_Mariana_Guerra;
using ObligatorioMvc.ViewModels;
using System.Threading;
namespace ObligatorioMvc.Controllers
{
    public class PeonController : Controller
    {

        Sistema sistema = Sistema.Instancia;

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult RegistroVacunas()
        {
            var viewModel = new RegistroVacunasView
            {
                Vacunas = sistema.GetVacunas(),
                Animales = sistema.GetAnimales(),
            };

            return View(viewModel);
        }


        [HttpPost]
        public IActionResult RegistroVacunas(string vacuna, string animal)
        {
            Vacuna vacActual = sistema.GetVacuna(vacuna);
            Animal aniActual = sistema.GetAnimal(animal);

            var vacunaA = new VacunaAnimal
            {
                _vacuna = vacActual,
                _animal = aniActual,
                _fecha = DateTime.Now
                
            };

            var viewModel = new RegistroVacunasView
            {
                Vacunas = sistema.GetVacunas(),
                Animales = sistema.GetAnimales(),
            };
            try
            {
                sistema.AgregarVacunaAnimal(vacunaA);
                ViewBag.msg = "Vacuna agregada exitosamente";
                return View(viewModel);
            }
            catch(Exception e)
            {
                ViewBag.msg = e.Message;
                return View(viewModel);
            }
          

        }

    
        public IActionResult Datos()
        {
            string logueadoEmail = HttpContext.Session.GetString("EmailAct");
            Peon peonLogueado = sistema.GetPeon(logueadoEmail);
            
            return View(peonLogueado);
        }

        //peon 10
        public IActionResult ListadoTareas()
        {
            // Obtener el peón actual desde donde sea que lo estés recuperando
            Peon peonActual = sistema.GetPeon(HttpContext.Session.GetString("EmailAct"));
            List<Tarea> tareas = sistema.GetTareas(peonActual);
            if (tareas.Count() == 0)
            {
                ViewBag.msg = "No tiene tareas pendientes";
            }
            return View(tareas);
        }


   
        public IActionResult CompletarTarea(int idTarea)
        {
            Tarea tarea = sistema.GetTarea(idTarea);
            return View(tarea);
        }


        [HttpPost]
        public IActionResult CompletarTarea(Tarea tareaActualizada)
        {


            string peonActual = HttpContext.Session.GetString("EmailAct");
            if (string.IsNullOrEmpty(tareaActualizada._comentarioPeon))
            {
                ViewBag.msgError = "Debe ingresar un comentario";
                return View(tareaActualizada);
            }
            tareaActualizada = sistema.GetPeon(peonActual).CompletarUnaTarea(tareaActualizada._id, tareaActualizada._comentarioPeon);
           
            ViewBag.msgOk = "Tarea Actualizada";
            return View(tareaActualizada);

        }

    }
}
