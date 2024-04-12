using agendav2.contactDB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//using Xamarin.Forms;

namespace agendav2.service.DAO
{
    public class DAOcontact 
    {
        ContactContext Context;

        public DAOcontact()
        {
            Context = new ContactContext();
        }
        //fonction qui permet ve verifier si la base de donnée et bien connecter
        public bool TestConnection()
        {
            using (Context = new ContactContext())
            {
                try
                {
                    Context.Database.OpenConnection();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        //fonction qui retourne tous les contacts
        public IEnumerable<Contact> GetAllContacts()
        {
            using (Context = new ContactContext())
            {
                var AllContact = Context.Contacts.ToList();
                return AllContact;
            }
        }
        //fonction qui crée un contact
        public int addContact(Contact contact)
        {
            using (Context = new ContactContext())
            {
                Context.Contacts.Add(contact);

                Context.SaveChanges();
            }
            return 1;
        }
        //fonction qui supprime un contact selon l'id
        public int removeContact(int id)
        {
            using (Context = new ContactContext())
            {
                var contact = Context.Contacts.Single(a => a.Idcontact == id);
                Context.Contacts.Remove(contact);

                Context.SaveChanges();
            }
            return 1;
        }   
        //fonction qui modifie un contact selon l'id
        public int updateContact(int id, Contact contact)
        {
            using (Context = new ContactContext())
            {
                var contacte = Context.Contacts.Single(a => a.Idcontact == id);
                contacte.Name = contact.Name;
                contacte.LastName = contact.LastName;
                contacte.Mail = contact.Mail;
                contacte.PhoneNumber = contact.PhoneNumber;
                contacte.Sex = contact.Sex;
                contacte.Status = contact.Status;
                contacte.Birth = contact.Birth;
                Context.Contacts.Update(contacte);

                Context.SaveChanges();
            }
            return 1;
        }   
    }
}