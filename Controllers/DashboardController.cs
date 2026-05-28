using Microsoft.AspNetCore.Http;
using LogisticsTrackingSystem.Data;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsTrackingSystem.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        
        {

            if (HttpContext.Session.GetString("Role")
                 != "Admin")
             {
                 return RedirectToAction(
                     "Login",
                     "Account");
             }

            ViewBag.TotalShipments =
                _context.Shipments.Count();

            ViewBag.ActiveShipments =
                 _context.Shipments
                     .Count(x => !x.IsArchived);
                    
            ViewBag.ArchivedShipments =
                _context.Shipments
                    .Count(x => x.IsArchived);

            ViewBag.TotalUsers =
                _context.Users.Count();

            ViewBag.OverdueShipments =
                 _context.Shipments.Count(x =>
                     x.ExpectedDeliveryDate < DateTime.Now &&
                     x.Status != "Delivered");

            return View();
        }
    }
}