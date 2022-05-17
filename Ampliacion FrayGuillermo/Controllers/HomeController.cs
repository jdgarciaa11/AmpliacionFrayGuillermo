using Ampliacion_FrayGuillermo.Models;
using Ampliacion_FrayGuillermo.Models.Entities;
using Ampliacion_FrayGuillermo.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ampliacion_FrayGuillermo.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomeController
        public IActionResult Index()
        {
            ActionResult actionResult;
            try
            {
                actionResult = View(new clsIndexVM());
            } catch (Exception)
            { 
                actionResult = View("Error");
            }
            return actionResult;
        }
        
        [HttpPost]
        public IActionResult Index(int[] idPlantas, int idCategoria)
        {
            try
            {
                clsGestoraPlantas.editarPlantasCategoria(idPlantas, idCategoria);
                return RedirectToAction("Index", new { resultado = "Plantas editadas con éxito." });
            }
            catch
            {
                return View("Error");
            }
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
