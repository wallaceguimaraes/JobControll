using api.Models.EntityModel.Users;

namespace api.Models.Interfaces
{
    public interface IUserAuthentication
    {
        Task<(bool, User)> SignIn(string login, string password);
        Task<(User?, string?)> FindUser(int holderId, string salt);
    }
}