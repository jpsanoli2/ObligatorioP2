using Dominio;
using Microsoft.AspNetCore.Mvc;
using Obligatorio_Mariana_Guerra;

namespace ObligatorioMvc.Controllers
{
    public class EmpleadoController : Controller
    {

        Sistema sistema = Sistema.Instancia;


        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Registrarse()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string contrasenia)  //para iniciar sesion
        {

            if (email != null && contrasenia != null)  //validamos q no este vacio 
            {
                Empleado empleado = sistema.GetEmpleado(email, contrasenia);

                if (empleado == null) 
                {
                    ViewBag.msg = "Los datos son incorrectos";
                    return View();
                }
                else   //si logra iniciar sesion guarda la sesion 
                { 
                    HttpContext.Session.SetString("EmailAct", empleado._email);
                    HttpContext.Session.SetString("ContraseniaAct", empleado._contrasenia);
                    HttpContext.Session.SetString("NombreAct", empleado._nombre);
                    HttpContext.Session.SetString("TipoEmp", empleado.GetType().Name);
                    return RedirectToAction("Index", "Home");
                }
            }
            else  
            {
                ViewBag.msg = "Ingrese sus datos";
                return View();
            }
        }
       
        public IActionResult Logout()  //limpiamos la informacion de la sesion y redirigimos al login
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Registrarse(string email, string contrasenia, string nombre, DateTime fechaIngreso, string esResidente) //registramos un nuevo empleado, de tipo peon porque son los unicos que se pueden registrar
        {
            bool residente = esResidente == "si";

            var peon = new Peon
            {
                _email = email,
                _contrasenia = contrasenia,
                _nombre = nombre,
                _fechaIngreso = fechaIngreso,
                _residente = residente
            };


            try
            {
                sistema.AgregarEmpleado(peon);
                return RedirectToAction("Login", "Empleado");
            }
            catch(Exception ex)
            {
                ViewBag.msg = ex.Message;
                return View();
            }
        }



    }
}
