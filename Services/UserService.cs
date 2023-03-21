using contact_app.Data;
using contact_app.Models;

namespace contact_app.Services
{
    public class UserService : IUserService
    {
        private readonly ContactAppContext _context;

        public UserService(ContactAppContext context)
        {
            this._context = context;
        }

        public void Add(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }

        public User Get(int id)
        {
            return _context.Users.Find(id);
        }

        public User Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();

            return user;
        }
    }
}
