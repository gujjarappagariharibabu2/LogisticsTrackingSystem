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
    }
}