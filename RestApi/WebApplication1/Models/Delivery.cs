using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Delivery
    {
        public int Id { get; set; }
        [Required]
        public Coordinates OriginCoordinates { get; set; }
        [Required]
        public string OriginContactName { get; set; }
        [Required]
        [Phone]
        public string OriginPhoneNumber { get; set; }
        [Required]
        public Coordinates DestinationCoordinates { get; set; }
        [Required]
        public string DestinationContactName { get; set; }
        [Required]
        [Phone]
        public string DestinationPhoneNumber { get; set; }
        [Required]
        public List<DeliveryItem> DeliveryItems { get; set; }


        public void GenerateId(List<Delivery> deliveries)
        {
            Id = deliveries[deliveries.Count - 1].Id + 1;
        }
    }
}
