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
            ViewBag.TotalShipments =
                _context.Shipments.Count();

            ViewBag.ActiveShipments =
                _context.Shipments
                    
            ViewBag.ArchivedShipments =
                _context.Shipments
                    .Count(x => x.IsArchived);

            ViewBag.TotalUsers =
                _context.Users.Count();

            return View();
        }
    }
}