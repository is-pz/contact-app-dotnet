using contact_app.Models;

namespace contact_app.Services
{
    public interface IUserService
    {
        UserModel Get(int id);
        Boolean Add(UserModel user);
        UserModel Update(UserModel user);
        UserModel ValidateUser(String email, String password);
    }
}
