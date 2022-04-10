namespace SharedTrip.Controllers
{
    using System;
    using System.Globalization;
    using System.Linq;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SharedTrip.Data;
    using SharedTrip.Data.Models;
    using SharedTrip.Models.Trips;
    using SharedTrip.UserServices;

    public class TripsController : Controller
    {
        private readonly IValidator validator;
        private readonly ApplicationDbContext data;

        public TripsController(
            IValidator validator,
            ApplicationDbContext data)
        {
            this.validator = validator;
            this.data = data;
        }

        [Authorize]
        public HttpResponse All() 
        {
            var trips = this.data.Trips.Select(t => new TripListingViewModel
            {
                TripId = t.Id,
                StartPoint = t.StartPoint,
                EndPoint = t.EndPoint,
                Details = t.Description,
                DepartureTime = t.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                HasFreeSeats = t.Seats > 0,
                Seats = t.Seats
            }).ToList();

            return View(trips);
        }

        [Authorize]
        public HttpResponse Add() => View();

        [HttpPost]
        [Authorize]
        public HttpResponse Add(TripAddFormModel model)
        {
            var modelErrors = this.validator.ValidateTrip(model);

            var isDepartureTime = DateTime.TryParseExact(
                model.DepartureTime, "dd.MM.yyyy HH:mm",
                CultureInfo.InvariantCulture, DateTimeStyles.None,
                out DateTime departureTime);

            if (!isDepartureTime)
            {
                modelErrors.Add($"{model.DepartureTime} in not a valid time.");
            }

            if (modelErrors.Any())
            {
                return Redirect("/Trips/Add");
            }


            var trip = new Trip
            {
                StartPoint = model.StartPoint,
                EndPoint = model.EndPoint,
                DepartureTime = departureTime,
                Seats = int.Parse(model.Seats),
                Description = model.Description,
                ImagePath = model.ImagePath,
            };

            this.data.Trips.Add(trip);

            this.data.SaveChanges();

            return Redirect("/Trips/All");
        }


        [Authorize]
        public HttpResponse Details(string tripId)
        {
            var trip = this.data
                .Trips
                .Where(t => t.Id == tripId)
                .Select(t => new TripListingViewModel
                {
                    TripId = t.Id,
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    ImagePath = t.ImagePath,
                    DepartureTime = t.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                    Seats = t.Seats,
                    Details = t.Description,
                    HasFreeSeats = t.Seats > 0
                })
                .FirstOrDefault();

            if (trip == null)
            {
                return Error(new string[] { "Such a trip does not exists." });
            }

            return View(trip);
        }

        [Authorize]
        public HttpResponse AddUserToTrip(string tripId)
        {
            var alreadyAdded = this.data.UserTrips.Any(ut => ut.TripId == tripId && ut.UserId == this.User.Id);

            if (alreadyAdded)
            {
                return Redirect($"/Trips/Details?tripId={tripId}");
            }

            var userTrip = new UserTrip
            {
                UserId = this.User.Id,
                TripId = tripId
            };

            this.data.UserTrips.Add(userTrip);

            this.data.SaveChanges();

            this.data.Trips.FirstOrDefault(t => t.Id == tripId).Seats--;

            this.data.SaveChanges();

            return Redirect("/Trips/All");
        }
    }
}
