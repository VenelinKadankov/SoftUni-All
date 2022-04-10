namespace SharedTrip.UserServices
{
    using System.Collections.Generic;
    using SharedTrip.Models.Trips;
    using SharedTrip.Models.Users;

    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterUserFormModel model);

        ICollection<string> ValidateTrip(TripAddFormModel model);
    }
}
