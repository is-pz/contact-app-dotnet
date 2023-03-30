using contact_app.Data;
using contact_app.Models;
using contact_app.Utilities;
namespace contact_app.Services
{
    public class AccessService : IAccessService
    {
        private readonly ContactAppContext _context;

        public AccessService(ContactAppContext context)
        {
            this._context = context;
        }

        public String Add(UserModel user)
        {
            try
            {
                _context.Add(user);
                _context.SaveChanges();

                return "Registered successfully";
            }catch(Exception ex) {
                Console.WriteLine($"Excepcion: {ex}");
                return (ex.InnerException.ToString().Contains("The duplicate key value is")) ? 
                            "Email is already registered" : 
                            "An error occurred while trying to register the account";
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
                PasswordUtilities passwordU = new PasswordUtilities();
                if (passwordU.PasswordVerify(Password, user.Password))
                {
                    return user;
                }
            }
            return null;
        }
    }
}
