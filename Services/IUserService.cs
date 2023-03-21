using contact_app.Models;

namespace contact_app.Services
{
    public interface IUserService
    {
        User Get(int id);
        void Add(User user);
        User Update(User user);
    }
}
