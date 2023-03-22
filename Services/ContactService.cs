using contact_app.Data;
using contact_app.Models;

namespace contact_app.Services
{
    public class ContactService : IContactService
    {
        private readonly ContactAppContext _context;

        public ContactService(ContactAppContext context) 
        {
            this._context = context;
        }

        public Contact Get(int idContact, int idUser)
        {
            return _context.Contacts.Where(c => c.UserId == idUser && c.Id == idContact).FirstOrDefault();
        }

        public List<Contact> GetAll(int idUser) 
        {
            return _context.Contacts.Where(c => c.UserId == idUser).ToList();
        }

        public Contact Update(Contact _contact)
        {
            Contact contact = _context.Contacts.Find(_contact.Id);
            contact.Name = _contact.Name;
            contact.PhoneNumber = _contact.PhoneNumber;

            _context.Update(contact);
            _context.SaveChanges();

            return contact;
        }

        public void Delete(int idContact)
        {
            Contact _contact = _context.Contacts.Find(idContact);
            _context.Remove(_contact);
            _context.SaveChanges();
        }
    }
}
