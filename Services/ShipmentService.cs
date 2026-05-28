using LogisticsTrackingSystem.Models;

namespace LogisticsTrackingSystem.Services
{
    public class ShipmentService
    {
        public List<Shipment> GetActiveShipments(List<Shipment> shipments)
        {
            return shipments
                .Where(x => !x.IsArchived)
                .ToList();
        }
    }
}