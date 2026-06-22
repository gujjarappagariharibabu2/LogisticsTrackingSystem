using System.ComponentModel.DataAnnotations;

namespace LogisticsTrackingSystem.Models
{
    public class Shipment
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string TrackingNumber { get; set; }
            = string.Empty;

        [Required]
        [StringLength(100)]
        public string Destination { get; set; }
            = string.Empty;

        public bool IsArchived { get; set; }
        public string Status { get; set; }
              = "Pending";
        public DateTime CreatedDate { get; set; }
             = DateTime.Now;

        public DateTime ExpectedDeliveryDate { get; set; }

         public DateTime? DeliveredDate { get; set; }
         public int? UserId { get; set; }

         public User? User { get; set; }
         
        public string ShipmentCode { get; set; }
             = string.Empty;

    }
}