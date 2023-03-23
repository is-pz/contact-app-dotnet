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

        public Contact Get(int idContact, int idUser)
        {
            return context.Contacts.Where(c => c.UserId == idUser && c.Id == idContact).FirstOrDefault();
        }

        public List<Contact> GetAll(int idUser) 
        {
            return context.Contacts.Where(c => c.UserId == idUser).ToList();
        }

        public Boolean Create(Contact _contact)
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

        public Boolean Update(Contact _contact)
        {
            try
            {
                Contact contact = context.Contacts.Find(_contact.Id);
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
                Contact _contact = context.Contacts.Find(idContact);
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
