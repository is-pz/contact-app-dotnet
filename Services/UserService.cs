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

        public Boolean Add(User user)
        {
            try
            {
                _context.Add(user);
                _context.SaveChanges();

                return true;
            }catch(Exception ex) {
                Console.WriteLine($"Excepcion: {ex}");
                return false;
            }
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


        public User ValidateUser(String email, String Password)
        {
            User? user = _context.Users.Where(c => c.Email == email).FirstOrDefault();
            if (user == null)
            {
                if (user.Password.Equals(Password))
                {
                    return null;
                }
            }
            return user;
        }
    }
}
