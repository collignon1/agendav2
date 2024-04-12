using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using agendav2.contactDB;

namespace agendav2.service.DAO
{
    internal class DAOTache
    {
        ContactContext Context;
        public DAOTache()
        {
            Context = new ContactContext();
        }
        //fonction qui retourne toutes les taches
        public IEnumerable<Tache> GetAllTaches()
        {
            using (Context = new ContactContext())
            {
                var AllTache = Context.Taches.ToList();
                return AllTache;
            }
        }
        //fonction qui retourne une tache selon l'id
        public Tache GetTacheByID(int id)
        {
            using (Context = new ContactContext())
            {
                var Tache = Context.Taches.Single(a => a.Idtache == id);
                return Tache;
            }
        }
        //fonction qui ajoute une tache
        public void AddTache(Tache Tache)
        {
            using (Context = new ContactContext())
            {
                Context.Taches.Add(Tache);
                Context.SaveChanges();
            }
        }
        //fonction qui met à jour une tache
        public void UpdateTache(Tache Tache)
        {
            using (Context = new ContactContext())
            {
                var TacheToUpdate = Context.Taches.Single(a => a.Idtache == Tache.Idtache);
                TacheToUpdate.Name = Tache.Name;
                TacheToUpdate.Description = Tache.Description;
                TacheToUpdate.Check = Tache.Check;
                Context.SaveChanges();
            }
        }
        //fonction qui retourne une liste de tache selon l'id de la todolist
        public List<Tache> GetTacheByToDoList(int id)
        {
            using (Context = new ContactContext())
            {
                var Tache = Context.Taches.Where(a => a.ToDoListIdtoDo == id).ToList();
                return Tache;
            }
        }
        //fonction qui supprime une tache selon l'id
        public void DeleteTache(int id)
        {
            using (Context = new ContactContext())
            {
                var tache = Context.Taches.Single(a => a.Idtache == id);
                Context.Taches.Remove(tache);
                Context.SaveChanges();
            }
        }
    }
}