namespace SharedTrip.Data.Models
{
    public class UserTrip
    {
        public string UserId { get; init; }

        public User User { get; set; }

        public string TripId { get; init; }

        public Trip Trip { get; set; }
    }
}

/*•	Has UserId – a string
•	Has User – a User object
•	Has TripId– a string
•	Has Trip – a Trip object
*/