namespace SharedTrip.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants;

    public class Trip
    {
        [Key]
        [Required]
        [MaxLength(IdMaxLength)]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        public string StartPoint { get; set; }

        [Required]
        public string EndPoint { get; set; }

        [Required]
        public DateTime DepartureTime { get; set; }

        [Required]
        public int Seats { get; set; }

        [Required]
        [MaxLength(TripDescriptionMaxLength)]
        public string Description { get; set; }

        public string ImagePath { get; set; }

        public IEnumerable<UserTrip> UserTrips { get; init; } = new List<UserTrip>();
    }
}

/*•	Has an Id – a string, Primary Key
•	Has a StartPoint – a string (required)
•	Has a EndPoint – a string (required)
•	Has a DepartureTime – a datetime (required) 
•	Has a Seats – an integer with min value 2 and max value 6 (required)
•	Has a Description – a string with max length 80 (required)
•	Has a ImagePath – a string
•	Has UserTrips collection – a UserTrip type
*/
