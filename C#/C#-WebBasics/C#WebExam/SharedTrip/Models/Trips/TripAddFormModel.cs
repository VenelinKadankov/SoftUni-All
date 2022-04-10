namespace SharedTrip.Models.Trips
{
    public class TripAddFormModel
    {
        public string StartPoint { get; init; }

        public string EndPoint { get; init; }

        public string DepartureTime { get; set; }

        public string ImagePath { get; init; }

        public string Seats { get; init; }

        public string Description { get; init; }
    }
}


//   
// <input min="2" max="6" type="number" class="form-control" id="seats" name="seats" placeholder="Number of free seats"> 