namespace SharedTrip.UserServices
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
    }
}
