using contact_app.Data;
using contact_app.Models;

namespace contact_app.Services
{
    public class ContactService : IContactService
    {
        private readonly ContactAppContext context;

        public ContactService(ContactAppContext _context) 
        {
            this.context = _context;
        }

        public ContactModel Get(int idContact, int idUser)
        {
            return context.Contacts.Where(c => c.UserId == idUser && c.Id == idContact).FirstOrDefault();
        }

        public List<ContactModel> GetAll(int idUser) 
        {
            return context.Contacts.Where(c => c.UserId == idUser).ToList();
        }

        public Boolean Create(ContactModel _contact)
        {
            try
            {
                context.Add(_contact);
                context.SaveChanges();

                return true;
            }catch(Exception ex)
            {
                Console.WriteLine($"Excepcion: {ex.Message}");
                return false;
            }
        }

        public Boolean Update(ContactModel _contact)
        {
            try
            {
                ContactModel contact = context.Contacts.Find(_contact.Id);
                contact.Name = _contact.Name;
                contact.PhoneNumber = _contact.PhoneNumber;

                context.Update(contact);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public Boolean Delete(int idContact)
        {
            try
            {
                ContactModel _contact = context.Contacts.Find(idContact);
                context.Remove(_contact);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
