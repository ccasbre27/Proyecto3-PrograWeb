using Entitites;
using P3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace P3.Controllers
{
    public class HomeController : Controller
    {
        static List<Section> SectionsList = new List<Section>()
        {
            new Section(1, "Graderia de pie", 30000, 70, 25),
            new Section(2, "Gradería sur alta", 40000, 70, 20),
            new Section(3, "Gradería sur baja", 55000, 40, 20),
            new Section(4, "Gradería alta, este y oeste", 120000, 40, 5),
            new Section(5, "Gradería baja, este y oeste", 170000, 40, 5),
            new Section(6, "Plata", 240000, 40, 5),
            new Section(7, "Oro", 285000, 30, 5),
            new Section(8, "Platinum Square", 345000, 20, 0)
        };

        public ActionResult Index()
        {
            TicketViewModel viewModel = new TicketViewModel(SectionsList);

            return View(viewModel);
        }
        
        [HttpGet]
        public JsonResult GetSection(int id)
        {
            return Json(SectionsList.Where(e => e.Id == id).FirstOrDefault(), JsonRequestBehavior.AllowGet);
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BuyTickets(int IndexOfSelectedSection, int QuantityToBuy)
        {
            Result result = new Result();
            
            if (QuantityToBuy > 0)
            {
                // se verifica si se tiene la cantidad disponible de tiquetes que se desean adquirir
                if (SectionsList.Where(e => e.Id == IndexOfSelectedSection).FirstOrDefault().QuantitySeatsAvailable >= QuantityToBuy)
                {
                    // se rebaja el tiquete
                    SectionsList.Where(e => e.Id == IndexOfSelectedSection).FirstOrDefault().QuantitySeatsSold += QuantityToBuy;

                    result = new Result(true, String.Format("Usted ha comprado {0} {1} de la sección {2}.\n¡Gracias por su compra!", QuantityToBuy, QuantityToBuy == 1 ? "boleto" : "boletos", SectionsList.Where(e => e.Id == IndexOfSelectedSection).FirstOrDefault().Name));
                }
                else
                {
                    result = new Result(false, "La cantidad de boletos a comprar es mayor a los disponibles, reduzca la cantidad o seleccione otra sección");
                }
            }
            else
            {
                result = new Result(false, "Debe seleccionar una cantidad mayor a cero");
            }
            
            TempData["Result"] = result;

            return RedirectToAction("Index");
        }
    }
}