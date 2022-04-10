namespace SharedTrip.UserServices
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using SharedTrip.Models.Trips;
    using SharedTrip.Models.Users;
    using static Data.DataConstants;

    public class Validator : IValidator
    {
        public ICollection<string> ValidateTrip(TripAddFormModel model)
        {
            var errors = new List<string>();

            var seats = -1;
            var isNumber = int.TryParse(model.Seats, out seats);

            if (!isNumber)
            {
                errors.Add($"{model.Seats} should be a number.");
            }

            if (seats < TripMinSeats || seats > TripMaxSeats)
            {
                errors.Add($"The offered seats in the trip must be between {TripMinSeats} and {TripMaxSeats}.");
            }

            if (model.Description.Length > TripDescriptionMaxLength)
            {
                errors.Add($"The description of the trip should not be longer that {TripDescriptionMaxLength} characters.");
            }

            if (string.IsNullOrWhiteSpace(model.StartPoint) 
                || string.IsNullOrWhiteSpace(model.EndPoint) 
                || string.IsNullOrWhiteSpace(model.DepartureTime) 
                || string.IsNullOrWhiteSpace(model.Description)
                || string.IsNullOrWhiteSpace(model.Seats.ToString()))
            {
                errors.Add("There is additional information you should provide.");
            }

            return errors;
        }

        public ICollection<string> ValidateUser(RegisterUserFormModel user)
        {
            var errors = new List<string>();

            if (user.Username == null || user.Username.Length < UserMinUsername || user.Username.Length > DefaultMaxLength)
            {
                errors.Add($"Username '{user.Username}' is not valid. It must be between {UserMinUsername} and {DefaultMaxLength} characters long.");
            }

            if (user.Email == null || !Regex.IsMatch(user.Email, UserEmailRegularExpression))
            {
                errors.Add($"Email '{user.Email}' is not a valid e-mail address.");
            }

            if (user.Password == null || user.Password.Length < UserMinPassword || user.Password.Length > DefaultMaxLength)
            {
                errors.Add($"The provided password is not valid. It must be between {UserMinPassword} and {DefaultMaxLength} characters long.");
            }

            if (user.Password != null && user.Password.Any(x => x == ' '))
            {
                errors.Add($"The provided password cannot contain whitespaces.");
            }

            if (user.Password != user.ConfirmPassword)
            {
                errors.Add("Password and its confirmation are different.");
            }

            return errors;
        }
    }
}
