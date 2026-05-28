using LogisticsTrackingSystem.Models;

namespace LogisticsTrackingSystem.Services
{
    public class ShipmentService
    {
        // Active shipments
        public List<Shipment> GetActiveShipments(
            List<Shipment> shipments)
        {
            return shipments
                .Where(x => !x.IsArchived)
                .ToList();
        }

        // Archived shipments
        public List<Shipment> GetArchivedShipments(
            List<Shipment> shipments)
        {
            return shipments
                .Where(x => x.IsArchived)
                .ToList();
        }
    }
}