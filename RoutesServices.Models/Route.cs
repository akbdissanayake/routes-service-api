using System;
using System.ComponentModel.DataAnnotations;

namespace RoutesServices.Models
{
    public class Route
    {
        [Required]
        public int RequestedStopId { get; set; }
        public DateTime RequestedDateTime { get; set; }
    }
}
