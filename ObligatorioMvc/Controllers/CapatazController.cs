using Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Obligatorio_Mariana_Guerra;
using ObligatorioMvc.ViewModels;
using System.Drawing;
using System.Reflection.PortableExecutable;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ObligatorioMvc.Controllers
{
    public class CapatazController : Controller
    {

        Sistema sistema = Sistema.Instancia;
        public IActionResult RegistrarBovino()
        {
            return View();
        }



        public IActionResult AsignarAnimalPotrero()
        {
            var viewModel = new AnimalPotreroView
            {
                Potreros = sistema.GetPotreros(),
                Animales = sistema.GetAnimalesSinPotrero()
            };

            return View(viewModel);
        }


        public IActionResult ListadoPeones()
        {
            List<Peon> peones = sistema.GetPeones();
            return View(peones);
        }

        public IActionResult AsignarTarea()
        {
            var viewModel = new PeonTareaView
            {
                Peones = sistema.GetPeones(),
                Tareas = sistema.GetTodasTareas()

            };
            return View(viewModel);
        }

        public IActionResult ListadoPotreros()
        {
            List<Potrero> potreros = sistema.GetTodosLosPotreros();
            
            return View(potreros);
        }


        public IActionResult CrearTarea()
        {

            return View();
        }

     

        [HttpPost]
        public IActionResult RegistrarBovino(string id, EnumSexo sexo, string raza, DateTime fechaNacimiento, decimal costoAdquisicion,
        decimal costoAlimentacion, double pesoActual, bool hibrido, EnumAlim tipoAlimentacion, decimal precioXKgBovino)
        {
            var Bovino = new Bovino
            {
                _id = id,
                _sexo = sexo,
                _raza = raza,
                _fechaNacimiento = fechaNacimiento,
                _costoAdquisicion = costoAdquisicion,
                _costoAlimentacion = costoAlimentacion,
                _pesoActual = pesoActual,
                _hibrido = hibrido,
                _tipoAlimentacion = tipoAlimentacion,
                _precioXKgBovino = precioXKgBovino
            };

            try
            {
                sistema.AgregarAnimal(Bovino);
                ViewBag.msg = "Agregado correctamente";
                return View();
            }
            catch(Exception e)
            {
                ViewBag.msg = e.Message;
                return View();
            }
        }



        [HttpPost]


        public IActionResult AsignarAnimalPotrero(string animal, int potrero)
        {
            Potrero potActual = sistema.GetPotrero(potrero);
            Animal aniActual = sistema.GetAnimal(animal);

            var viewModel = new AnimalPotreroView
            {
                Potreros = sistema.GetPotreros(),
                Animales = sistema.GetAnimalesSinPotrero(),
            };
                potActual.AsignarAnimal(aniActual);
                ViewBag.msg = "Animal asigando correctamente";
                return View(viewModel);
        }



        [HttpPost]

        public IActionResult AsignarTarea(string email, int id)
        {

            Peon peActual = sistema.GetPeon(email);
            Tarea taActual = sistema.GetTarea(id);

            var viewModel = new PeonTareaView
            {
                Peones = sistema.GetPeones(),
                Tareas = sistema.GetTodasTareas()

            };
            peActual.Asignar(taActual);
            ViewBag.msg = "Tarea asignada correctamente";
            return View(viewModel);
        }


        [HttpPost]
        public IActionResult CrearTarea(string descripcion, DateTime fechaRealizacion, DateTime fechaCierre)
        {
            var tarea = new Tarea
            {

                _descripcion = descripcion,
                _fechaRealizacion = fechaRealizacion,
                _completa = false,
                _fechaCierre = fechaCierre
            };

            bool valido = sistema.ExisteTarea(tarea);
            valido = tarea.EsValido();
            if (valido) {
                sistema.AgregarTarea(tarea);
                return RedirectToAction("AsignarTarea", "Capataz");
            }
            else
            {
                ViewBag.msg = "Datos incorrectos";
                return View();
            }
            
        }

      
        public IActionResult ListadoAnimales()
        {
            
            return View();
           
        }
      
        public IActionResult MostrarListado(double peso, string tipo)
        {
          
            List<Animal> animales = sistema.GetAnimalesXPeso(peso, tipo);
            if (animales.Count() == 0)
            {
                ViewBag.msg = "No existen animales con ese peso";
            }

            return View(animales);

        }
    }
}

