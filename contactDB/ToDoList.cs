using System;
using System.Collections.Generic;

namespace agendav2.contactDB;

public partial class ToDoList
{
    public int IdtoDo { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public DateOnly? Date { get; set; }

    public DateOnly? EndDate { get; set; }

    public virtual ICollection<Tache> Taches { get; set; } = new List<Tache>();
}
