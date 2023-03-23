﻿using contact_app.Models;

namespace contact_app.Services
{
    public interface IContactService
    {
        Contact Get(int idContact, int idUser);
        List<Contact> GetAll(int idUser);
        Boolean Create(Contact _contact);
        Boolean Update(Contact _contact);
        Boolean Delete(int idContact);

    }
}
