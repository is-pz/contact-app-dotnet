using contact_app.Data;
using contact_app.Models;

namespace contact_app.Services
{
    public class AccessService : IAccessService
    {
        private readonly ContactAppContext _context;

        public AccessService(ContactAppContext context)
        {
            this._context = context;
        }

        public Boolean Add(UserModel user)
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

        public UserModel Get(int id)
        {
            return _context.Users.Find(id);
        }

        public UserModel Update(UserModel user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();

            return user;
        }


        public UserModel ValidateUser(String email, String Password)
        {
            UserModel? user = _context.Users.Where(c => c.Email == email).FirstOrDefault();
            if (user != null)
            {
                if (user.Password.Equals(Password))
                {
                    return user;
                }
            }
            return null;
        }
    }
}
