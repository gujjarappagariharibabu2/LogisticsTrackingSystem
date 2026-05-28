namespace LogisticsTrackingSystem.Models
{
    public class Shipment
    {
        public int Id { get; set; }

        public string TrackingNumber { get; set; }

        public string Destination { get; set; }

        public bool IsArchived { get; set; }
    }
}