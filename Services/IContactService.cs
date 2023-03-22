﻿using contact_app.Models;

namespace contact_app.Services
{
    public interface IContactService
    {
        Contact Get(int idContact, int idUser);
        List<Contact> GetAll(int idUser);
        Contact Update(Contact _contact);
        void Delete(int idContact);

    }
}