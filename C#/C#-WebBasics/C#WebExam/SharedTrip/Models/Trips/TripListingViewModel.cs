namespace SharedTrip.Models.Trips
{
    public class TripListingViewModel
    {
        public string TripId { get; init; }

        public string ImagePath { get; init; }

        public string StartPoint { get; init; } 

        public string EndPoint { get; init; }

        public string DepartureTime { get; init; } 

        public int Seats { get; init; }

        public bool HasFreeSeats { get; init; }

        public string Details { get; init; }

    }
}
