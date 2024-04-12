using agendav2.contactDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agendav2.service.DAO
{

    class DAOToDoList
    {
        ContactContext Context;

        public DAOToDoList()
        {
            Context = new ContactContext();
        }
        //fonction qui retourne toutes les todolist
        public IEnumerable<ToDoList> GetAllToDoList()
        {
            using (Context = new ContactContext())
            {
                var AllToDoList = Context.ToDoLists.ToList();
                return AllToDoList;
            }
        }
        //fonction qui retourne une todolist selon l'id
        public ToDoList GetToDoListByID(int id)
        {
            using (Context = new ContactContext())
            {
                var ToDoList = Context.ToDoLists.Single(a => a.IdtoDo == id);
                return ToDoList;
            }
        }
        //fonction qui ajoute une todolist
        public void AddToDoList(ToDoList toDoList)
        {
            using (Context = new ContactContext())
            {
                Context.ToDoLists.Add(toDoList);
                Context.SaveChanges();
            }
        }

        //fonction qui modifie une todolist selon l'id
        public void ModifyToDoList(int id, ToDoList ToDoList)
        {
            using (Context = new ContactContext())
            {
                var ToDoListToModify = Context.ToDoLists.Single(a => a.IdtoDo == id);
                ToDoListToModify.Name = ToDoList.Name;
                ToDoListToModify.Description = ToDoList.Description;
                ToDoListToModify.Date = ToDoList.Date;
                ToDoListToModify.EndDate = ToDoList.EndDate;
                Context.SaveChanges();
            }
        }

        //fonction qui supprime une todolist selon l'id et supprime les taches associées
        public void DeleteToDoListAndTache(int id)
        {
            using (Context = new ContactContext())
            {
                var ToDoListToDelete = Context.ToDoLists.Single(a => a.IdtoDo == id);
                var TacheToDelete = Context.Taches.Where(a => a.ToDoListIdtoDo == id).ToList();
                foreach (var tache in TacheToDelete)
                {
                    Context.Taches.Remove(tache);
                }
                Context.ToDoLists.Remove(ToDoListToDelete);
                Context.SaveChanges();
            }
        }
    }
}
