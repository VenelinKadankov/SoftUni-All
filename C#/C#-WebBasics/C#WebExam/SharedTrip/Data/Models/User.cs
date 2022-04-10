namespace SharedTrip.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants;

    public class User
    {
        [Key]
        [Required]
        [MaxLength(IdMaxLength)]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(DefaultMaxLength)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public IEnumerable<UserTrip> UserTrips { get; init; } = new List<UserTrip>();
    }
}

/*•	Has an Id – a string, Primary Key
•	Has a Username – a string with min length 5 and max length 20 (required)
•	Has an Email - a string (required)
•	Has a Password – a string with min length 6 and max length 20  - hashed in the database (required)
•	Has UserTrips collection – a UserTrip type
*/
