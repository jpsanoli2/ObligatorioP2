using Microsoft.AspNetCore.Mvc;
using ObligatorioMvc.Models;
using System.Diagnostics;

namespace ObligatorioMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

       
            public IActionResult Index()
            {
                string? LogueadiId = HttpContext.Session.GetString("EmailAct");

                if (LogueadiId != null)
                {
                    string? NombreLogueado = HttpContext.Session.GetString("NombreAct");
                    ViewBag.msg = NombreLogueado;
                }
                else
                {
                    ViewBag.msg = "Inicie Sesiòn";
                }

                return View();
            }
        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
