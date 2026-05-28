using LogisticsTrackingSystem.Models;
using LogisticsTrackingSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsTrackingSystem.Controllers
{
    public class ShipmentController : Controller
    {
        private readonly ShipmentService _service = new ShipmentService();

        public IActionResult Active()
        {
            var shipments = new List<Shipment>
            {
                new Shipment
                {
                    Id = 1,
                    TrackingNumber = "TRK100",
                    Destination = "Delhi",
                    IsArchived = false
                },

                new Shipment
                {
                    Id = 2,
                    TrackingNumber = "TRK200",
                    Destination = "Mumbai",
                    IsArchived = true
                }
            };

            var result = _service.GetActiveShipments(shipments);

            return Json(result);
        }
    }
}