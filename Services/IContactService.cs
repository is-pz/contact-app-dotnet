using contact_app.Models;

namespace contact_app.Services
{
    public interface IContactService
    {
        ContactModel Get(int idContact, int idUser);
        List<ContactModel> GetAll(int idUser);
        Boolean Create(ContactModel _contact);
        Boolean Update(ContactModel _contact);
        Boolean Delete(int idContact);

    }
}
